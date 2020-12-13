using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserAPI.Infrastructure.Services;

namespace UserAPI.Controllers
{
    [Route("UserApi/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet("id")]
        public IActionResult Get(int id)
        {
            var user = _userService.Get(id);
            if(user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }
    }
}
