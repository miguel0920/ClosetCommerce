using static Order.Service.Proxies.Catalog.Common.Enums;

namespace Order.Service.Proxies.Catalog.Commands
{
    public class ProductInStockUpdateStockCommand
    {
        public IEnumerable<ProductIsStockUpdateItem> Items { get; set; } = new List<ProductIsStockUpdateItem>();

        public class ProductIsStockUpdateItem
        {
            public int ProductId { get; set; }
            public int Stock { get; set; }
            public ProductStockAction Action { get; set; }
        }
    }
}