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
        [Display(Name = "Code Donneur")]
        public string Code { get; set; } = Guid.NewGuid().ToString();
        [Display(Name = "Groupe Sanguin")]
        public string GroupeSanguin { get; set; }
        public long? PersonneDeContactId { get; set; }
        [Display(Name = "Personne de Contact")]
        public PersonneDeContact? PersonneDeContact { get; set; }
    }
}
