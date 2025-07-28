using ApplicationCore.Entities.Collectes;
using System.ComponentModel.DataAnnotations;

namespace SGDS_Web.ViewModels
{
    public class DonVM
    {
        public long Id { get; set; }
        [Required]
        [Display(Name = "Donneur")]
        public long DonneurId { get; set; }
        public Donneur? Donneur { get; set; }
        [Required]
        [Display(Name = "Collecte")]
        public long CollecteId { get; set; }
        public Collecte? Collecte { get; set; }
        [Required]
        public int Volume { get; set; }
        public bool TestePositifPourMaladie { get; set; }
    }
}
