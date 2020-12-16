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

        EventHeader GetEvent(Guid id, Guid eventId);
        EventHeader AddEvent(Guid id, EventHeader userEvent);
        void UpdateEvent(Guid id, EventHeader userEvent);
        void DeleteEvent(Guid id, Guid eventId);

        LocationHeader GetLocation(Guid id, Guid locationId);
        LocationHeader AddLocation(Guid id, LocationHeader locationEvent);
        void UpdateLocation(Guid id, LocationHeader locationEvent);
        void DeleteLocation(Guid id, Guid locationId);
    }
}
