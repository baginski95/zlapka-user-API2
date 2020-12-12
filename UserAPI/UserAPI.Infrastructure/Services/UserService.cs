using AutoMapper;
using System;
using System.Collections.Generic;
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
        public UserDto Get(int id)
        {
            var user = _userRepository.Get(id);

            return _mapper.Map<UserDto>(user);
        }

        public User Add(UserDto user)
        {
            throw new NotImplementedException();
        }
        public void Update(UserDto user)
        {
            throw new NotImplementedException();
        }

        public void Delete(UserDto user)
        {
            throw new NotImplementedException();
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
