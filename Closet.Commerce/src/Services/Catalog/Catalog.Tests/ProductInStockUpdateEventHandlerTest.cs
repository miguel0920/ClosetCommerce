using Catalog.Domain;
using Catalog.Service.EventHandlers;
using Catalog.Service.EventHandlers.Commands;
using Catalog.Tests.Config;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
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
            handler.Handle(new ProductInStockUpdateStockCommand
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

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TryToSubstractStockWhenProductHasNotStock()
        {
            var context = ApplicationDbContextInMemory.Get();
            var productInStockId = 2;
            var productId = 2;

            context.Stocks.Add(new ProductInStock
            {
                ProductInStockId = productInStockId,
                ProductId = productId,
                Stock = 1,
            });

            context.SaveChanges();
            try
            {
                var handler = new ProductInStockUpdateEventHandler(context, GetLogger);
                handler.Handle(new ProductInStockUpdateStockCommand
                {
                    Items = new List<ProductIsStockUpdateItem>()
                {
                    new ProductIsStockUpdateItem
                    {
                        ProductId = productId,
                        Stock = 2,
                        Action = ProductStockAction.Substract
                    }
                }
                }, new CancellationToken()).Wait();
            }
            catch (AggregateException ex)
            {
                if (ex.GetBaseException() is Exception)
                {
                    throw new Exception(ex?.InnerException?.Message);
                }
            }
        }

        [TestMethod]
        public void TryToAddStockWhenProductExists()
        {
            var context = ApplicationDbContextInMemory.Get();
            var productInStockId = 3;
            var productId = 3;

            context.Stocks.Add(new ProductInStock
            {
                ProductInStockId = productInStockId,
                ProductId = productId,
                Stock = 1,
            });

            context.SaveChanges();

            var handler = new ProductInStockUpdateEventHandler(context, GetLogger);
            handler.Handle(new ProductInStockUpdateStockCommand
            {
                Items = new List<ProductIsStockUpdateItem>()
                {
                    new ProductIsStockUpdateItem
                    {
                        ProductId = productId,
                        Stock = 2,
                        Action = ProductStockAction.Add
                    }
                }
            }, new CancellationToken()).Wait();

            var stockInDB = context.Stocks.Single(x => x.ProductId == productId).Stock;
            Assert.AreEqual(stockInDB, 3);
        }

        [TestMethod]
        public void TryToAddStockWhenProductNotExist()
        {
            var context = ApplicationDbContextInMemory.Get();
            var productId = 4;

            var handler = new ProductInStockUpdateEventHandler(context, GetLogger);
            handler.Handle(new ProductInStockUpdateStockCommand
            {
                Items = new List<ProductIsStockUpdateItem>()
                {
                    new ProductIsStockUpdateItem
                    {
                        ProductId = productId,
                        Stock = 2,
                        Action = ProductStockAction.Add
                    }
                }
            }, new CancellationToken()).Wait();
        }
    }
}