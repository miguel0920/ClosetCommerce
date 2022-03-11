using Identity.Domain;
using Identity.Service.EventHandlers.Commands;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Identity.Service.EventHandlers
{
    public class UserCreateEventHandler : IRequestHandler<UserCreateCommand, IdentityResult>
    {
        public UserCreateEventHandler(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IdentityResult> Handle(UserCreateCommand request, CancellationToken cancellationToken)
        {
            ApplicationUser entry = new()
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                UserName = request.Email
            };
            return await _userManager.CreateAsync(entry, request.Password);
        }

        private readonly UserManager<ApplicationUser> _userManager;
    }
}