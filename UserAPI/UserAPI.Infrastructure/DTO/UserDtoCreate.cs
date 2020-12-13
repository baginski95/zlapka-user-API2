using System;
using System.Collections.Generic;
using System.Text;

namespace UserAPI.Infrastructure.DTO
{
    public class UserDtoCreate
    {
        public string Id { get; set; }
        public string PhoneNumber { get; set; }
        public string DateOfBirth { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Email { get; set; }
    }
}
