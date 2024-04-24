using Frontend.Infrastructure;
using LoginManagement.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Frontend.Controllers
{
    public class RoleController : Controller
    {
     
        private readonly IRoleService _roleService;

        public RoleController(
            IRoleService service
        )
        {
            _roleService = service;
        }
        public async Task<IActionResult> List()
        {
            var models = await _roleService.GetRoles();
           
            return View(models);
        }
    }
}
