using ApplicationCore.Entities;
using AutoMapper;
using SGDS_Web.ViewModels.Users;

namespace SGDS_Web.Mappings
{
    public class RoleVMProfile : Profile
    {
        public RoleVMProfile()
        {
            CreateMap<RoleVM, DomainRole>().ReverseMap();
        }
    }
}
