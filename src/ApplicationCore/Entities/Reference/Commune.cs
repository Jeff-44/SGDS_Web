using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.Entities.Reference
{
    public class Commune : Audit
    {
        public int Id { get; set; }
        public string Nom { get; set; } = default!;
        public int ArrondissementId { get; set; }
        //------------------------------------------
        public short DepartementId { get; set; }
        public int MapId { get; set; }
        public float Latitude { get; set; } = default;
        public float Longitude { get; set; } = default;
        public long Population { get; set; }
        public int Superficie { get; set; }
        public int Zoom { get; set; }
        //------------------------------------------
        public Arrondissement Arrondissement { get; set; } = default!;
    }
}
