using Identity.Persistence.Database;
using Identity.Service.Queries.DTOs;
using Identity.Service.Queries.Interfaces;
using Microsoft.EntityFrameworkCore;
using Service.Common.Collection;
using Service.Common.Mapping;
using Service.Common.Paging;

namespace Identity.Service.Queries.Contracts
{
    public class UserQueryService : IUserQueryService
    {
        public UserQueryService(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<DataCollection<UserDto>> GetAllAsync(int page, int take, IEnumerable<string> users = null)
        {
            var collection = await _applicationDbContext.Users
                .Where(x => users == null || users.Contains(x.Id))
                .OrderBy(x => x.FirstName)
                .GetPageAsync(page, take);

            return collection.MapTo<DataCollection<UserDto>>();
        }

        public async Task<UserDto> GetAsync(string id)
        {
            return (await _applicationDbContext.Users.SingleAsync(x => x.Id == id)).MapTo<UserDto>();
        }

        private readonly ApplicationDbContext _applicationDbContext;
    }
}