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
    public class CollecteRepository : GenericRepository<Collecte>, ICollecteRepository
    {
        public CollecteRepository(SGDSDbContext context) : base(context)
        {
        }
    }
}
