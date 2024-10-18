using Models;
using Models.Auth;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.IServices.IAuthService
{
   public interface ILoginService
    {
        Task<User> SignIn(Login Login);
        Task SignOut();
    }
}
