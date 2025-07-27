using ApplicationCore.Entities.Collectes;
using ApplicationCore.Interfaces.IRepositories;
using Infrastructure.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Implementations.Repositories
{
    public class DonneurRepository : GenericRepository<Donneur>, IDonneurRepository
    {
        public DonneurRepository(SGDSDbContext context) : base(context)
        {
        }
        // You can add any specific methods for DonneurRepository here if needed.
    }
}
