using ApplicationCore.Entities.Collectes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces.IServices
{
    public interface IDonService : IGenericService<Don>
    {
        Task<IEnumerable<Don>?> GetAllDonsAsync();
        Task<Don?> GetDonByIdAsync(long id);
    }
}
