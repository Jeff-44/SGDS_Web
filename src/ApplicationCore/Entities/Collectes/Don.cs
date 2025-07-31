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
        public long Id { get; set; }
        public long DonneurId { get; set; }
        public Donneur? Donneur { get; set; }
        public long CollecteId { get; set; }
        public Collecte? Collecte { get; set; }
        public int Volume { get; set; }
        public bool TestePositifPourMaladie { get; set; }
    }
}
