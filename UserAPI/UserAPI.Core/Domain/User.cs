using System;
using System.Collections.Generic;
using System.Text;

namespace UserAPI.Core.Domain
{
    class User
    {
        public int Id { get; protected set; }
        public int PhoneNumber { get; protected set; } // for a while be a string 
        public int Score { get; protected set; }
        public DateTime DateOfBirth { get; protected set; }
        public string UserName { get; protected set; }
        public string FirstName { get; protected set; }
        public string SecondName { get; protected set; }
        public string Description { get; protected set; }
        public string Email { get; protected set; }
        public string PhotoDir { get; protected set; }
        public string Role { get; protected set; }
        public IEnumerable<EventHeader> UserEvents { get; set; }

        //public IEnumerable<Preference> Preferences{ get; set;} 
    }
}
