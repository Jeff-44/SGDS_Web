using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities.Collectes
{
    public class Commentaire : Audit
    {
        [Key] public long Id { get; set; }
        [Required]
        public long DonneurId { get; set; }
        public Donneur? Donneur { get; set; }
        [Required]
        public string? Description { get; set; }
    }
}
