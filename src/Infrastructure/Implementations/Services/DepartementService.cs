using ApplicationCore.Entities.Reference;
using ApplicationCore.Interfaces.IRepositories;
using ApplicationCore.Interfaces.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Implementations.Services
{
    public class DepartementService : GenericService<Departement>, IDepartementService
    {
        private readonly IDepartementRepository _repository;
        public DepartementService(IDepartementRepository repository) : base(repository)
        {
            _repository = repository;
        }
        public Task<IEnumerable<Departement>> GetByRegionIdAsync(int regionId)
        {
            throw new NotImplementedException("Method not implemented yet.");
            //return await _repository.GetByRegionIdAsync(regionId);
        }
        public Task<Departement> GetByCodeAsync(string code)
        {
            throw new NotImplementedException("Method not implemented yet.");
            //return await _repository.GetByCodeAsync(code) ?? throw new KeyNotFoundException($"Departement with code {code} not found");
        }
    }
}
