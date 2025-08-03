using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    public class Audit
    {
        [Display(Name = "Crée Par")]
        public string? CreePar { get; set; }
        [Display(Name = "Crée Le")]
        public DateTime? CreeLe { get; set; } = null;
        [Display(Name = "Modifié Par")]
        public string? ModifiePar { get; set; }
        [Display(Name = "Modifié Le")]
        public DateTime? ModifieLe { get; set; } = null;
    }
}
