using ApplicationCore.Entities.Location;
using ApplicationCore.Interfaces.IRepositories;
using Infrastructure.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Implementations.Repositories
{
    public class CentreRepository : GenericRepository<Centre>, ICentreRepository
    {
        public CentreRepository(SGDSDbContext context) : base(context)
        {
        }
    }
}
