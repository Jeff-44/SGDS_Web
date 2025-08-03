using ApplicationCore.Entities.Collectes;
using AutoMapper;
using SGDS_Web.ViewModels.Collectes;

namespace SGDS_Web.Mappings
{
    public class CollecteVMProfile : Profile
    {
        public CollecteVMProfile()
        {
            CreateMap<CollecteVM, Collecte>().ReverseMap();
        }
    }
}
