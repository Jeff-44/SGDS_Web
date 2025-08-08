using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    public class DashboardStats
    {
        public int NombreDonneursActifs { get; set; }
        public int DonsCeMois { get; set; }
        public int RendezVousCetteSemaine { get; set; }
        public double TauxParticipationRDV { get; set; }
        public int NouveauxDonneursCeMois { get; set; }
        public Dictionary<string, int> DonsParType { get; set; } // "Sang" -> 45, "Plasma" -> 22
    }
}
