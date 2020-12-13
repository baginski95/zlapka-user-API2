using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using UserAPI.Core.Domain;
using UserAPI.Infrastructure.DTO;

namespace UserAPI.Infrastructure.Mappers
{
   public static class AutoMapperConfig
    {
        public static IMapper Initialize()
            => new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User, UserDto>();
                cfg.CreateMap<User, UserDtoCreate>();
            }
            ).CreateMapper();
    }
}
