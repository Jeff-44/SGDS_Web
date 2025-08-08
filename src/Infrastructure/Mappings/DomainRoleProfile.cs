using ApplicationCore.Entities.Users;
using AutoMapper;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Mappings
{
    public class DomainRoleProfile : Profile
    {
        public DomainRoleProfile()
        {
            CreateMap<DomainRole, IdentityRole>()
                .ForAllMembers(options => options.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<IdentityRole, DomainRole>();
        }
    }
}
