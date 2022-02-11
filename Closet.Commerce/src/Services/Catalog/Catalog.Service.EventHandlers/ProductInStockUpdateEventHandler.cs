using Catalog.Domain;
using Catalog.Persistence.Database;
using Catalog.Service.EventHandlers.Commands;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using static Catalog.Common.Enums;

namespace Catalog.Service.EventHandlers
{
    public class ProductInStockUpdateEventHandler : INotificationHandler<ProductIsStockUpdateStockCommand>
    {
        public ProductInStockUpdateEventHandler(ApplicationDbContext dbContext, ILogger<ProductInStockUpdateEventHandler> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }
        public async Task Handle(ProductIsStockUpdateStockCommand notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"--- {nameof(ProductIsStockUpdateStockCommand)} started ---");

            IEnumerable<int> product = notification.Items.Select(x => x.ProductId);
            List<ProductInStock> stocks = await _dbContext.Stocks.Where(x => product.Contains(x.ProductId)).ToListAsync(cancellationToken: cancellationToken);

            _logger.LogInformation($"--- Retrieve products from database");
            foreach (ProductIsStockUpdateItem item in notification.Items)
            {
                ProductInStock? entry = stocks.SingleOrDefault(x => x.ProductId == item.ProductId);
                if (item.Action == ProductStockAction.Substract)
                {
                    if (entry == null || item.Stock > entry.Stock)
                    {
                        _logger.LogError($"--- Product {entry?.ProductId} - doesn't have enough stock");
                        throw new Exception($"Product {entry?.ProductId} - doesn't have enough stock");
                    }
                    entry.Stock -= item.Stock;
                    _logger.LogInformation($"--- Product {entry?.ProductId} - its stock war substracted - new stock {entry?.Stock}");
                }
                else
                {
                    if (entry == null)
                    {
                        entry = new ProductInStock
                        {
                            ProductId = item.ProductId,
                        };
                        await _dbContext.AddAsync(entry, cancellationToken);
                        _logger.LogInformation($"--- New stock record was create for {entry?.ProductId} because didn't exists before");
                    }
                    entry.Stock += item.Stock;

                    _logger.LogInformation($"--- Product {entry?.ProductId} its stock was increased and its new stock is {entry?.Stock}");
                }
            }

            await _dbContext.SaveChangesAsync(cancellationToken);

            _logger.LogInformation($"--- {nameof(ProductIsStockUpdateStockCommand)} Ended ---");
        }

        private readonly ILogger<ProductInStockUpdateEventHandler> _logger;
        private readonly ApplicationDbContext _dbContext;
    }
}