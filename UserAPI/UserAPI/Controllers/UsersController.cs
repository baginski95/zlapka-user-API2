using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using UserAPI.Infrastructure.DTO;
using UserAPI.Infrastructure.Services;

namespace UserAPI.Controllers
{
    [Route("userApi/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IHttpClientFactory _httpClientFactory;
        public UsersController(IUserService userService ,IHttpClientFactory httpClientFactory)
        {
            _userService = userService;
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet("userId")]
        public IActionResult GetUser(Guid userId)
        {
            var user = _userService.Get(userId);
            if(user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpGet("userId/info")]
        public IActionResult GetAllUserInfo(Guid userId)
        {
            var user = _userService.GetAllInfo(userId);
            if (user == null)
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
            return Created($"userAPI/users/{newId}", user);
        }

        [HttpPut("userId")]
        public IActionResult UpdateUser(Guid userId, [FromBody] UserDtoUpdate user)
        {
            var userCheck = _userService.Get(userId);
            if (userCheck == null)
            {
                return NotFound();
            }

            _userService.Update(userId, user.Email, user.PhotoDir, user.Description);
            return NoContent();
        }

        [HttpDelete("userId")]
        public IActionResult DeleteUser(Guid userId)
        {
            var userCheck = _userService.Get(userId);
            if (userCheck == null)
            {
                return NotFound();
            }
            _userService.Delete(userId);
            return NoContent();
        }

        [HttpPost("userId/events/add")]
        public IActionResult AddEvent(Guid userId, [FromBody] EventHeaderDto userEvent)
        {
            var userCheck = _userService.Get(userId);
            if (userCheck == null)
            {
                return NotFound();
            }
            _userService.AddEvent(userId, Guid.Parse(userEvent.Id), userEvent.Name);
            return Ok(userEvent);
        }

        [HttpPut("userId/events/update")]
        public IActionResult UpdateEvent(Guid userId, [FromBody] EventHeaderDto userEvent)
        {
            if (Guid.TryParse(userEvent.Id, out var eventId))
            {
                var eventCheck = _userService.GetEvent(userId, eventId);
                if (eventCheck == null)
                {
                    return NotFound();
                }
                _userService.UpdateEvent(userId, eventId, userEvent.Name);
                return Ok();
            }
            return NotFound();
        }

        [HttpDelete("userId/events/delete")]
        public IActionResult DeleteEvent(Guid userId, [FromBody] EventHeaderDto userEvent)
        {
            if( Guid.TryParse(userEvent.Id, out var eventId))
            {
                var eventCheck = _userService.GetEvent(userId, eventId);
                if (eventCheck == null)
                {
                    return NotFound();
                }
                _userService.DeleteEvent(userId, eventId);
                return Ok();
            }
            return NotFound();
        }









        [HttpPost("userId/locations/add")]
        public IActionResult AddLocation(Guid userId, [FromBody] LocationHeaderDto userLocation)
        {
            var userCheck = _userService.Get(userId);
            if (userCheck == null)
            {
                return NotFound();
            }
            _userService.AddLocation(userId, Guid.Parse(userLocation.Id), userLocation.Name);
            return Ok(userLocation);
        }

        [HttpPut("userId/locations/update")]
        public IActionResult UpdateLocation(Guid userId, [FromBody] LocationHeaderDto userLocation)
        {
            if (Guid.TryParse(userLocation.Id, out var locationId))
            {
                var eventCheck = _userService.GetLocation(userId, locationId);
                if (eventCheck == null)
                {
                    return NotFound();
                }
                _userService.UpdateLocation(userId, locationId, userLocation.Name);
                return Ok();
            }
            return NotFound();
        }

        [HttpDelete("userId/locations/delete")]
        public IActionResult DeleteLocation(Guid userId, [FromBody] LocationHeaderDto userLocation)
        {
            if (Guid.TryParse(userLocation.Id, out var locationId))
            {
                var eventCheck = _userService.GetLocation(userId, locationId);
                if (eventCheck == null)
                {
                    return NotFound();
                }
                _userService.DeleteLocation(userId, locationId);
                return Ok();
            }
            return NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var request = new HttpRequestMessage(HttpMethod.Get,
            "https://dog.ceo/api/breeds/image/random");
            request.Headers.Add("Accept", "application/json");


            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                var data = await JsonSerializer.DeserializeAsync<Test>(responseStream);
                return Ok(data);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
