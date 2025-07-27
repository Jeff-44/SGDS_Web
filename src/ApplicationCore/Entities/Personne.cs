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
       
        public string Nom { get; set; }
        
        public string Prenom { get; set; }
        
        public string Sexe { get; set; }
        
        public DateOnly DateNaissance { get; set; }
        public string? StatutMatrimonial { get; set; }
        public string? Occupation { get; set; }
        public string? Adresse { get; set; }
        public string Telephone { get; set; }
        public string? Email { get; set; }
    }
}
