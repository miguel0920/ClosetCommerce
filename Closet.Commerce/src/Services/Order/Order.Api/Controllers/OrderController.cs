using MediatR;
using Microsoft.AspNetCore.Mvc;
using Order.Service.EventHandlers.Commands;
using Order.Service.Queries.DTOs;
using Order.Service.Queries.Interfaces;
using Service.Common.Collection;

namespace Order.Api.Controllers
{
    [Route("v1/orders")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        public OrderController(IOrderQueryService orderQueryService, ILogger<OrderController> logger, IMediator mediator)
        {
            _orderQueryService = orderQueryService;
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<DataCollection<OrderDto>> GetAll(int page = 1, int take = 10)
        {
            return await _orderQueryService.GetAllAsync(page, take);
        }

        [HttpGet("{id}")]
        public async Task<OrderDto> Get(int id)
        {
            return await _orderQueryService.GetAsync(id);
        }

        [HttpPost]
        public async Task<IActionResult> Create(OrderCreateCommand notification)
        {
            await _mediator.Publish(notification);
            return Ok();
        }

        private readonly IOrderQueryService _orderQueryService;
        private readonly ILogger<OrderController> _logger;
        private readonly IMediator _mediator;
    }
}