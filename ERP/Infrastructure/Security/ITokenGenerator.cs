using Models;
using Models.Auth;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Security
{
  public interface ITokenGenerator
    {
        string CreateToken(User user);
    }
}
