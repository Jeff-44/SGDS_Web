using ApplicationCore.Entities.Collectes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces.IRepositories
{
    public interface IDonneurRepository : IGenericRepository<Donneur>
    {
        Task<IEnumerable<Donneur>> GetAllDonneursAsync();
        Task<Donneur?> GetDonneurByIdAsync(long donneurId);
    }
}
