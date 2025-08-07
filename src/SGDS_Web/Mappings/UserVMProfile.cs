using ApplicationCore.Entities;
using AutoMapper;
using SGDS_Web.ViewModels.Users;

namespace SGDS_Web.Mappings
{
    public class UserVMProfile : Profile
    {
        public UserVMProfile()
        {
            CreateMap<UserVM, DomainUser>().ReverseMap();
        }
    }
}
