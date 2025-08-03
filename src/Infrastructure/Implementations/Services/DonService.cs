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
    public class DonService : GenericService<Don>, IDonService
    {
        private readonly IDonRepository _repository;
        public DonService(IDonRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Don>?> GetAllDonsAsync()
        {
            return await _repository.GetAllDonsAsync();
        }

        public async Task<Don?> GetDonByIdAsync(long id)
        {
            return await _repository.GetDonByIdAsync(id);
        }
    }
}
