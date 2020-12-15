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
    [Route("UserAPI/[controller]")]
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

        [HttpGet("id/info")]
        public IActionResult GetAllUserInfo(Guid id)
        {
            var user = _userService.GetAllInfo(id);
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
            return Created($"UserAPI/users/{newId}", user);
        }

        [HttpPut("id")]
        public IActionResult UpdateUser(Guid id, [FromBody] UserDtoUpdate user)
        {
            var userCheck = _userService.Get(id);
            if (userCheck == null)
            {
                return NotFound();
            }

            _userService.Update(id, user.Email, user.PhotoDir, user.Description);
            return NoContent();
        }

        [HttpDelete("id")]
        public IActionResult DeleteUser(Guid id)
        {
            var userCheck = _userService.Get(id);
            if (userCheck == null)
            {
                return NotFound();
            }
            _userService.Delete(id);
            return NoContent();
        }

        [HttpPost("id/events/add")]
        public IActionResult AddEvent(Guid id, [FromBody] EventHeaderDto userEvent)
        {
            var userCheck = _userService.Get(id);
            if (userCheck == null)
            {
                return NotFound();
            }
            _userService.AddEvent(id, Guid.Parse(userEvent.Id), userEvent.Name);
            return Ok(userEvent);
        }

        [HttpPut("id/events/update")]
        public IActionResult UpdateEvent(Guid id, [FromBody] EventHeaderDto userEvent)
        {
            Guid eventId = Guid.Parse(userEvent.Id);
            var eventCheck = _userService.GetEvent(id, eventId);
            if (eventCheck == null)
            {
                return NotFound();
            }
            _userService.UpdateEvent(id, eventId, userEvent.Name);
            return Ok();
        }

        [HttpDelete("id/events/delete")]
        public IActionResult DeleteEvent(Guid id, [FromBody] EventHeaderDto userEvent)
        {
            Guid eventId = Guid.Parse(userEvent.Id);
            var eventCheck = _userService.GetEvent(id, eventId);
            if (eventCheck == null)
            {
                return NotFound();
            }
            _userService.DeleteEvent(id, eventId);
            return Ok();
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
