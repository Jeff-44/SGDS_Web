using ApplicationCore.Entities.Reference;
using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.Entities.Location
{
    public class Centre : Audit
    {
        public int Id { get; set; }
        //public string Code { get; set; }
        public string NomCentre { get; set; }
        public string TypeCentre { get; set; }
        public int CommuneId { get; set; }
        public Commune Commune { get; set; }
    }
}