using ApplicationCore.Entities.Users;
using AutoMapper;
using SGDS_Web.ViewModels.Users;

namespace SGDS_Web.Mappings
{
    public class EditUserVMProfile : Profile
    {
        public EditUserVMProfile()
        {
            CreateMap<EditUserVM, DomainUser>().ReverseMap();
        }
    }
}
