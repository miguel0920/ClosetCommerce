using Catalog.Domain;
using Catalog.Service.EventHandlers;
using Catalog.Service.EventHandlers.Commands;
using Catalog.Tests.Config;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Threading;
using static Catalog.Common.Enums;

namespace Catalog.Tests
{
    [TestClass]
    public class ProductInStockUpdateEventHandlerTest
    {
        private ILogger<ProductInStockUpdateEventHandler> GetLogger
        {
            get { return new Mock<ILogger<ProductInStockUpdateEventHandler>>().Object; }
        }

        [TestMethod]
        public void TryToSubstractStockWhenProductHasStock()
        {
            var context = ApplicationDbContextInMemory.Get();
            var productInStockId = 1;
            var productId = 1;

            context.Stocks.Add(new ProductInStock
            {
                ProductInStockId = productInStockId,
                ProductId = productId,
                Stock = 1,
            });

            context.SaveChanges();

            var handler = new ProductInStockUpdateEventHandler(context, GetLogger);
            handler.Handle(new ProductIsStockUpdateStockCommand
            {
                Items = new List<ProductIsStockUpdateItem>()
                {
                    new ProductIsStockUpdateItem
                    {
                        ProductId = productId,
                        Stock = 1,
                        Action = ProductStockAction.Substract
                    }
                }
            }, new CancellationToken()).Wait();
        }
    }
}