using Customer.Service.EventHandlers;
using Customer.Service.EventHandlers.Commands;
using Customer.Test.Config;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;

namespace Customer.Test
{
    [TestClass]
    public class ClientCreateEventHandlerTest
    {
        [TestMethod]
        public void TryToClientCreate()
        {
            var context = ApplicationDbContextInMemory.Get();

            var handler = new ClientCreateEventHandlers(context);
            handler.Handle(new ClientCreateCommand
            {
                Name = "Miguel",
            }, new CancellationToken()).Wait();
        }
    }
}