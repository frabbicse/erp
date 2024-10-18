using Infrastructure.Common;
using Infrastructure.IServices.IAuthService;

using Microsoft.EntityFrameworkCore;

using Models;
using Models.Auth;

using Persistance;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services.AuthServices
{
  public  class RegisterService : IRegisterService
    {
       ERPContext _context;

        public RegisterService(ERPContext context)
        {
            _context = context;
        }
        public async Task<bool> Register(Register register)
        {
            bool exists = _context.Register.Any(user => user.UserName == register.UserName & user.EmailId == register.EmailId);

            if (!exists)
            {
                _context.Register.Add(register);

                var loginCred = new Login
                {
                    UserName = register.UserName,
                    Password = register.Password
                };

                _context.Login.Add(loginCred);

              var result = await _context.SaveChangesAsync()>0;

                if (result)
                    return true;

                throw new RestException(HttpStatusCode.InternalServerError,"Not Inserted.");
            }
            throw new RestException(HttpStatusCode.Found, "Already Exist!");
        }

       public async Task<List<Register>> RegisteredUser()
        {
            var userList = await _context.Register.ToListAsync();
            return userList;
        }
    }
}
