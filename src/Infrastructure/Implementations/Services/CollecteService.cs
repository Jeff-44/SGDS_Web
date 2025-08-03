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
    public class CollecteService : GenericService<Collecte>,  ICollecteService
    {
        private readonly ICollecteRepository _repository;
        public CollecteService(ICollecteRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public Task<IEnumerable<Collecte>?> GetAllCollectesAsync()
        {
            return _repository.GetAllCollectesAsync();
        }

        public async Task <Collecte?> GetCollecteByIdAsync(long id)
        {
            return await _repository.GetCollecteByIdAsync(id);
        }
    }
}
