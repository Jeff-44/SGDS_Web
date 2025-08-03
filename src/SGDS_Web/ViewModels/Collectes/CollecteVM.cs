using ApplicationCore.Entities.Location;
using System.ComponentModel.DataAnnotations;

namespace SGDS_Web.ViewModels.Collectes
{
    public class CollecteVM
    {
        public long Id { get; set; }
        public string Code { get; set; }
        public string? Libelle { get; set; }
        public string? Description { get; set; }
        [Display(Name = "Date Collecte")]
        public DateOnly DateCollecte { get; set; }
        public int CentreId { get; set; }
        public Centre? Centre { get; set; }
    }
}
