using ApplicationCore.Entities.Collectes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces.IServices
{
    public interface IDonneurService : IGenericService<Donneur>
    {
        Task<IEnumerable<Donneur>> GetAllDonneursAsync();
        Task<Donneur?> GetDonneurByIdAsync(long id);
        Task AddDonneurAsync(Donneur donneur);
        Task UpdateDonneurAsync(Donneur donneur);
        Task DeleteDonneurAsync(Donneur donneur);
        Task<bool> DonneurExistsAsync(long id);
        Task<int> CountDonneursAsync();
    }
}
