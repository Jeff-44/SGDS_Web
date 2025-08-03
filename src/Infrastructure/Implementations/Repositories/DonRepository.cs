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
    public class DonRepository : GenericRepository<Don>, IDonRepository
    {
        private readonly SGDSDbContext _context;
        public DonRepository(SGDSDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Don>?> GetAllDonsAsync()
        {
            return await _context.Dons
                            .Include(d => d.Donneur)
                            .Include(d => d.Collecte)
                            .ToListAsync();
        }

        public async Task<Don?> GetDonByIdAsync(long id)
        {
            return await _context.Dons
                            .Include(d => d.Donneur)
                            .Include(d => d.Collecte)
                            .FirstOrDefaultAsync(d => d.Id == id);
        }
    }
}
