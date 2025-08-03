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
    public class ArrondissementRepository : GenericRepository<Arrondissement>, IArrondissementRepository
    {
        public ArrondissementRepository(SGDSDbContext context) : base(context)
        {
            
        }
    }
}
