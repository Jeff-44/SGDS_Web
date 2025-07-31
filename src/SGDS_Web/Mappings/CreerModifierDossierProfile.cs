using ApplicationCore.Entities.Collectes;
using AutoMapper;
using SGDS_Web.ViewModels.Dossiers;

namespace SGDS_Web.Mappings
{
    public class CreerModifierDossierProfile : Profile
    {
        public CreerModifierDossierProfile() 
        {
            CreateMap<CreerModifierDossier, Dossier>().ReverseMap();
        }
    }
}
