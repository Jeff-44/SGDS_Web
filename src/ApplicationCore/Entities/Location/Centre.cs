using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.Entities.Location
{
    public class Centre : Audit
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string NomCentre { get; set; }
        public string TypeCentre { get; set; }
        public long VilleId { get; set; }
    }
}