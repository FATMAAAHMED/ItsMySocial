using AutoMapper;
using ItsMySocialDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Dtos
{
    public class MyAutoMapper:Profile
    {
        public MyAutoMapper()
        {
            CreateMap<User, RegisterDto>();
            CreateMap<RegisterDto, User>();
            CreateMap<User, LoginDto>();
            CreateMap<LoginDto, User>();

        }
    }
}
