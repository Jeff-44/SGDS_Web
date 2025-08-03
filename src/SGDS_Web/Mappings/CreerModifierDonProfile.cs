using ApplicationCore.Entities.Collectes;
using AutoMapper;
using SGDS_Web.ViewModels.Dons;

namespace SGDS_Web.Mappings
{
    public class CreerModifierDonProfile : Profile
    {
        public CreerModifierDonProfile()
        {
            CreateMap<CreerModifierDon, Don>().ReverseMap();
        }
    }
}
