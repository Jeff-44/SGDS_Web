using ApplicationCore.Entities.Reference;
using Microsoft.AspNetCore.Mvc.Rendering;
using SGDS_Web.ViewModels.Reference;
using System.ComponentModel.DataAnnotations;

namespace SGDS_Web.ViewModels.Centres
{
    public class CreerModifierCentre
    {
        public int Id { get; set; }

        //[Display(Name = "Code Centre")]
        //public string? Code { get; set; }
        [Required(ErrorMessage ="Le nom du centre est obligatoire.")]
        [Display(Name = "Nom Centre")]
        public string NomCentre { get; set; }
        //categorie du centre fixe ou mobile
        //public bool IsMobile { get; set; }
        //public bool IsFixe { get; set; }

        [Required(ErrorMessage = "La categorie est obligatoire.")]
        [Display(Name = "Catégorie")]
        public string TypeCentre { get; set; }



        //FIXE OU MOBILE
        //[Display(Name = "Responsable")]
        //public long PersonneResponsableId { get; set; }
        //UTILISATEURS CLES: ADMIN, PERSONNEL DE LA CRH
        [Required]
        [Display(Name = "Département")]
        public short DepartementId { get; set; }
        [Required]
        [Display(Name = "Arrondissement")]
        public int ArrondissementId { get; set; }
        [Required]
        [Display(Name = "Commune")]
        public int CommuneId { get; set; }

        public SelectList? Departements { get; set; }
        public IEnumerable<CommuneVM>? Communes { get; set; }
        public IEnumerable<ArrondissementVM>? Arrondissements { get; set; }
    }
}
