using Identity.Domain;
using Identity.Persistence.Database;
using Identity.Service.EventHandlers.Commands;
using Identity.Service.EventHandlers.Responses;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Identity.Service.EventHandlers
{
    public class UserLoginEventHandler : IRequestHandler<UserLoginCommand, IdentityAccess>
    {
        public UserLoginEventHandler(SignInManager<ApplicationUser> userManager, ApplicationDbContext context, IConfiguration configuration)
        {
            _userManager = userManager;
            _context = context;
            _configuration = configuration;
        }

        public async Task<IdentityAccess> Handle(UserLoginCommand request, CancellationToken cancellationToken)
        {
            IdentityAccess result = new();

            ApplicationUser user = await _context.Users.SingleAsync(x => x.Email == request.Email, cancellationToken);
            var response = await _userManager.CheckPasswordSignInAsync(user, request.Password, false);

            if (response.Succeeded)
            {
                result.Succeeded = true;
                await GenerateToken(user, result);
            }

            return result;
        }

        private async Task GenerateToken(ApplicationUser user, IdentityAccess result)
        {
            var secretKey = _configuration.GetValue<string>("SecretKey");
            var key = Encoding.ASCII.GetBytes(secretKey);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Name, user.FirstName),
                new Claim(ClaimTypes.Surname, user.LastName)
            };

            var roles = await _context.Roles
                          .Where(x => x.UserRoles.Any(y => y.UserId == user.Id))
                          .ToListAsync();

            foreach (var role in roles)
            {
                claims.Add(
                    new Claim(ClaimTypes.Role, role.Name)
                );
            }

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature
                )
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var createdToken = tokenHandler.CreateToken(tokenDescriptor);

            result.AccessToken = tokenHandler.WriteToken(createdToken);
        }

        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;
        private readonly SignInManager<ApplicationUser> _userManager;
    }
}