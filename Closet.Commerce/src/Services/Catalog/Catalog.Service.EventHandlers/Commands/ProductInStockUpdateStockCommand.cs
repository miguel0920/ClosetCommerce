using MediatR;
using static Catalog.Common.Enums;

namespace Catalog.Service.EventHandlers.Commands
{
    public class ProductInStockUpdateStockCommand : INotification
    {
        public IEnumerable<ProductIsStockUpdateItem> Items { get; set; } = new List<ProductIsStockUpdateItem>();
    }

    public class ProductIsStockUpdateItem
    {
        public int ProductId { get; set; }
        public int Stock { get; set; }
        public ProductStockAction Action { get; set; }
    }
}