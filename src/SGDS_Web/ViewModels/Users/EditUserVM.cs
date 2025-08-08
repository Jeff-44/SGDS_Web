using Microsoft.AspNetCore.Mvc;

namespace SGDS_Web.ViewModels.Users
{
    public class EditUserVM
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
        public string? ProfilePictureUrl { get; set; }

        public string? succes { get; set; }
        public string? error { get; set; }
    }
}
