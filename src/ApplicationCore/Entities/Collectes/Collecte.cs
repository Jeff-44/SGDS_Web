using ApplicationCore.Entities.Location;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities.Collectes
{
    public class Collecte : Audit
    {
        [Key] public long Id { get; set; }
        [Required]
        [Display(Name = "Date Collecte")]
        [DataType(DataType.Date)]
        public DateTime DateCollecte { get; set; }
        [Required]
        [Display(Name = "Centre")]
        public int CentreId { get; set; }
        public Centre? Centre { get; set; }
        //[Required]
        //public long Organisateur { get; set; }
    }
}
