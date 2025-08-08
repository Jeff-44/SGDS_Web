using ApplicationCore.Entities.Statistics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces.IServices
{
    public interface IStatisticsService
    {
        Task<GlobalStatistics> GetGlobalStatisticsAsync();
        Task<IEnumerable<RepartitionMensuelle>> GetMonthlyStatisticsAsync();
    }
}
