using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UserAPI.Core.Domain;
using UserAPI.Core.Repositories;
using UserAPI.Infrastructure.DTO;

namespace UserAPI.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public UserDto Get(Guid id)
        {
            var user = _userRepository.Get(id);

            return _mapper.Map<UserDto>(user);
        }
        public User GetAllInfo(Guid id)
        {
            var user = _userRepository.Get(id);
            return user;
        }

        public UserDtoCreate Create(Guid id, string phoneNumber, string dateOfBirth, string userName,
                                string firstName,string secondName, string email)
        {
            var compare = _userRepository.GetAll().FirstOrDefault(c => c.UserName == userName ||
                                                 c.PhoneNumber == int.Parse(phoneNumber) ||
                                                 c.Email == email);
            if (compare != null)
            {
                throw new NotImplementedException();
            }

           var convertedPhoneNumber = int.Parse(phoneNumber);
           var mappedDate = dateOfBirth + "12:00:00 AM";
           var convertedDateOfBirth = DateTime.Parse(dateOfBirth);
           User user = new User(id, convertedPhoneNumber,convertedDateOfBirth,
                                userName,firstName, secondName, email);

            _userRepository.Create(user);
            return _mapper.Map<UserDtoCreate>(user);
        }
        public void Update(Guid id, string email, string photoDir, string description)
        {
            var user = _userRepository.Get(id);
            user.PhotoDir = photoDir;
            user.Email = email;
            user.Description = description;
            _userRepository.Update(user);
        }

        public void Delete(Guid id)
        {
            var user = _userRepository.Get(id);
            _userRepository.Delete(user);
        }
        public EventHeaderDto GetEvent(Guid id, Guid eventId)
        {
            var userEvent = _userRepository.GetEvent(id, eventId);
            return _mapper.Map<EventHeaderDto>(userEvent);
        }
        public EventHeaderDto AddEvent(Guid id,Guid eventId, string name = "defaultName")
        {

            var userEvent = new EventHeader(eventId, name);
            _userRepository.AddEvent(id, userEvent);

            return _mapper.Map<EventHeaderDto>(userEvent);
        }

        public void UpdateEvent(Guid id, Guid eventId, string name = "defaultName")
        {
             var userEvent = _userRepository.GetEvent(id, eventId);
             userEvent.Name = name;
            _userRepository.UpdateEvent(id, userEvent);
        }

        public void DeleteEvent(Guid id, Guid eventId)
        {
            _userRepository.DeleteEvent(id, eventId);
        }

        public LocationHeaderDto GetLocation(Guid id, Guid locationId)
        {
            var userLocation = _userRepository.GetLocation(id, locationId);
            return _mapper.Map<LocationHeaderDto>(userLocation);
        }
        public LocationHeaderDto AddLocation(Guid id, Guid locationId, string name = "defaultName")
        {

            var userLocation = new LocationHeader(locationId, name);
            _userRepository.AddLocation(id, userLocation);

            return _mapper.Map<LocationHeaderDto>(userLocation);
        }

        public void UpdateLocation(Guid id, Guid locationId, string name = "defaultName")
        {
            var userLocation = _userRepository.GetLocation(id, locationId);
            userLocation.Name = name;
            _userRepository.UpdateLocation(id, userLocation);
        }


        public void DeleteLocation(Guid id, Guid locationId)
        {
            _userRepository.DeleteLocation(id, locationId);
        }
    }
}
