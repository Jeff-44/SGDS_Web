using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities.Collectes
{
    public class Don : Audit
    {
        [Required]
        [Display(Name = "Donneur")]
        public long DonneurId { get; set; }
        public Donneur? Donneur { get; set; }
        [Required]
        [Display(Name = "Collecte")]
        public long CollecteId { get; set; }
        public Collecte? Collecte { get; set; }
        [Required]
        public int Volume { get; set; }
        public bool TestePositifPourMaladie { get; set; }
    }
}
