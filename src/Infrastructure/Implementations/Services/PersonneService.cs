using ApplicationCore.Entities;
using ApplicationCore.Interfaces.IRepositories;
using ApplicationCore.Interfaces.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Implementations.Services
{
    public class PersonneService : IPersonneService
    {
        private readonly IPersonneRepository _repository;
        public PersonneService(IPersonneRepository repository)
        {
            _repository = repository;
        }
        public async Task AddPersonne(Personne entity)
        {
            await _repository.AddAsync(entity);
        }
    }
}
