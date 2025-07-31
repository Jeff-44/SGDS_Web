using ApplicationCore.Entities.Collectes;
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
    public class DonneurRepository : GenericRepository<Donneur>, IDonneurRepository
    {
        private readonly SGDSDbContext _context;
        public DonneurRepository(SGDSDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Donneur>> GetAllDonneursAsync()
        {
            return await _context.Donneurs
                                 .Include(d => d.Dossier)
                                 .ToListAsync();
        }

        public async Task<Donneur?> GetDonneurByIdAsync(long donneurId)
        {
            return await _context.Donneurs
                                 .Include(d => d.Dossier)
                                 .FirstOrDefaultAsync(d => d.Id == donneurId);
        }
    }
}
