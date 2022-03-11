<<<<<<< HEAD
﻿using Identity.Service.EventHandlers.Commands;
using MediatR;
=======
﻿using Identity.Domain;
using Identity.Service.EventHandlers.Commands;
using MediatR;
using Microsoft.AspNetCore.Identity;
>>>>>>> 37efefdb37a2aa228744357c1615ffe5e8be5777
using Microsoft.AspNetCore.Mvc;

namespace Identity.Api.Controllers
{
    [Route("v1/identity")]
    [ApiController]
    public class IdentityController : ControllerBase
    {
        public IdentityController(ILogger<IdentityController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(UserCreateCommand userCreate)
        {
            if (ModelState.IsValid)
            {
                var result = await _mediator.Send(userCreate);
                if (!result.Succeeded)
                    return BadRequest(result.Errors);

                return Ok();
            }
            return BadRequest();
        }

<<<<<<< HEAD
        [HttpPost("authentication")]
        public async Task<IActionResult> Authentication(UserLoginCommand userLogin)
        {
            if (ModelState.IsValid)
            {
                var result = await _mediator.Send(userLogin);
                if (!result.Succeeded)
                    return BadRequest("Access denied");

                return Ok(result);
            }
            return BadRequest();
        }

=======
>>>>>>> 37efefdb37a2aa228744357c1615ffe5e8be5777
        private readonly ILogger<IdentityController> _logger;
        private readonly IMediator _mediator;
    }
}