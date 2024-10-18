using Models.Auth;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.IServices.IAuthService
{
    public interface IRoleService
    {
        Task<bool> CreateRole(Role role);
        Task< List<Role> >RoleList();
    }
}
