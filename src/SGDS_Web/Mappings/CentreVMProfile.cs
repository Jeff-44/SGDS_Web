using ApplicationCore.Entities.Location;
using AutoMapper;
using SGDS_Web.ViewModels;

namespace SGDS_Web.Mappings
{
    public class CentreVMProfile : Profile
    {
        public CentreVMProfile()
        {
            CreateMap<Centre, CentreVM>().ReverseMap();
        }
    }
}
