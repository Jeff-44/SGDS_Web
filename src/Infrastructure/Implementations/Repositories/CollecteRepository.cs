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
    public class CollecteRepository : GenericRepository<Collecte>, ICollecteRepository
    {
        private readonly SGDSDbContext _context;
        public CollecteRepository(SGDSDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Collecte>?> GetAllCollectesAsync()
        {
            return await _context.Collectes.Include(c => c.Centre).ToListAsync();
        }

        public async Task<Collecte?> GetCollecteByIdAsync(long id)
        {
            return await _context.Collectes
                .Include(c => c.Centre).FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
