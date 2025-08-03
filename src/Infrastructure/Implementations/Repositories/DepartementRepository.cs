using ApplicationCore.Entities.Reference;
using ApplicationCore.Interfaces.IRepositories;
using Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Implementations.Repositories
{
    public class DepartementRepository : GenericRepository<Departement>, IDepartementRepository
    {
        private readonly SGDSDbContext _context;
        public DepartementRepository(SGDSDbContext context) : base(context)
        {
            _context = context;
        }
        public Task<IEnumerable<Departement>> GetAllDepartementsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Departement?> GetDepartementByIdAsync()
        {
            throw new NotImplementedException();
        }
    }
}
