using ApplicationCore.Entities.Location;
using AutoMapper;
using SGDS_Web.ViewModels.Centres;

namespace SGDS_Web.Mappings
{
    public class CreerModifierCentreProfile : Profile
    {
        public CreerModifierCentreProfile()
        { 
            CreateMap<CreerModifierCentre, Centre>().ReverseMap();
        }
    }
}
