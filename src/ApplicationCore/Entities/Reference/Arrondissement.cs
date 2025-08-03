using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.Entities.Reference
{
    public class Arrondissement : Audit
    {
        public int Id { get; set; }
        public string Nom { get; set; } = default!;
        //public int DepartmentId { get; set; }
        public short DepartementId { get; set; }
        //public float Latitude { get; set; }
        //public float Longitude { get; set; }
        public Departement Departement { get; set; } = default!;        
        public ICollection<Commune> Communes { get; set; }
            = new List<Commune>();
    }
}
