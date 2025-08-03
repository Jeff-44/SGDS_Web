using ApplicationCore.Entities.Collectes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces.IServices
{
    public interface ICollecteService : IGenericService<Collecte>
    {
        Task<Collecte?> GetCollecteByIdAsync(long id);
        Task<IEnumerable<Collecte>?> GetAllCollectesAsync();
    }
}
