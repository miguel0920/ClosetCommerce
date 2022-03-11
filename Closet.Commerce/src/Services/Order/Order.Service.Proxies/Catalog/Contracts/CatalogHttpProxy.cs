using Microsoft.Extensions.Options;
using Order.Service.Proxies.Catalog.Commands;
using Order.Service.Proxies.Catalog.Interfaces;
using System.Text;
using System.Text.Json;

namespace Order.Service.Proxies.Catalog.Contracts
{
    public class CatalogHttpProxy : ICatalogProxy
    {
        public CatalogHttpProxy(IOptions<ApiUrls> apiUrls, HttpClient httpClient)
        {
            _apiUrls = apiUrls.Value;
            _httpClient = httpClient;
        }

        public async Task UpdateStockAsync(ProductInStockUpdateStockCommand stockUpdateStockCommand)
        {
            StringContent content = new(JsonSerializer.Serialize(stockUpdateStockCommand),
                Encoding.UTF8, "application/json");
            var request = await _httpClient.PutAsync($"{_apiUrls.CatalogUrlBase}/v1/stocks", content);
            request.EnsureSuccessStatusCode();
        }

        private readonly HttpClient _httpClient;
        private readonly ApiUrls _apiUrls;
    }
}