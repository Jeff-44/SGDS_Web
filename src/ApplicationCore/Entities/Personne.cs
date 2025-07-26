using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    public class Personne : Audit
    {
        [Key] public long Id { get; set; }
        public string CIN { get; set; }
        public string NIF { get; set; }
        [Required(ErrorMessage = "Le nom est obligatoire.")]
        public string Nom { get; set; }
        [Required(ErrorMessage = "Le prénom est obligatoire.")]
        public string Prenom { get; set; }
        [Required(ErrorMessage = "Le sexe est obligatoire.")]
        public string Sexe { get; set; }
        [Required(ErrorMessage = "Le date de naissance est obligatoire.")]
        public DateTime DateNaissance { get; set; }
        public string? StatutMatrimonial { get; set; }
        public string? Occupation { get; set; }
        public string? Adresse { get; set; }
        public string? Telephone { get; set; }
        public string? Email { get; set; }
    }
}
