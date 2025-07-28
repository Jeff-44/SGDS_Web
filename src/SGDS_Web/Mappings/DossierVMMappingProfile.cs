using ApplicationCore.Entities.Collectes;
using AutoMapper;
using SGDS_Web.ViewModels;

namespace SGDS_Web.Mappings
{
    public class DossierVMMappingProfile : Profile
    {
        public DossierVMMappingProfile() 
        {
            CreateMap<DossierVM, Dossier>().ReverseMap();
        }
    }
}
