using Customer.Service.EventHandlers.Commands;
using Customer.Service.Queries.DTOs;
using Customer.Service.Queries.Interfaces;
using MediatR;
<<<<<<< HEAD
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
=======
>>>>>>> 37efefdb37a2aa228744357c1615ffe5e8be5777
using Microsoft.AspNetCore.Mvc;
using Service.Common.Collection;

namespace Customer.Api.Controllers
{
    [Route("v1/clients")]
    [ApiController]
<<<<<<< HEAD
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
=======
>>>>>>> 37efefdb37a2aa228744357c1615ffe5e8be5777
    public class ClientController : ControllerBase
    {
        public ClientController(IClientQueryService clientQueryService, ILogger<ClientController> logger, IMediator mediator)
        {
            _clientQueryService = clientQueryService;
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<DataCollection<ClientDto>> Get(int page = 1, int take = 10, string? ids = null)
        {
            IEnumerable<int>? clients = null;

            if (!string.IsNullOrEmpty(ids))
            {
                clients = ids.Split(',').Select(x => Convert.ToInt32(x));
            }

            return await _clientQueryService.GetAllAsync(page, take, clients);
        }

        [HttpGet("{id}")]
        public async Task<ClientDto> Get(int id)
        {
            return await _clientQueryService.GetAsync(id);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ClientCreateCommand notification)
        {
            await _mediator.Publish(notification);
            return Ok();
        }

        private readonly IClientQueryService _clientQueryService;
        private readonly IMediator _mediator;
        private readonly ILogger<ClientController> _logger;
    }
}