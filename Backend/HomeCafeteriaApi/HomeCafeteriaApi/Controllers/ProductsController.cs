#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HomeCafeteriaApi.Data;
using HomeCafeteriaApi.Data.Repositories;
using HomeCafeteriaApi.Models;
using HomeCafeteriaApi.Models.DataModels;
using HomeCafeteriaApi.Models.ViewModels;
using Microsoft.AspNetCore.Cors;

namespace HomeCafeteriaApi.Controllers
{
    [Route("api/Cafeteria/Products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ProductsRepository _products;
        private readonly ProductInstancesRepository _instances;

        public ProductsController(HomeCafeteriaApiContext context)
        {
            _products = new ProductsRepository(context, context.Product);
            _instances = new ProductInstancesRepository(context, context.ProductInstances);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductView>>> GetProduct()
        {
            var types = await _products.Get();
            var instances = await _instances.Get();

            return types.Select(type => new ProductView(type.Id, type.Name, 
                instances.Count(x => x.ProductId == type.Id && x.State == ProductInstanceState.Available), type.ImageUrl, type.Price))
                .OrderByDescending(x => x.Quantity).ToList();
        }

        [HttpGet("Add/{id}")]
        public async Task<ActionResult<ProductView>> AddProduct(string id, int count)
        {
            if (count > 1000) return BadRequest();
            var type = await _products.Get(id);
            if (type == null) return NotFound();
            var instances = new List<ProductInstance>();
            for (var i = 0; i < count; i++)
                instances.Add(new ProductInstance(type.Id));
            await _instances.AddRange(instances);

            return Ok(type);
        }

        [HttpGet("Types")]
        public async Task<IEnumerable<ProductType>> GetProductTypes() 
            => await _products.Get();
    }
}
