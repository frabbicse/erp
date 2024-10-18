using Infrastructure.Common;
using Infrastructure.IServices.IAuthService;
using Infrastructure.Security;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

using Models;
using Models.Auth;

using Persistance;

using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Infrastructure.Services.AuthServices
{
    public class LoginService : ILoginService
    {
        private readonly ERPContext _context;
        private readonly ITokenGenerator _tokenGenerator;
        private readonly ILogger<LoginService> _logger;

        public LoginService(ERPContext context, ITokenGenerator tokenGenerator, ILogger<LoginService> logger)
        {
            _context = context;
            _tokenGenerator = tokenGenerator;
            _logger = logger;
        }

        public async Task<User> SignIn(Login login)
        {

            var registeredUser = await _context.Register.AnyAsync(user => user.UserName == login.UserName);

            var registeredPassword = await _context.Register.AnyAsync(user => user.Password == login.Password);

            if (!registeredUser || !registeredPassword)

                throw new RestException(HttpStatusCode.NotFound, "User Name or Password Not Found/Matched.");

            if (registeredUser && registeredPassword)
            {
                var user = new User
                {
                    UserName = login.UserName
                };

                return new User
                {
                    UserName = login.UserName,
                    Token = _tokenGenerator.CreateToken(user)
                };
            }
            _logger.LogInformation("");
            throw new RestException(HttpStatusCode.BadRequest);
            
        }

        public async Task SignOut()
        {
            throw new NotImplementedException();
        }
    }
}
