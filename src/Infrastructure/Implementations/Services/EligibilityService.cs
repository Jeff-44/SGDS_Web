using ApplicationCore.Entities.Collectes;
using ApplicationCore.Interfaces.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Implementations.Services
{
    public class EligibilityService : IEligibilityService
    {
        private readonly IDonneurService _donneurService;
        public EligibilityService(IDonneurService donneurService)
        {
            _donneurService = donneurService;
        }
        public bool IsEligible(Donneur donneur)
        {
            if (donneur.Dossier.EstAnemie) return false;

            if (donneur.Dossier.EstEnceinte) return false;

            if (donneur.Dossier.InfectionRecente) return false;

            if (donneur.Dossier.MaladieChronique) return false;

            //if (string.IsNullOrEmpty(donneur.Dossier.PriseDeMedicamentsActuel)) return false;

            if(CalculateAge(donneur) < 18) return false;

            return true;
        }

        public bool IsEligible(Dossier dossierDonneur)
        {
            if (dossierDonneur.EstAnemie) return false;

            if (dossierDonneur.EstEnceinte) return false;

            if (dossierDonneur.InfectionRecente) return false;

            if (dossierDonneur.MaladieChronique) return false;

            //if (string.IsNullOrEmpty(donneur.Dossier.PriseDeMedicamentsActuel)) return false;

            if (CalculateAge(dossierDonneur.Donneur) < 18) return false;

            return true;
        }

        public int CalculateAge(Donneur donneur)
        {
            var age = DateTime.Now.Year - donneur.DateNaissance.Year;
            return age < 0 ? 0 : age;
        }

        public async Task UpdateEligibilityAsync(Donneur donneur)
        {
            await _donneurService.UpdateAsync(donneur);
        }

        public async Task CheckEligibilityAsync(Donneur donneur)
        {
            if (donneur.Dossier != null)
            {
                var isEligible = IsEligible(donneur);
                if (donneur.EstEligible != isEligible)
                {
                    donneur.EstEligible = isEligible;
                    await UpdateEligibilityAsync(donneur);
                }
            }
        }

        public async Task CheckEligibilityAsync(IEnumerable<Donneur> donneurs)
        {
            foreach(var donneur in donneurs)
            {
                await CheckEligibilityAsync(donneur);
            }
        }

        //Generated method to check eligibility for all donors
        //public async Task<bool> CheckEligibilityAsync()
        //{
        //    var donneurs = await _donneurService.GetAllDonneursAsync();
        //    bool isEligibilityStatusChanged = false;
        //    foreach (var donneur in donneurs)
        //    {
        //        var isEligible = IsEligible(donneur);
        //        if (donneur.EstEligible != isEligible)
        //        {
        //            donneur.EstEligible = isEligible;
        //            await _donneurService.UpdateAsync(donneur);
        //            isEligibilityStatusChanged = true;
        //        }
        //    }
        //    return isEligibilityStatusChanged;
        //}

        //public async Task<bool> CheckEligibilityAsync(Donneur donneur)
        //{
        //    bool isEligibilityStatusChanged = false;
        //    var isEligible = IsEligible(donneur);
        //    if (donneur.EstEligible != isEligible)
        //    {
        //        donneur.EstEligible = isEligible;
        //        await _donneurService.UpdateAsync(donneur);
        //        isEligibilityStatusChanged = true;
        //    }

        //    return isEligibilityStatusChanged;
        //}
    }
}
