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
    public class DonneurService : IDonneurService
    {
        private readonly IDonneurRepository _repository;
        public DonneurService(IDonneurRepository repository)
        {
            _repository = repository;
        }
        public async Task AddDonneurAsync(Donneur donneur)
        {
            await _repository.AddAsync(donneur);
        }

        public Task<int> CountDonneursAsync()
        {
            throw new NotImplementedException();
        }

        public async Task DeleteDonneurAsync(Donneur donneur)
        {
            await _repository.DeleteAsync(donneur);
        }

        public async Task<bool> DonneurExistsAsync(long id)
        {
            return await _repository.ExistsAsync(id);
        }

        public async Task<IEnumerable<Donneur>> GetAllDonneursAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Donneur?> GetDonneurByIdAsync(long id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task UpdateDonneurAsync(Donneur donneur)
        {
            await _repository.UpdateAsync(donneur);
        }
    }
}
