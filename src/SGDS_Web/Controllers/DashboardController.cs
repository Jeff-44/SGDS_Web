using ApplicationCore.Interfaces.IServices;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SGDS_Web.ViewModels.Statistics;

namespace SGDS_Web.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IStatisticsService _statisticsService;
        private readonly IMapper _mapper;
        public DashboardController(IStatisticsService statisticsService, IMapper mapper)
        {
            _statisticsService = statisticsService;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var vm = new DashboardVM();
            var stats = await _statisticsService.GetGlobalStatisticsAsync();
            var monthlyStats = await _statisticsService.GetMonthlyStatisticsAsync();
            vm.GlobalStatistics = stats;
            vm.MonthlyDistributions = monthlyStats;
            return View(vm);
        }
    }
}
