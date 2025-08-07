using System.ComponentModel.DataAnnotations;

namespace SGDS_Web.ViewModels.Users
{
    public class CreerModifierRole
    {
        public string Id { get; set; }
        [Required(ErrorMessage = "Le nom du role est obligatoire."), Display(Name = "Nom")]
        public string Name { get; set; }
    }
}
