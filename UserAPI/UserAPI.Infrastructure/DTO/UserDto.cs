using System;
using System.Collections.Generic;
using System.Text;

namespace UserAPI.Infrastructure.DTO
{
    public class UserDto
    {
        public string Id { get; set; }
        public string Score { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Role { get; set; }
       // public IEnumerable<EventHeaderDto> UserEvents { get; set; }


    }
}
