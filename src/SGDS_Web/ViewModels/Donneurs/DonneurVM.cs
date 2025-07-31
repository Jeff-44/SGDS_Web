using ApplicationCore.Entities;
using System.ComponentModel.DataAnnotations;

namespace SGDS_Web.ViewModels.Donneurs
{
    public class DonneurVM
    {
        public long Id { get; set; }
        [Required(ErrorMessage = "Le CIN est obligatoire.")]
        public string CIN { get; set; }
        [Required(ErrorMessage = "Le NIF est obligatoire.")]
        public string NIF { get; set; }
        [Required(ErrorMessage = "Le nom est obligatoire.")]
        public string Nom { get; set; }
        [Required(ErrorMessage = "Le prénom est obligatoire.")]
        public string Prenom { get; set; }
        [Required(ErrorMessage = "Le sexe est obligatoire.")]
        public string Sexe { get; set; }
        [Display(Name = "Groupe Sanguin")]
        [Required(ErrorMessage = "Le Groupe Sanguin est obligatoire.")]
        public string GroupeSanguin { get; set; }
        [Required(ErrorMessage = "La date de naissance est obligatoire.")]
        [DataType(DataType.Date)]
        public DateOnly DateNaissance { get; set; }
        public string? StatutMatrimonial { get; set; }
        public string? Occupation { get; set; }
        public string? Adresse { get; set; }
        [Required(ErrorMessage = "Le numéro de téléphone est obligatoire.")]
        public string? Telephone { get; set; }
        [EmailAddress(ErrorMessage = "L'email est invalide.")]
        public string? Email { get; set; }
    }
}
