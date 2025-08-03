using ApplicationCore.Entities.Collectes;
using System.ComponentModel.DataAnnotations;

namespace SGDS_Web.ViewModels.Dons
{
    public class DonVM
    {
        public long Id { get; set; }
        public long DonneurId { get; set; }
        public Donneur? Donneur { get; set; }
        public long CollecteId { get; set; }
        public Collecte? Collecte { get; set; }
        public int Volume { get; set; }
        public bool TestePositifPourMaladie { get; set; }
    }
}
