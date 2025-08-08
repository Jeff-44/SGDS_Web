using ApplicationCore.Entities.Statistics;

namespace SGDS_Web.ViewModels.Statistics
{
    public class DashboardVM
    {
        public GlobalStatistics GlobalStatistics { get; set; } = new GlobalStatistics();
        //public List<MonthlyDistribution> MonthlyDistributions { get; set; }
        public IEnumerable<RepartitionMensuelle> MonthlyDistributions { get; set; } = Enumerable.Empty<RepartitionMensuelle>();
    }
}
