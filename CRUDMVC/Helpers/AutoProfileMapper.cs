using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CRUDMVC.DTOs;
using CRUDMVC.Models;

namespace CRUDMVC.Helpers
{
    public class AutoProfileMapper : Profile
    {
        public AutoProfileMapper()
        {
            CreateMap<AddUserDTO, AppUser>();
            CreateMap<AppUser, UpdateUserDTO>().ReverseMap();

            CreateMap<AddCompanyDTO, Company>();
            CreateMap<Company, UpdateCompanyDTO>().ReverseMap();
        }
    }
}