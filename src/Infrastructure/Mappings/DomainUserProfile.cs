using ApplicationCore.Entities;
using AutoMapper;
using Infrastructure.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Mappings
{
    public class DomainUserProfile : Profile
    {
        public DomainUserProfile()
        {
            CreateMap<DomainUser, ApplicationUser>()
                .ForAllMembers(options => options.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<ApplicationUser, DomainUser>();
        }
    }
}
