using Microsoft.EntityFrameworkCore;
using Order.Persistence.Database;
using Order.Service.Queries.DTOs;
using Order.Service.Queries.Interfaces;
using Service.Common.Collection;
using Service.Common.Mapping;
using Service.Common.Paging;

namespace Order.Service.Queries.Contracts
{
    public class OrderQueryService : IOrderQueryService
    {
        public OrderQueryService(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<DataCollection<OrderDto>> GetAllAsync(int page, int take)
        {
            var collection = await _applicationDbContext.Orders
                .Include(x => x.Items)
                .OrderByDescending(x => x.OrderId)
                .GetPageAsync(page, take);

            return collection.MapTo<DataCollection<OrderDto>>();
        }

        public async Task<OrderDto> GetAsync(int id)
        {
            return (await _applicationDbContext.Orders.Include(x => x.Items).SingleAsync(x => x.OrderId == id)).MapTo<OrderDto>();
        }

        private readonly ApplicationDbContext _applicationDbContext;
    }
}