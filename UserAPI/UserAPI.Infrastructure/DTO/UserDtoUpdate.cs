using System;
using System.Collections.Generic;
using System.Text;

namespace UserAPI.Infrastructure.DTO
{
    public class UserDtoUpdate
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
        public string PhotoDir { get; set; }
        public string Role { get; protected set; }
    }
}
