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
    public class DossierRepository : GenericRepository<Dossier>, IDossierRepository
    {
        private readonly SGDSDbContext _context;
        public DossierRepository(SGDSDbContext context) : base(context) 
        {
            _context = context;
        }

        public async Task<Dossier?> GetDossierByIdAsync(long id)
        {
            return await _context.Dossiers
                .Include(d => d.Donneur)
                .FirstOrDefaultAsync(d => d.Id == id);
        }
        public async Task<IEnumerable<Dossier>?> GetAllDossiersAsync()
        {
            return await _context.Dossiers
                .Include(d => d.Donneur)
                .ToListAsync();
        }
    }
}
