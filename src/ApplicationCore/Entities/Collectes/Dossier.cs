using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities.Collectes
{
    public class Dossier : Audit
    {
        public long Id { get; set; }
        public long DonneurId { get; set; }
        public Donneur? Donneur { get; set; }
        public bool MaladieChronique { get; set; }
        public string? DetailsMaladieChronique { get; set; }
        public bool EstAnemie { get; set; }
        public bool EstEnceinte { get; set; }
        public bool InfectionRecente { get; set; }
        public DateOnly? DateInfectionRecente { get; set; }
        public string? PriseDeMedicamentsActuel { get; set; }
        public float Poids { get; set; }
        //[Required(ErrorMessage = "Le poids de la personne est obligatoire.")]
        //[Range(10, 500, ErrorMessage = "Le poids de la personne doit être compris entre 10 et 500 kg")]
        //public float Poids { get; set; }
        //[Required(ErrorMessage = "Le pouls de la personne est obligatoire.")]
        //[Range(10, 1000, ErrorMessage = "Le pouls est invalide. Il doit être compris entre 10 et 1000 bpm")]
        //public int Pouls { get; set; }
        //[Required(ErrorMessage = "La tension arterielle Systolique de la personne est obligatoire.")]
        //public int TensionArterielleSystolique { get; set; }
        //[Required(ErrorMessage = "La tension arterielle Diastolique de la personne est obligatoire.")]
        //public int TensionArterielleDiastolique { get; set; }
        //[Required(ErrorMessage = "Le niveau d'hémoglobine est obligatoire.")]
        //[Range(0.0, 20.0, ErrorMessage = "Le niveau d'hémoglobine doit être compris entre 0.0 et 20.0.")]
        //public decimal Hemoglobine { get; set; }
        //public bool EtatDeSante { get; set; }
    }
}
