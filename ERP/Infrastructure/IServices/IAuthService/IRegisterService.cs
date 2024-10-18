using Models.Auth;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.IServices.IAuthService
{
   public interface IRegisterService
    {
        Task<bool> Register(Register register);
        Task<List<Register>> RegisteredUser();
    }
}
