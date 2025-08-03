using ApplicationCore.Entities.Reference;
using ApplicationCore.Interfaces.IRepositories;
using ApplicationCore.Interfaces.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Implementations.Services
{
    public class ArrondissementService : GenericService<Arrondissement>, IArrondissementService
    {
        public ArrondissementService(IArrondissementRepository repository) : base(repository)
        {
            
        }
    }
}
