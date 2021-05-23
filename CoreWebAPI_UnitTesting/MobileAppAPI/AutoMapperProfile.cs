using AutoMapper;
using MobileAppAPI.Models;
using MobileAppAPI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobileAppAPI
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Employee, ListEmployee>();
            CreateMap<Employee, CreateEmployee>().ReverseMap();
        }
    }
}
