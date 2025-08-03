using ApplicationCore.Entities.Reference;
using System.ComponentModel.DataAnnotations;

namespace SGDS_Web.ViewModels.Centres
{
    public class CentreVM
    {
        public int Id { get; set; }

        //[Display(Name = "Code Centre")]
        //public string? Code { get; set; }

        [Display(Name = "Nom Centre")]
        public string NomCentre { get; set; }

        [Display(Name = "Categorie")]
        public string TypeCentre { get; set; }

        //FIXE OU MOBILE
        //[Display(Name = "Responsable")]
        //public long PersonneResponsableId { get; set; }
        //UTILISATEURS CLES: ADMIN, PERSONNEL DE LA CRH

        [Required]
        [Display(Name = "Ville")]
        public int CommuneId { get; set; }
        public Commune Commune { get; set; }
    }
}
