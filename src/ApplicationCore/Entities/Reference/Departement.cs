using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.Entities.Reference
{
    public class Departement : Audit
    {
        public short Id { get; set; }
        //public int Id { get; set; }
        public string Nom { get; set; } = default!;
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public ICollection<Arrondissement> Arrondissements { get; set; }
            = new List<Arrondissement>();
    }
}
