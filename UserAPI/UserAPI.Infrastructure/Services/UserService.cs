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

        public UserDto Create(Guid id, int phoneNumber, DateTime dateOfBirth,string userName,
                                string firstName,string secondName, string email)
        {
            var compare = _userRepository.GetAll().FirstOrDefault(c => c.UserName == userName ||
                                                 c.PhoneNumber == phoneNumber ||
                                                 c.Email == email);
            if (compare == null)
            {
                throw new NotImplementedException();
            }

            User user = new User(id, phoneNumber,dateOfBirth,
                                userName,firstName, secondName, email);

            _userRepository.Create(user);
            return _mapper.Map<UserDto>(user);
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

        public IEnumerable<UserDto> GetEventUsers(int eventId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<EventHeader> GetUserEvents(UserDto user)
        {
            throw new NotImplementedException();
        }

    }
}
