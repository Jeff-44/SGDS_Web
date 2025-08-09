using ApplicationCore.Entities.Collectes;
using Microsoft.AspNetCore.Mvc.Rendering;
using SGDS_Web.ViewModels.Donneurs;
using System.ComponentModel.DataAnnotations;

namespace SGDS_Web.ViewModels.Dossiers
{
    public class DossierVM
    {
        public long Id { get; set; }
        [Display(Name ="NIF")]
        public long DonneurId { get; set; }
        //-----------------------------
        public Donneur? Donneur { get; set; }
        //-----------------------------
        public bool MaladieChronique { get; set; }
        public string? DetailsMaladieChronique { get; set; }
        [Display(Name = "Est anémie")]
        public bool EstAnemie { get; set; }
        [Display(Name = "Est enceinte")]
        public bool EstEnceinte { get; set; }
        [Display(Name = "Infection récente")]
        public bool InfectionRecente { get; set; }
        //[DataType(DataType.Date)]
        [Display(Name = "Date dernière infection")]
        public DateOnly? DateInfectionRecente { get; set; }
        [Display(Name = "Prise de médicaments actuel")]
        public string? PriseDeMedicamentsActuel { get; set; }
        [Required(ErrorMessage="Le poids est obligatoire")]
        public float Poids { get; set; }

        //public DonneurVM? Donneur { get; set; }

        //public List<PrelevementVM>? Prelevements { get; set; } = new List<PrelevementVM>();
        //public SelectList? Donneurs { get; set; }



        //public long Id { get; set; }
        //public long DonneurId { get; set; }
        //public bool MaladieChronique { get; set; }
        //public string? DetailsMaladieChronique { get; set; }

        //public bool EstAnemie { get; set; }

        //public bool EstEnceinte { get; set; }

        //public bool InfectionRecente { get; set; }
        //public DateOnly? DateInfectionRecente { get; set; }
        //public string? PriseDeMedicamentsActuel { get; set; }
        //public float Poids { get; set; }

        ////public DonneurVM? Donneur { get; set; }

        ////public List<PrelevementVM>? Prelevements { get; set; } = new List<PrelevementVM>();
        //public List<SelectListItem>? Donneurs { get; set; }
    }
}
