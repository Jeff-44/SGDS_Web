using ApplicationCore.Entities;
using ApplicationCore.Interfaces.IRepositories;
using Infrastructure.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Implementations.Repositories
{
    public class PersonneRepository : GenericRepository<Personne>, IPersonneRepository
    {
        public PersonneRepository(SGDSDbContext context) : base(context)
        {
        }
    }
}
