using Catalog.Domain;
using Catalog.Persistence.Database;
using Catalog.Service.EventHandlers.Commands;
using MediatR;

namespace Catalog.Service.EventHandlers
{
    public class ProductCreateEventHandler : INotificationHandler<ProductCreateCommand>
    {
        public ProductCreateEventHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task Handle(ProductCreateCommand notification, CancellationToken cancellationToken)
        {
            await _dbContext.AddAsync(new Product
            {
                Description = notification.Description,
                Name = notification.Name,
                Price = notification.Price
            }, cancellationToken);

            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        private readonly ApplicationDbContext _dbContext;
    }
}