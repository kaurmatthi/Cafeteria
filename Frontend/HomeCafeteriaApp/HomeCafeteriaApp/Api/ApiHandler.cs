using System.Net.Http.Json;
using HomeCafeteriaApp.Models;

namespace HomeCafeteriaApp.Api
{
    public class ApiHandler
    {
        private readonly HttpClient _client;
        private const string BaseUrl = Constants.ApiUrl;

        public ApiHandler()
        {
            _client = new HttpClient();
        }

        private async Task<SalesmanView?> SalesmanCall(string endPoint)
        {
            try
            {
                return await _client.GetFromJsonAsync<SalesmanView>(BaseUrl + "Salesmen/" + endPoint);
            }
            catch (Exception)
            {
                return null;
            }
        }

        private async Task<List<ProductView>?> ProductCall(string endPoint)
        {
            try
            {
                return await _client.GetFromJsonAsync<List<ProductView>>(BaseUrl + "Products/" + endPoint);
            }
            catch (Exception)
            {
                return null;
            }
        }

        private async Task<HttpResponseMessage?> Call(string endpoint)
        {
            try
            {
                return await _client.GetAsync(BaseUrl + endpoint);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<HttpResponseMessage?> Authenticate(string token)
            => await Call("Salesmen/" + token + "/Authenticate");
        public async Task<SalesmanView?> GetSalesmanView(string salesmanId) 
            => await SalesmanCall(salesmanId);

        public async Task<SalesmanView?> AddToCart(string productId, string salesmanId)
            => await SalesmanCall("AddToCart/" + productId + "?salesmanId=" + salesmanId);

        public async Task<SalesmanView> ClearCart(SalesmanView salesman)
            => await SalesmanCall(salesman.SalesmanId + "/ClearBasket") ?? salesman;

        public async Task<SalesmanView> Checkout(SalesmanView salesman)
            => await SalesmanCall(salesman.SalesmanId + "/Checkout") ?? salesman;

        public async Task<List<ProductView>> GetProducts() 
            => await ProductCall("") ?? new List<ProductView>();

        public async Task<HttpResponseMessage?> AddProducts(string selectedProduct, int count) =>
            await Call("Products/Add/" + selectedProduct + "?count=" + count);
    }
}
