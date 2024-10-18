using Infrastructure.Common;
using Infrastructure.IServices.IAuthService;

using Microsoft.EntityFrameworkCore;

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
    public class RoleService : IRoleService
    {
        private readonly ERPContext _context;

        public RoleService(ERPContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateRole(Role role)
        {
            try
            {
                if (role.Id == 0)
                {
                    bool roleExist = await _context.Roles.AnyAsync(r => r.RoleName == role.RoleName);

                    if (!roleExist)
                    {
                        _context.Roles.Add(role);
                    }
                    else
                    {
                        throw new RestException(HttpStatusCode.Found, "already exists!");
                    }
                    
                }
                else
                {
                    _context.Update<Role>(role);
                }
                var msg = await _context.SaveChangesAsync() > 0;
                return msg;
            }
            catch (Exception e)
            {
                throw new RestException(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        public async Task<List<Role>> RoleList()
        {
            var roles = await _context.Roles.ToListAsync();

            return roles;
        }
    }
}
