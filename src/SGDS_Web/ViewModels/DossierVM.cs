using ApplicationCore.Entities.Collectes;
using System.ComponentModel.DataAnnotations;

namespace SGDS_Web.ViewModels
{
    public class DossierVM
    {
        public long Id { get; set; }
        public long DonneurId { get; set; }
        public bool MaladieChronique { get; set; }
        public string? DetailsMaladieChronique { get; set; }
        [Display(Name = "Est anémie")]
        public bool EstAnemie { get; set; }
        [Display(Name = "Est enceinte")]
        public bool EstEnceinte { get; set; }
        [Display(Name = "Infection récente")]
        public bool InfectionRecente { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Date dernière infection")]
        public DateOnly? DateInfectionRecente { get; set; }
        [Display(Name = "Prise de médicaments actuel")]
        public string? PriseDeMedicamentsActuel { get; set; }
        [Required(ErrorMessage="Le poids est obligatoire")]
        public float Poids { get; set; }
    }
}
