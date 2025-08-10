using System.ComponentModel.DataAnnotations;

namespace SGDS_Web.ViewModels
{
    public class ContactVM
    {
        [Required(ErrorMessage = "Le nom est requis")]
        [StringLength(100)]
        [Display(Name = "Nom complet")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "L'email est requis")]
        [EmailAddress(ErrorMessage = "Email invalide")]
        [Display(Name = "Email")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Le sujet est requis")]
        [StringLength(140, ErrorMessage = "Le sujet est trop long (max 140 caractères).")]
        [Display(Name = "Sujet")]
        public string Subject { get; set; } = string.Empty;

        [Required(ErrorMessage = "Le message est requis")]
        [StringLength(4000, ErrorMessage = "Message trop long (max 4000 caractères).")]
        [Display(Name = "Message")]
        public string Message { get; set; } = string.Empty;
    }


}
