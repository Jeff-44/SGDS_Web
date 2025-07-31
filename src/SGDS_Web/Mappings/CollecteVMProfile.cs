using ApplicationCore.Entities.Collectes;
using AutoMapper;
using SGDS_Web.ViewModels;

namespace SGDS_Web.Mappings
{
    public class CollecteVMProfile : Profile
    {
        public CollecteVMProfile()
        {
            CreateMap<Collecte, CollecteVM>().ReverseMap();
        }
    }
}
