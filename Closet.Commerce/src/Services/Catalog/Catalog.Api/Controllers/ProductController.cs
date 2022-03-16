using Catalog.Service.EventHandlers.Commands;
using Catalog.Service.Queries.DTOs;
using Catalog.Service.Queries.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Service.Common.Collection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Catalog.Api.Controllers
{
    [Route("v1/products")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ProductController : ControllerBase
    {
        public ProductController(IProductQueryService productQueryService, ILogger<ProductController> logger, IMediator mediator)
        {
            _productQueryService = productQueryService;
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<DataCollection<ProductDto>> GetAll(int page = 1, int take = 10, string ids = null)
        {
            IEnumerable<int> products = null;
            if (!string.IsNullOrEmpty(ids))
            {
                products = ids.Split(',').Select(x => Convert.ToInt32(x));
            }
            return await _productQueryService.GetAllAsync(page, take, products);
        }

        [HttpGet("{id}")]
        public async Task<ProductDto> GetProductId(int id)
        {
            return await _productQueryService.GetAsync(id);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductCreateCommand productCreate)
        {
            await _mediator.Publish(productCreate, new CancellationToken(false));
            return Ok();
        }

        private readonly IProductQueryService _productQueryService;
        private readonly IMediator _mediator;
        private readonly ILogger<ProductController> _logger;
    }
}