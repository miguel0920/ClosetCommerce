using Microsoft.Azure.ServiceBus;
using Microsoft.Extensions.Options;
using Order.Service.Proxies.Catalog.Commands;
using Order.Service.Proxies.Catalog.Interfaces;
using System.Text;
using System.Text.Json;

namespace Order.Service.Proxies.Catalog.Contracts
{
    public class CatalogQueueProxy : ICatalogProxy
    {
        public CatalogQueueProxy(IOptions<AzureServiceBus> azureConfig)
        {
            _azureServiceBus = azureConfig.Value;
        }

        public async Task UpdateStockAsync(ProductInStockUpdateStockCommand stockUpdateStockCommand)
        {
            var queueClient = new QueueClient(_azureServiceBus.ConnectionString, "");

            //Serialize message
            string body = JsonSerializer.Serialize(stockUpdateStockCommand);
            Message message = new Message(Encoding.UTF8.GetBytes(body));

            //send the message to the queue
            await queueClient.SendAsync(message);

            //Close
            await queueClient.CloseAsync();
        }

        private readonly AzureServiceBus _azureServiceBus;
    }
}