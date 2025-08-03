using ApplicationCore.Entities.Collectes;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace SGDS_Web.ViewModels.Dons
{
    public class CreerModifierDon
    {
        public long Id { get; set; }
        [Required]
        [Display(Name = "Donneur")]
        public long DonneurId { get; set; }
        [Required]
        [Display(Name = "Collecte")]
        public long CollecteId { get; set; }
        [Required]
        public int Volume { get; set; }
        public bool TestePositifPourMaladie { get; set; }
        public SelectList? Donneurs { get; set; }
        public SelectList? Collectes { get; set; }
    }
}
