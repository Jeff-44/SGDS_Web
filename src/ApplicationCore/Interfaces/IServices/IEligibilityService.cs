using ApplicationCore.Entities.Collectes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces.IServices
{
    public interface IEligibilityService
    {
        Task<bool> IsEligibleAsync(Donneur donneur);
        Task CheckEligibilityAsync(IEnumerable<Donneur> donneurs);
        Task CheckEligibilityAsync(Donneur donneur);
        Task UpdateDonneurAsync(Donneur donneur); //?? Update the eligibility status of a specific donor
    }
}
