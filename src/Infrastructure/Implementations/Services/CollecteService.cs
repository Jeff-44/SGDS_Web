using ApplicationCore.Entities.Collectes;
using ApplicationCore.Interfaces.IRepositories;
using ApplicationCore.Interfaces.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Implementations.Services
{
    public class CollecteService : GenericService<Collecte>,  ICollecteService
    {
        public CollecteService(ICollecteRepository repository) : base(repository)
        {
            
        }
    }
}
