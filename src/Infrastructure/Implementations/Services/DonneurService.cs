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
    public class DonneurService :GenericService<Donneur>, IDonneurService
    {
        private readonly IDonneurRepository _repository;
        public DonneurService(IDonneurRepository repository) : base(repository)
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
            return await _repository.GetAllDonneursAsync();
        }

        public async Task<Donneur?> GetDonneurByIdAsync(long id)
        {
            if (!await DonneurExistsAsync(id))
            {
                throw new ArgumentException($"Donneur {id} introuvable.");
            }
            return await _repository.GetDonneurByIdAsync(id);
        }

        public async Task UpdateDonneurAsync(Donneur donneur)
        {
            await _repository.UpdateAsync(donneur);
        }
    }
}
