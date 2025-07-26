using ApplicationCore.Entities;
using System.ComponentModel.DataAnnotations;

namespace SGDS_Web.ViewModels
{
    public class DonneurVM
    {
        //public string CIN { get; set; }
        //public string NIF { get; set; }
        //[Required(ErrorMessage = "Le nom est obligatoire.")]
        //public string Nom { get; set; }
        //[Required(ErrorMessage = "Le prénom est obligatoire.")]
        //public string Prenom { get; set; }
        //[Required(ErrorMessage = "Le sexe est obligatoire.")]
        //public string Sexe { get; set; }
        //[Required(ErrorMessage = "Le date de naissance est obligatoire.")]
        //public DateTime DateNaissance { get; set; }
        //public string? StatutMatrimonial { get; set; }
        //public string? Occupation { get; set; }
        //public string? Adresse { get; set; }
        //public string? Telephone { get; set; }
        //public string? Email { get; set; } 

        public string CIN { get; set; }
        public string NIF { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Sexe { get; set; }
        public string GroupeSanguin { get; set; }
        public DateTime DateNaissance { get; set; }
        public string? StatutMatrimonial { get; set; }
        public string? Occupation { get; set; }
        public string? Adresse { get; set; }
        public string? Telephone { get; set; }
        public string? Email { get; set; }
    }
}
