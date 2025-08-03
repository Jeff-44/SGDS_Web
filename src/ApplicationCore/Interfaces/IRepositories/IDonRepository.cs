using ApplicationCore.Entities.Collectes;
using ApplicationCore.Entities.Location;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces.IRepositories
{
    public interface IDonRepository : IGenericRepository<Don>
    {
        Task<IEnumerable<Don>?> GetAllDonsAsync();
        Task<Don?> GetDonByIdAsync(long id);
    }
}
