using Catalog.Persistence.Database;
using Catalog.Service.Queries.DTOs;
using Catalog.Service.Queries.Interfaces;
using Microsoft.EntityFrameworkCore;
using Service.Common.Collection;
using Service.Common.Mapping;
using Service.Common.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.Service.Queries.Contracts
{
    public class ProductQueryService : IProductQueryService
    {
        public ProductQueryService(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<DataCollection<ProductDto>> GetAllAsync(int page, int take, IEnumerable<int> products = null)
        {
            var collection = await _applicationDbContext.Products
                .Where(p => products == null || products.Contains(p.ProductId))
                .OrderByDescending(p => p.ProductId)
                .GetPageAsync(page, take);

            return collection.MapTo<DataCollection<ProductDto>>();
        }

        public async Task<ProductDto> GetAsync(int id)
        {
            return (await _applicationDbContext.Products.SingleAsync(x => x.ProductId == id)).MapTo<ProductDto>();
        }

        private readonly ApplicationDbContext _applicationDbContext;
    }
}