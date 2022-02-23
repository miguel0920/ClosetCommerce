using Customer.Domain;
using Customer.Persistence.Database;
using Customer.Service.EventHandlers.Commands;
using MediatR;

namespace Customer.Service.EventHandlers
{
    public class ClientCreateEventHandlers : INotificationHandler<ClientCreateCommand>
    {
        public ClientCreateEventHandlers(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task Handle(ClientCreateCommand notification, CancellationToken cancellationToken)
        {
            await _applicationDbContext.AddAsync(new Client
            {
                Name = notification.Name
            }, cancellationToken);
            await _applicationDbContext.SaveChangesAsync(cancellationToken);
        }

        private readonly ApplicationDbContext _applicationDbContext;
    }
}