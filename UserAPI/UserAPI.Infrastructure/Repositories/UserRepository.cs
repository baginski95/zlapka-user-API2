using System;
using System.Collections.Generic;
using System.Text;
using UserAPI.Core.Domain;
using UserAPI.Core.Repositories;

namespace UserAPI.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private static readonly ISet<User> _users = new HashSet<User>()
        {
                new User( 0, 567834123, DateTime.Now, "Bagiczny", "Filip",
                            "Bagins", "bag@gmail.com"),
                new User( 1, 163434153, DateTime.Now, "Magiczny", "Szymon",
                            "Tarnacki", "Tar.S@gmail.com"),
                new User( 2, 768453289, DateTime.Now, "Sportowo", "Halina",
                            "Korzeniowski", "Korzen@gmail.com"),
                new User( 3, 586319083, DateTime.Now, "Przyjaciel12", "Michal",
                            "Mitur", "tiruriru@gmail.com"),
                new User( 4, 500869200, DateTime.Now, "FilipWAWA", "Filip",
                            "Wadecki", "kolanko123@gmail.com"),
                new User( 5, 305281934, DateTime.Now, "Wypieki", "Aga",
                            "Kazimierczak", "Kazik29@gmail.com"),
                new User( 6, 395231174, DateTime.Now, "Sylsia", "Sylwia",
                            "Szymczak", "syl.Ka@gmail.com"),
                new User( 7, 985217567, DateTime.Now, "Kolega12", "Piotr",
                            "Kowalczyk", "piotr.K@gmail.com"),
        };
        public User Get(int id)
        {
            throw new NotImplementedException();
        }
        public User Add(User user)
        {
            throw new NotImplementedException();
        }
        public void Update(User user)
        {
            throw new NotImplementedException();
        }

        public void Delete(User user)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetEventUsers(int eventId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<EventHeader> GetUserEvents(User user)
        {
            throw new NotImplementedException();
        }

    }
}
