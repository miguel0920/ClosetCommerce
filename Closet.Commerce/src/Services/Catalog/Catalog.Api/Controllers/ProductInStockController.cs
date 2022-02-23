using Catalog.Service.EventHandlers.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Catalog.Api.Controllers
{
    [Route("v1/stocks")]
    [ApiController]
    public class ProductInStockController : ControllerBase
    {
        public ProductInStockController(ILogger<ProductInStockController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }
        [HttpPut]
        public async Task<IActionResult> UpdateStock(ProductIsStockUpdateStockCommand command)
        {
            await _mediator.Publish(command);
            return NoContent();
        }

        private readonly ILogger<ProductInStockController> _logger;
        private readonly IMediator _mediator;
    }
}