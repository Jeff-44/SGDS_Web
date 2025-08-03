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
        public async Task<bool> IsEligibleAsync(Donneur donneur)
        {
            const int MIN_AGE = 18;
            const int MAX_AGE = 65;
            const float MIN_WEIGHT = 50.0f;
            const int MINIMUM_DAYS_SINCE_LAST_DONATION = 90;
            const int MINIMUM_DAYS_SINCE_LAST_INFECTION = 90;

            var age = CalculateAge(donneur);

            if (donneur.Dossier == null)
            {
                await UpdateRaisonEligibilityAsync(donneur, "Dossier du donneur est manquant.");
                return false;
            }

            if (!donneur.EstActif)
            {
                await UpdateRaisonEligibilityAsync(donneur, "Donneur inactif.");
                return false;
            }

            //if (donneur.EstActif.DateDernierDon.HasValue)
            //{
            //    await UpdateRaisonEligibilityAsync(donneur, "Donneur inactif.");
            //    return false;
            //}

            if (donneur.Dossier.EstAnemie)
            {
                await UpdateRaisonEligibilityAsync(donneur.Dossier.Donneur, "Le donneur est anémié.");
                return false;
            }

            if (donneur.Dossier.EstEnceinte) return false;
            if (donneur.Dossier.EstEnceinte)
            {
                await UpdateRaisonEligibilityAsync(donneur.Dossier.Donneur, "Le donneur est actuellement enceinte.");
                return false;
            }

            if (donneur.Dossier.MaladieChronique)
            {
                await UpdateRaisonEligibilityAsync(donneur.Dossier.Donneur, "Le donneur souffre d'une maladie chronique.");
                return false;
            }

            //if (string.IsNullOrEmpty(donneur.Dossier.PriseDeMedicamentsActuel)) return false;

            
            if (donneur.Dossier.Poids < MIN_WEIGHT)
            {
                await UpdateRaisonEligibilityAsync(donneur.Dossier.Donneur, "Poids inférieur à 50 kg.");
                return false;
            }
            
            if (age < MIN_AGE || age > 65)
            {
                await UpdateRaisonEligibilityAsync(donneur.Dossier.Donneur, "Age non autorisé pour donner du sang.");
                return false;
            }


            //if (donneur.DateDernierDon.HasValue)
            //{
            //    var daysSinceLastDonation = (DateTime.Now - donneur.DateDernierDon.Value.ToDateTime(TimeOnly.MinValue)).TotalDays;
            //    if (daysSinceLastDonation < MINIMUM_DAYS_SINCE_LAST_DONATION)
            //    {
            //        await UpdateRaisonEligibilityAsync(donneur.Dossier.Donneur, "Le donneur doit attendre au moins 90 jours depuis son dernier don.");
            //        return false;
            //    }
            //}

            if (CheckLastDonationDateAsync(donneur, MINIMUM_DAYS_SINCE_LAST_DONATION).GetAwaiter().GetResult()) 
            {
                await UpdateRaisonEligibilityAsync(donneur.Dossier.Donneur, "Le donneur doit attendre au moins 90 jours depuis son dernier don.");
                return false;
            }

            if (CheckRecentInfectionDateAsync(donneur, MINIMUM_DAYS_SINCE_LAST_INFECTION).GetAwaiter().GetResult()) 
            {
                await UpdateRaisonEligibilityAsync(donneur.Dossier.Donneur, "Le donneur a une infection récente.");
                return false;
            }

            return true;
        }

        public int CalculateAge(Donneur donneur)
        {
            var age = DateTime.Now.Year - donneur.DateNaissance.Year;
            //if (DateTime.Now.Month < donneur.DateNaissance.Month && DateTime.Now.Day < donneur.DateNaissance.Day) age--;
            return age < 0 ? 0 : age;
        }

        public async Task<bool> CheckLastDonationDateAsync(Donneur donneur, int minimumdays) 
        {
            bool result = false;
            var today = DateOnly.FromDateTime(DateTime.Now);
            if (donneur.DateDernierDon.HasValue) 
            {
                var daysSinceLastDonation = (DateTime.Now - donneur.DateDernierDon.Value.ToDateTime(TimeOnly.MinValue)).TotalDays;
                if (daysSinceLastDonation < minimumdays)
                {
                    donneur.ProchaineDateEligible = donneur.DateDernierDon.Value.AddDays(minimumdays);
                    await UpdateDonneurAsync(donneur);
                    result = true;
                }
            }

            return result;
        }
        public async Task<bool> CheckRecentInfectionDateAsync(Donneur donneur, int minimumdays) 
        {
            bool result = false;
            if (donneur.Dossier.DateInfectionRecente.HasValue) 
            {
                var daysSinceLastInfection = (DateTime.Now - donneur.Dossier.DateInfectionRecente.Value.ToDateTime(TimeOnly.MinValue)).TotalDays;
                if (daysSinceLastInfection < minimumdays)
                {
                    donneur.Dossier.InfectionRecente = true;
                    donneur.ProchaineDateEligible = donneur.Dossier.DateInfectionRecente.Value.AddDays(minimumdays);
                    result = true;
                }
                else
                {
                    donneur.Dossier.InfectionRecente = false;
                    result = false;
                }

                await UpdateDonneurAsync(donneur);
            }
            return result;
        }

        public async Task UpdateDonneurAsync(Donneur donneur)
        {
            await _donneurService.UpdateAsync(donneur);
        }

        public async Task CheckEligibilityAsync(Donneur donneur)
        {
            if (donneur.Dossier != null)
            {
                var isEligible = await IsEligibleAsync(donneur);
                if (donneur.EstEligible != isEligible)
                {
                    donneur.EstEligible = isEligible;
                    await UpdateDonneurAsync(donneur);
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

        public async Task UpdateRaisonEligibilityAsync(Donneur donneur, string? raison)
        {
            donneur.Raison = raison;
            await UpdateDonneurAsync(donneur);
        }
    }
}
