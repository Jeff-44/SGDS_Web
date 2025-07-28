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
    public class DossierService : GenericService<Dossier>, IDossierService
    {
        public DossierService(IDossierRepository repository) : base(repository) 
        {
        }
    }
}
