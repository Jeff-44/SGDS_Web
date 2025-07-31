using ApplicationCore.Entities.Location;
using System.ComponentModel.DataAnnotations;

namespace SGDS_Web.ViewModels
{
    public class CollecteVM
    {
        public long Id { get; set; }
        public string? Description { get; set; }
        [Required]
        [Display(Name = "Date Collecte")]
        [DataType(DataType.Date)]
        public DateOnly DateCollecte { get; set; }
        [Required]
        [Display(Name = "Centre")]
        public int CentreId { get; set; }
        public Centre? Centre { get; set; }
    }
}
