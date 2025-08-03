using ApplicationCore.Entities.Location;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace SGDS_Web.ViewModels.Collectes
{
    public class CreerModifierCollecte
    {
        public long Id { get; set; }
        [Required(ErrorMessage = "Le code est obligatoire")]
        public string Code { get; set; }
        public string? Libelle { get; set; }
        public string? Description { get; set; }
        [Required(ErrorMessage = "La date est obligatoire")]
        [Display(Name = "Date Collecte")]
        [DataType(DataType.Date)]
        public DateOnly DateCollecte { get; set; }
        [Required]
        [Display(Name = "Centre")]
        public int CentreId { get; set; }
        public SelectList? Centres { get; set; }
        //public Centre? Centre { get; set; }
    }
}
