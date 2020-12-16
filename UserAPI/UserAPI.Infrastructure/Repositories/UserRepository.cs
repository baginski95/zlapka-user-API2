using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UserAPI.Core.Domain;
using UserAPI.Core.Repositories;

namespace UserAPI.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private static readonly ISet<User> _users = new HashSet<User>()
        {
                new User( new Guid("3d280c89-0825-4196-b11a-d13131ce107f"), 567834123, DateTime.Now, "Bagiczny", "Filip",
                            "Bagins", "bag@gmail.com"),
                new User( Guid.NewGuid(), 163434153, DateTime.Now, "Magiczny", "Szymon",
                            "Tarnacki", "Tar.S@gmail.com"),
                new User( Guid.NewGuid(), 768453289, DateTime.Now, "Sportowo", "Halina",
                            "Korzeniowski", "Korzen@gmail.com"),
                new User( Guid.NewGuid(), 586319083, DateTime.Now, "Przyjaciel12", "Michal",
                            "Mitur", "tiruriru@gmail.com"),
                new User( Guid.NewGuid(), 500869200, DateTime.Now, "FilipWAWA", "Filip",
                            "Wadecki", "kolanko123@gmail.com"),
                new User( Guid.NewGuid(), 305281934, DateTime.Now, "Wypieki", "Aga",
                            "Kazimierczak", "Kazik29@gmail.com"),
                new User( Guid.NewGuid(), 395231174, DateTime.Now, "Sylsia", "Sylwia",
                            "Szymczak", "syl.Ka@gmail.com"),
                new User( Guid.NewGuid(), 985217567, DateTime.Now, "Kolega12", "Piotr",
                            "Kowalczyk", "piotr.K@gmail.com"),
        };
        public User Get(Guid id)
        {
            return _users.SingleOrDefault(x => x.Id == id);
        }
        public IEnumerable<User> GetAll()
        {
            return _users;
        }
        public User Create(User user)
        {
            _users.Add(user);
            return user;
        }
        public void Update(User user)
        {
           
        }
        public void Delete(User user)
        {
            _users.Remove(user);

        }
        public EventHeader GetEvent(Guid id, Guid eventId)
        {
            var user = _users.SingleOrDefault(x => x.Id == id);
            return user.UserEvents.SingleOrDefault(x => x.Id == eventId);
        }
        public EventHeader AddEvent(Guid id, EventHeader userEvent)
        {
            var user = _users.SingleOrDefault(x => x.Id == id);
            user.UserEvents.Add(userEvent);
            return userEvent;
        }

        public void UpdateEvent(Guid id, EventHeader userEvent)
        {
 
        }

        public void DeleteEvent(Guid id, Guid eventId)
        {
            var user = _users.SingleOrDefault(x => x.Id == id);
            var eventInRepo = user.UserEvents.SingleOrDefault(x => x.Id == eventId);
            if (eventInRepo != null) user.UserEvents.Remove(eventInRepo);
        }
        public LocationHeader GetLocation(Guid id, Guid EventId)
        {
            var user = _users.SingleOrDefault(x => x.Id == id);
            return user.UserLocations.SingleOrDefault(x => x.Id == EventId);
        }
        public LocationHeader AddLocation(Guid id, LocationHeader userLocation)
        {
            var user = _users.SingleOrDefault(x => x.Id == id);
            user.UserLocations.Add(userLocation);
            return userLocation;
        }

        public void UpdateLocation(Guid id, LocationHeader userLocation)
        {

        }

        public void DeleteLocation(Guid id, Guid locationId)
        {
            var user = _users.SingleOrDefault(x => x.Id == id);
            var locationInRepo = user.UserLocations.SingleOrDefault(x => x.Id == locationId);
            if (locationInRepo != null) user.UserLocations.Remove(locationInRepo);
        }
    }
}
