using ApplicationCore.Entities.Collectes;
using AutoMapper;
using SGDS_Web.ViewModels;

namespace SGDS_Web.Mappings
{
    public class DonneurVMMappingProfile : Profile
    {
        public DonneurVMMappingProfile()
        {
            CreateMap<DonneurVM, Donneur>().ReverseMap();
        }
    }
}
