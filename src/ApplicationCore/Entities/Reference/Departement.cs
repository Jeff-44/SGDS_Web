using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.Entities.Reference
{
    public class Departement : Audit
    {
        [Key] public short Id { get; set; }
        [Required]
        public string Libelle { get; set; }
    }
}
