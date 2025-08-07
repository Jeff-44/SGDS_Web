using ApplicationCore.Entities;
using AutoMapper;
using SGDS_Web.ViewModels.Users;

namespace SGDS_Web.Mappings
{
    public class CreerModifierRoleProfile : Profile
    {
        public CreerModifierRoleProfile()
        {
            CreateMap<CreerModifierRole, DomainRole>().ReverseMap();
        }
    }
}
