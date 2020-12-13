using System;
using System.Collections.Generic;
using System.Text;
using UserAPI.Core.Domain;
using UserAPI.Infrastructure.DTO;

namespace UserAPI.Infrastructure.Services
{
    public interface IUserService
    {
        UserDto Get(Guid id);
        UserDtoCreate Create(Guid id, string phoneNumber, string dateOfBirth, string userName,
                        string firstName, string secondName, string email);
        void Update(Guid id, string email, string photoDir, string description);
        void Delete(Guid id);
        IEnumerable<UserDto> GetEventUsers(int eventId);
        IEnumerable<EventHeader> GetUserEvents(UserDto user);
    }
}
