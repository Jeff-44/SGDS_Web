using ApplicationCore.Entities.Location;
using AutoMapper;
using SGDS_Web.ViewModels.Centres;

namespace SGDS_Web.Mappings
{
    public class CentreVMProfile : Profile
    {
        public CentreVMProfile()
        {
            CreateMap<CentreVM, Centre>().ReverseMap();
        }
    }
}
