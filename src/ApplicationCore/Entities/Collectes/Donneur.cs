using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities.Collectes
{
    public class Donneur : Personne
    {
        // [Display(Name = "Code Donneur")]
        // public string Code { get; set; } = Guid.NewGuid().ToString();
        public string GroupeSanguin { get; set; }
        public bool EstEligible { get; set; }
        public bool? EstRegulier { get; set; }
        public bool EstActif { get; set; } = true;
        public string? Raison { get; set; }
        public long? PersonneDeContactId { get; set; }
        [Display(Name = "Personne de Contact")]
        public PersonneDeContact? PersonneDeContact { get; set; }
        public Dossier? Dossier { get; set; }
    }
}
