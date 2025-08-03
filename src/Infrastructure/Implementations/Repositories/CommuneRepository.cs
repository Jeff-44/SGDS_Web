using ApplicationCore.Entities.Reference;
using ApplicationCore.Interfaces.IRepositories;
using Infrastructure.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Implementations.Repositories
{
    public class CommuneRepository : GenericRepository<Commune>, ICommuneRepository
    {
        public CommuneRepository(SGDSDbContext context) : base(context)
        {
            
        }
    }
}
