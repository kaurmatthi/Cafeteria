using HomeCafeteriaApi.Data;
using HomeCafeteriaApi.Data.Repositories;
using HomeCafeteriaApi.Models;
using HomeCafeteriaApi.Models.DataModels;
using HomeCafeteriaApi.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace HomeCafeteriaApi.Controllers;

[Route("api/Cafeteria/Salesmen")]
[ApiController]
public class SalesmenController : ControllerBase
{
    private readonly ProductsRepository _products;
    private readonly ProductInstancesRepository _instances;
    private readonly SalesmenRepository _salesmen;
    private readonly SalesmanItemsRepository _salesmanItems;
    public SalesmenController(HomeCafeteriaApiContext context)
    {
        _products = new ProductsRepository(context, context.Product);
        _instances = new ProductInstancesRepository(context, context.ProductInstances);
        _salesmen = new SalesmenRepository(context, context.Salesmen);
        _salesmanItems = new SalesmanItemsRepository(context, context.SalesmenItems);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<SalesmanView>> GetSalesman(string id)
    {
        var salesman = await _salesmen.Get(id);
        if (salesman == null) return NotFound();

        var allItems = await _salesmanItems.Get();
        var salesManItems = allItems.Where(x => x.SalesmanId == id).GroupBy(x => x.ProductTypeId);

        var items = new List<ProductView>();

        foreach (var salesmanItem in salesManItems)
        {
            var group = salesmanItem.ToList();

            var item = await _products.Get(group[0].ProductTypeId);

            if (item != null) items.Add(new ProductView(item.Id, item.Name, group.Count, item.ImageUrl, item.Price));
        }


        return new SalesmanView(salesman.Id, salesman.Name, items, 0);
    }

    [HttpGet("{id}/ClearBasket")]
    public async Task<ActionResult<SalesmanView>> ClearBasket(string id)
        => await GetItemsChangeStatus(id, ProductInstanceState.Available);

    [HttpGet("{id}/Checkout")]
    public async Task<ActionResult<SalesmanView>> Checkout(string id)
        => await GetItemsChangeStatus(id, ProductInstanceState.Sold);

    private async Task<ActionResult<SalesmanView>> GetItemsChangeStatus(string id, ProductInstanceState state)
    {
        var res = await _salesmanItems.Get();
        var result = res.Where(x => x.SalesmanId == id);

        foreach (var item in result)
        {
            var instance = await _instances.Get(item.ProductInstanceId);
            if (instance == null) continue;
            instance.State = state;
            await _instances.Update(instance);
            await _salesmanItems.Delete(item);
        }

        return await GetSalesman(id);
    }

    [HttpGet]
    public async Task<IEnumerable<Salesman>> GetSalesmen()
        => await _salesmen.Get();

    [HttpGet("{id}/Authenticate")]
    public async Task<ActionResult> Authenticate(string id)
    {
        var result = await _salesmen.Get(id);
        if (result != null) return Ok();
        return BadRequest();
    }

    // GET: api/Products/5
    [HttpGet("AddToCart/{id}")]
    public async Task<ActionResult<SalesmanView>> AddToCart(string id, string salesmanId)
    {
        var product = await _products.Get(id);
        var salesman = await _salesmen.Get(salesmanId);

        if (product == null || salesman == null)
            return NotFound();


        var instances = await _instances.Get();
        var instance = instances.FirstOrDefault(x => x.ProductId == id && x.State == ProductInstanceState.Available);
        if (instance != null)
        {
            instance.State = ProductInstanceState.Reserved;
            await _instances.Update(instance);
            await _salesmanItems.Add(new SalesmanItem(salesmanId, instance.Id, instance.ProductId));
        }

        var result = await GetSalesman(salesmanId);

        instances = await _instances.Get();
        var count = instances.Count(x => x.ProductId == id && x.State == ProductInstanceState.Available);
        if (result.Value != null) result.Value.ProductCount = count;
        return result;
    }
}