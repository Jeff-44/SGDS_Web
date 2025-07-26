using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.Entities.Reference
{
    public class Arrondissement : Audit
    {
        [Key] public int Id { get; set; }
        [Required]
        public string Libelle { get; set; }
        public short? DepartementId { get; set; }
        public Departement? departement { get; set; }
    }
}
