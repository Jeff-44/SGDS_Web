using ApplicationCore.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Mappings
{
    public class DomainRoleProfile : Profile
    {
        public DomainRoleProfile()
        {
            CreateMap<DomainRole, IdentityRole>().ReverseMap();
        }
    }
}
