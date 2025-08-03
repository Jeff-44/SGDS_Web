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
    public class CommuneService : GenericService<Commune>, ICommuneService
    {
        public CommuneService(ICommuneRepository repository) : base(repository)
        {
            
        }
    }
}
