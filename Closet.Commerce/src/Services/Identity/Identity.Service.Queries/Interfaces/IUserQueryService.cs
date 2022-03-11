using Identity.Service.Queries.DTOs;
using Service.Common.Collection;

namespace Identity.Service.Queries.Interfaces
{
    public interface IUserQueryService
    {
        Task<DataCollection<UserDto>> GetAllAsync(int page, int take, IEnumerable<string> users = null);
        Task<UserDto> GetAsync(string id);
    }
}