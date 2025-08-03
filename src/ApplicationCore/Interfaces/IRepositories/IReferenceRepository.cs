using ApplicationCore.Entities;
using ApplicationCore.Entities.Reference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces.IRepositories
{
    public interface IDepartementRepository : IGenericRepository<Departement>
    {
        Task<IEnumerable<Departement>> GetAllDepartementsAsync();
        Task<Departement?> GetDepartementByIdAsync();
    }
}
