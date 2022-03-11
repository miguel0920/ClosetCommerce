using Catalog.Service.EventHandlers.Commands;
using MediatR;
<<<<<<< HEAD
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
=======
>>>>>>> 37efefdb37a2aa228744357c1615ffe5e8be5777
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Catalog.Api.Controllers
{
    [Route("v1/stocks")]
    [ApiController]
<<<<<<< HEAD
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
=======
>>>>>>> 37efefdb37a2aa228744357c1615ffe5e8be5777
    public class ProductInStockController : ControllerBase
    {
        public ProductInStockController(ILogger<ProductInStockController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }
        [HttpPut]
        public async Task<IActionResult> UpdateStock(ProductInStockUpdateStockCommand command)
        {
            await _mediator.Publish(command);
            return NoContent();
        }

        private readonly ILogger<ProductInStockController> _logger;
        private readonly IMediator _mediator;
    }
}