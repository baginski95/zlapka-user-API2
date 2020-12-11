using System;
using System.Collections.Generic;
using System.Text;
using UserAPI.Core.Domain;

namespace UserAPI.Core.Repositories
{
    public interface IUserRepository
    {
        User Get(int id);
        User Add(User user);
        void Update(User user);
        void Delete(User user);
        IEnumerable<User> GetEventUsers(int eventId);
        IEnumerable<EventHeader> GetUserEvents(User user);



    }
}
