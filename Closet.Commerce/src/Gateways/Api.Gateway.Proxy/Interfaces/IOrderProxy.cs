using Api.Gateway.Models;
using Api.Gateway.Models.Order.Commands;
using Api.Gateway.Models.Order.DTOs;

namespace Api.Gateway.Proxies.Interfaces
{
    public interface IOrderProxy
    {
        Task CreateAsync(OrderCreateCommand command);
        Task<DataCollection<OrderDto>?> GetAllAsync(int page, int take);
        Task<OrderDto?> GetAsync(int id);
    }
}