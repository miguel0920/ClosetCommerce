using Order.Service.Proxies.Catalog.Commands;

namespace Order.Service.Proxies.Catalog.Interfaces
{
    public interface ICatalogProxy
    {
        Task UpdateStockAsync(ProductInStockUpdateStockCommand stockUpdateStockCommand);
    }
}