using ApplicationCore.Entities.Statistics;
using AutoMapper;
using SGDS_Web.ViewModels.Statistics;

namespace SGDS_Web.Mappings
{
    public class DashboardVMProfile : Profile
    {
        public DashboardVMProfile()
        {
            CreateMap<DashboardVM, GlobalStatistics>().ReverseMap();
        }
    }
}
