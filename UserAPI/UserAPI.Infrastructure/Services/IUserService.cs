using System;
using System.Collections.Generic;
using System.Text;
using UserAPI.Core.Domain;
using UserAPI.Infrastructure.DTO;

namespace UserAPI.Infrastructure.Services
{
    interface IUserService
    {
        UserDto Get(int id);
        User Add(UserDto user);
        void Update(UserDto user);
        void Delete(UserDto user);
        IEnumerable<UserDto> GetEventUsers(int eventId);
        IEnumerable<EventHeader> GetUserEvents(UserDto user);
    }
}
