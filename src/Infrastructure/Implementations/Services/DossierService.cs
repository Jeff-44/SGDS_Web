using ApplicationCore.Entities.Collectes;
using ApplicationCore.Interfaces.IRepositories;
using ApplicationCore.Interfaces.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Implementations.Services
{
    public class DossierService : GenericService<Dossier>, IDossierService
    {
        private readonly IDossierRepository _repository;
        public DossierService(IDossierRepository repository) : base(repository) 
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Dossier>?> GetAllDossiersAsync()
        {
            return await _repository.GetAllDossiersAsync();
        }

        public async Task<Dossier?> GetDossierByIdAsync(long id)
        {
            return await _repository.GetDossierByIdAsync(id);
        }
    }
}
