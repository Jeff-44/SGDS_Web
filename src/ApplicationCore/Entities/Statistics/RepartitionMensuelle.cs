using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities.Statistics
{
    public class RepartitionMensuelle
    {
        public string Mois { get; set; }
        public int TotalDons { get; set; }
        public int NouveauxDonneurs { get; set; }
        public int RendezVous { get; set; }
        public int Collectes { get; set; }
    }
}
