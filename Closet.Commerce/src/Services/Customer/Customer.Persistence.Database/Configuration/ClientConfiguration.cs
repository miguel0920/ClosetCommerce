using Customer.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Customer.Persistence.Database.Configuration
{
    public class ClientConfiguration
    {
        public ClientConfiguration(EntityTypeBuilder<Client> typeBuilder)
        {
            typeBuilder.HasIndex(x => x.ClientId);
            typeBuilder.Property(x => x.Name).IsRequired().HasMaxLength(100);

            List<Client> clients = new();
            for (int i = 1; i <= 10; i++)
            {
                clients.Add(new Client
                {
                    ClientId = i,
                    Name = $"Client {i}"
                });
            }

            typeBuilder.HasData(clients);
        }
    }
}