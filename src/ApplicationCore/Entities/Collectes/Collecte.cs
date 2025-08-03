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
        public long Id { get; set; }
        public string? Code { get; set; }
        public string? Libelle { get; set; }
        public string? Description { get; set; }
        public DateOnly DateCollecte { get; set; }
        public int CentreId { get; set; }
        public Centre? Centre { get; set; }
   
    }
}
