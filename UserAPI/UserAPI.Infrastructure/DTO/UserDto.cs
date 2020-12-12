using System;
using System.Collections.Generic;
using System.Text;

namespace UserAPI.Infrastructure.DTO
{
    public class UserDto
    {
        public int Id { get; protected set; }
        public int Score { get; protected set; }
        public string UserName { get; protected set; }
        public string FirstName { get; protected set; }
        public string SecondName { get; protected set; }
        public string Role { get; protected set; }
        public UserDto(int id, string username, string firstName,
                    string secondName)
        {
            Id = id;
            UserName = SetData(username);
            FirstName = SetData(firstName);
            SecondName = SetData(secondName);
            Role = "Regular";
        }
        public string SetData(string dataToCheck)
        {
            if (string.IsNullOrWhiteSpace(dataToCheck))
            {
                throw new Exception($"User with id {Id} doesn't set needed values to exist in our world");
            }

            return dataToCheck;
        }

    }
}
