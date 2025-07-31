using ApplicationCore.Entities.Location;
using ApplicationCore.Interfaces.IRepositories;
using ApplicationCore.Interfaces.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Implementations.Services
{
    public class CentreService : GenericService<Centre>, ICentreService
    {
        public CentreService(ICentreRepository repository) : base(repository)
        {
        }
    }
}
