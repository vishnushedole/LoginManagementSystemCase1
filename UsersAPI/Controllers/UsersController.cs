using LoginManagement.Entities;
using LoginManagement.Process;
using Microsoft.AspNetCore.Mvc;
using ProductsService.Infrastructure;

namespace UsersAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [CustomeAuthorization]
    public class UsersController : ControllerBase
    {
        private readonly Userprocess _process;
        public UsersController(Userprocess process)
        {
            _process = process;
        }

        [HttpGet("list")]
        public IActionResult List()
        {
            Console.WriteLine("hi");
            var models = _process.GetAllUsers();
            return Ok(models);
        }

        [HttpGet("details")]
        public IActionResult Details(int id)
        {
            var model = _process.GetUserById(id);
            return Ok(model);
        }

        [HttpPost("create")]
        public IActionResult Create(User user)
        {
            Console.WriteLine("Create called");
            _process.AddUser(user.UserName, user.FirstName,user.LastName,user.Password);
            return Ok();
        }

        [HttpPut("update")]
        public IActionResult Update(User user) 
        {
            _process.UpdateUser(user.UserId,user.UserName,user.FirstName,user.LastName,user.Password);
            return Ok();
        }

        [HttpDelete("delete")]
        public IActionResult Delete(int id)
        {
            _process.RemoveUser(id);
            return Ok();
        }

        [HttpPost("mapusertorole")]
        public IActionResult MapUserToRoles(UserRole ur)
        {
            _process.UpdateRole(ur.UserId, ur.RoleId);
            return Ok();
        }

    }
}
