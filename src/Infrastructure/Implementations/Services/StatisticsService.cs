using ApplicationCore.Entities.Statistics;
using ApplicationCore.Interfaces.IServices;
using ApplicationCore.Static;
using Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Implementations.Services
{
    public class StatisticsService : IStatisticsService
    {
        private readonly SGDSDbContext _context;
        public StatisticsService(SGDSDbContext context)
        {
            _context = context;
        }
        public async Task<GlobalStatistics> GetGlobalStatisticsAsync()
        {
            var dateMoisPrecedent = DateTime.UtcNow.AddMonths(-1);
            var donsCeMois = await _context.Dons
                .CountAsync(d => d.CreeLe >= dateMoisPrecedent);
            var stats = new GlobalStatistics
            {
                NombreDonneursActifs = await _context.Donneurs.CountAsync(d => d.EstActif),
                DonsCeMois = await _context.Dons.CountAsync(d => d.CreeLe >= dateMoisPrecedent),
                //RendezVousCetteSemaine = _context.RendezVous.Count(r => r.Date >= DateTime.Now.AddDays(-7)),
                //TauxParticipationRDV = _context.RendezVous.Any() ? 
                //    (double)_context.RendezVous.Count(r => r.EstConfirme) / _context.RendezVous.Count() * 100 : 0,
                NouveauxDonneursCeMois = await _context.Donneurs.CountAsync(d => d.CreeLe >= dateMoisPrecedent),
                //DonsParType = _context.Dons
                //    .GroupBy(d => d.Type)
                //    .ToDictionary(g => g.Key, g => g.Count())
            };

            return stats;
        }

        //public Task<RepartionMensuel> GetMonthlyStatisticsAsync()
        //{
        //    throw new NotImplementedException();
        //}

        public async Task<IEnumerable<RepartitionMensuelle>> GetMonthlyStatisticsAsync()
        {
            var moisList = DatePeriodeService.GetLast12Months();
            var result = new List<RepartitionMensuelle>();

            foreach (var (year, month) in moisList)
            {
                var (start, end) = DatePeriodeService.GetMonthRange(year, month);
                var startDate = DateOnly.FromDateTime(start);
                var endDate = DateOnly.FromDateTime(end);

                var label = $"{year}-{month:D2}";

                //var totalDons = await _context.Dons
                //    .CountAsync(d => d.CreeLe >= start && d.CreeLe < end && d.Statut == "Effectué");
                var totalDons = await _context.Dons
                    .CountAsync(d => d.CreeLe >= start && d.CreeLe < end);

                var nouveauxDonneurs = await _context.Donneurs
                    .CountAsync(d => d.CreeLe >= start && d.CreeLe < end);

                //var rdv = await _context.RendezVous
                //    .CountAsync(r => r.Date >= start && r.Date < end);

                var collectes = await _context.Collectes
                    .CountAsync(c => c.DateCollecte >= startDate && c.DateCollecte < endDate);

                result.Add(new RepartitionMensuelle
                {
                    Mois = label,
                    TotalDons = totalDons,
                    NouveauxDonneurs = nouveauxDonneurs,
                    //RendezVous = rdv,
                    Collectes = collectes
                });
            }

            return result;
        }

    }
}
