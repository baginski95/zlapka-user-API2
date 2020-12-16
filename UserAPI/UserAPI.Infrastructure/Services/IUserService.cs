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
        User GetAllInfo(Guid id);
        UserDtoCreate Create(Guid id, string phoneNumber, string dateOfBirth, string userName,
                        string firstName, string secondName, string email);
        void Update(Guid id, string email, string photoDir, string description);
        void Delete(Guid id);

        EventHeaderDto GetEvent(Guid id, Guid eventId);
        EventHeaderDto AddEvent(Guid id, Guid eventId, string name);
        void UpdateEvent(Guid id,Guid eventId, string name);
        void DeleteEvent(Guid id, Guid eventId);

        LocationHeaderDto GetLocation(Guid id, Guid locationId);
        LocationHeaderDto AddLocation(Guid id, Guid locationId, string name);
        void UpdateLocation(Guid id, Guid locationId, string name);
        void DeleteLocation(Guid id, Guid locationId);
    }
}
