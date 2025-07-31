using ApplicationCore.Entities.Collectes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces.IServices
{
    public interface IDossierService : IGenericService<Dossier>
    {
        Task<Dossier?> GetDossierByIdAsync(long id);
        Task<IEnumerable<Dossier>?> GetAllDossiersAsync();
    }
}
