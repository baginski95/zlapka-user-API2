using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserAPI.Infrastructure.DTO;
using UserAPI.Infrastructure.Services;

namespace UserAPI.Controllers
{
    [Route("UserAPI/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet("id")]
        public IActionResult GetUser(Guid id)
        {
            var user = _userService.Get(id);
            if(user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpPost]
        public IActionResult CreateUser([FromBody] UserDtoCreate user)
        {
            var newId = Guid.NewGuid();
            user = _userService.Create(newId, user.PhoneNumber, user.DateOfBirth, user.UserName,
                                       user.FirstName, user.SecondName, user.Email);
            return Created($"UserAPI/users/{newId}", user);
        }

        [HttpPut("id")]
        public IActionResult UpdateUser(Guid id, [FromBody] UserDtoUpdate user)
        {
            _userService.Update(id, user.Email, user.PhotoDir, user.Description);
            return NoContent();
        }

        [HttpDelete("id")]
        public IActionResult DeleteUser(Guid id)
        {
            _userService.Delete(id);
            return NoContent();
        }
    }
}
