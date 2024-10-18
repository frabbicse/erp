using Infrastructure.IServices.IAuthService;
using Infrastructure.Services.AuthServices;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Models.Auth;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpPost]
        public async Task<ActionResult> CreateRole(Role role)
        {
            await _roleService.CreateRole(role);
            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult<List<Role>>> GetRoles()
        {            
            return await _roleService.RoleList();
        }
    }
}
