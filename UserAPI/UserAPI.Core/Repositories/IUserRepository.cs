using System;
using System.Collections.Generic;
using System.Text;
using UserAPI.Core.Domain;

namespace UserAPI.Core.Repositories
{
    public interface IUserRepository
    {
        User Get(Guid id);
        IEnumerable<User> GetAll();
        User Create(User user);
        void Update(User user);
        void Delete(User user);
        IEnumerable<User> GetEventUsers(int eventId);
        IEnumerable<EventHeader> GetUserEvents(User user);

    }
}
