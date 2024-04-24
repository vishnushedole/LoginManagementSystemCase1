using LoginManagement.Entities;
using LoginManagement.Process;
using Microsoft.AspNetCore.Mvc;
using ProductsService.Infrastructure;


namespace RoleAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [CustomeAuthorization]
    public class RolesController : ControllerBase
    {
        private readonly RoleProcess _roleprocess;
        public RolesController(RoleProcess roleprocess) 
        {
            _roleprocess = roleprocess;
        }

        [HttpGet("list")]
        public List<Role> List()
        {
            var models = _roleprocess.GetAllRoles();
            return models;
        }

        [HttpGet("details")]
        public IActionResult Details(int id)
        {
            var model = _roleprocess.GetRoleById(id);
            return Ok(model);
        }

        [HttpPost("create")]
        public IActionResult Create(Role role)
        {
            Console.WriteLine("Create called");
            _roleprocess.AddRole(role.RoleName,role.Description);
            return Ok();
        }

        [HttpPut("update")]
        public IActionResult Update(Role role)
        {
            _roleprocess.UpdateRole(role.RoleId,role.RoleName,role.Description);
            return Ok();
        }

        [HttpDelete("delete")]
        public IActionResult Delete(int id)
        {
            _roleprocess.RemoveRole(id);
            return Ok();
        }

    }
}
