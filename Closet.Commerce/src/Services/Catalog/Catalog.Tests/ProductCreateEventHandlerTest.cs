using Catalog.Service.EventHandlers;
using Catalog.Service.EventHandlers.Commands;
using Catalog.Tests.Config;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;

namespace Catalog.Test
{
    [TestClass]
    public class ProductCreateEventHandlerTest
    {
        [TestMethod]
        public void TryToProductCreate()
        {
            var context = ApplicationDbContextInMemory.Get();

            var handler = new ProductCreateEventHandler(context);
            handler.Handle(new ProductCreateCommand
            {
                Description = "Table",
                Name = "Table",
                Price = 18000
            }, new CancellationToken()).Wait();
        }
    }
}