<<<<<<< HEAD
﻿using Identity.Service.Queries.DTOs;
using Identity.Service.Queries.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Common.Collection;
=======
﻿using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
>>>>>>> 37efefdb37a2aa228744357c1615ffe5e8be5777

namespace Identity.Api.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("v1/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
<<<<<<< HEAD
        public UserController(IUserQueryService userQueryService, ILogger<UserController> logger, IMediator mediator)
        {
            _userQueryService = userQueryService;
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<DataCollection<UserDto>> GetAll(int page = 1, int take = 10, string ids = null)
        {
            IEnumerable<string>? users = ids?.Split(',');
            return await _userQueryService.GetAllAsync(page, take, users);
        }

        [HttpGet("{id}")]
        public async Task<UserDto> Get(string id)
        {
            return await _userQueryService.GetAsync(id);
        }

        private readonly IUserQueryService _userQueryService;
        private readonly ILogger<UserController> _logger;
        private readonly IMediator _mediator;
=======
>>>>>>> 37efefdb37a2aa228744357c1615ffe5e8be5777
    }
}