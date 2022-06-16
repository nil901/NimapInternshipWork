using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;
using Repo.Service;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RoleBase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet]
        [Produces(typeof(IEnumerable<User>))]
        public async Task<IActionResult> getUserList()
        {
            IEnumerable<User> user = await _userService.GetAllUser();
            return Ok(user);
        }
        [AllowAnonymous]
        [HttpPost]

        [Produces(typeof(User))]
        public IActionResult AddUser(User Users)
        {
            return Ok(_userService.AddUser(Users));
        }


        [HttpPut]
        [Route("{id}")]
        [Produces(typeof(User))]
        public async Task<IActionResult> UpdateUser(User users)
        {
            return Ok(await _userService.UpdateUser(users));
        }

        [HttpDelete]
        [Route("{id}")]
        [Produces(typeof(bool))]
        public async Task<bool> DeleteUser(int id)
        {
            return await _userService.DeleteUser(id);
        }
    }
}
