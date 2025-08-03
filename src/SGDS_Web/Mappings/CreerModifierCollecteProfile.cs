using ApplicationCore.Entities.Collectes;
using AutoMapper;
using SGDS_Web.ViewModels.Collectes;

namespace SGDS_Web.Mappings
{
    public class CreerModifierCollecteProfile : Profile
    {
        public CreerModifierCollecteProfile()
        {
            CreateMap<CreerModifierCollecte, Collecte>().ReverseMap();
        }
    }
}
