using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Order.Persistence.Database.Configuration
{
    public class OrderDetailConfiguration
    {
        public OrderDetailConfiguration(EntityTypeBuilder<Domain.OrderDetail> entityTypeBuilder)
        {
            entityTypeBuilder.HasKey(x => x.OrderDetailId);
        }
    }
}