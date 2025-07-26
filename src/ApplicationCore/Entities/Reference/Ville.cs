using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.Entities.Reference
{
    public class Ville : Audit
    {
        [Key] public int Id { get; set; }
        [Required] public string Libelle { get; set; }
        public int? ArrondissementId { get; set; }
    }
}
