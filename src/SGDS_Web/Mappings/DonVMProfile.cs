using ApplicationCore.Entities.Collectes;
using ApplicationCore.Entities.Location;
using AutoMapper;
using SGDS_Web.ViewModels.Dons;

namespace SGDS_Web.Mappings
{
    public class DonVMProfile : Profile
    {
        public DonVMProfile()
        {
            CreateMap<DonVM, Don>().ReverseMap();
        }
    }
}
