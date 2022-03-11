using Microsoft.EntityFrameworkCore;
using Service.Common.Collection;

namespace Service.Common.Paging
{
    public static class PagingExtension
    {
        public static async Task<DataCollection<T>> GetPageAsync<T>(this IQueryable<T> query, int page, int take)
        {
            var originalPages = page;

            page--;

            if (page > 0)
                page *= take;

            DataCollection<T> result = new()
            {
                Items = await query.Skip(page).Take(take).ToListAsync(),
                Total = await query.CountAsync(),
                Page = originalPages
            };

            if (result.Total > 0)
                result.Pages = Convert.ToInt32(Math.Ceiling(Convert.ToDecimal(result.Total) / take));

            return result;
        }
    }
}