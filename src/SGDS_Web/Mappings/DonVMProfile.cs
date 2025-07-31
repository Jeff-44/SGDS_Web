using ApplicationCore.Entities.Collectes;
using ApplicationCore.Entities.Location;
using AutoMapper;
using SGDS_Web.ViewModels;

namespace SGDS_Web.Mappings
{
    public class DonVMProfile : Profile
    {
        public DonVMProfile()
        {
            CreateMap<Don, DonVM>().ReverseMap();
        }
    }
}
