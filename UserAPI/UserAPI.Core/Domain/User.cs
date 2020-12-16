using System;
using System.Collections.Generic;

namespace UserAPI.Core.Domain
{
    public class User : Entity
    {
        public int PhoneNumber { get; protected set; } 
        public int Score { get; protected set; }
        public DateTime DateOfBirth { get; protected set; }
        public string UserName { get; protected set; }
        public string FirstName { get; protected set; }
        public string SecondName { get; protected set; }
        public string Description { get; set; }
        public string Email { get; set; }
        public string PhotoDir { get; set; }
        public string Role { get; protected set; }
        public List<EventHeader> UserEvents { get; set; }
        public List<LocationHeader> UserLocations { get; set; }

        //public IEnumerable<Preference> Preferences{ get; set;} 

        public User()
        {

        }

        public User(Guid id, int phoneNumber, DateTime dateOfBirth, string username, string firstName,
                    string secondName, string email)
        {
            Id = id;
            Score = 0;
            PhoneNumber = phoneNumber;
            DateOfBirth = dateOfBirth;
            UserName = SetData(username);
            FirstName = SetData(firstName);
            SecondName = SetData(secondName);
            Email = SetData(email);
            UserEvents = new List<EventHeader>();
            UserLocations = new List<LocationHeader>();
            Role = "Regular";
            PhotoDir = "";
            Description = "";
        }

        public string SetData(string dataToCheck)
        {
            if(string.IsNullOrWhiteSpace(dataToCheck))
            {
                throw new Exception($"User with id {Id} doesn't set needed values to exist in our world");
            }

            return dataToCheck;
        }
    }
}
