using Infrastructure.Settings;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using SGDS_Web.ViewModels;

namespace SGDS_Web.Controllers
{
    public class ContactController : Controller
    {
        private readonly IEmailSender _emailSender;
        private readonly EmailSettings _options;
        public ContactController(
            IEmailSender emailSender,
            IOptions<EmailSettings> options
        )
        {
            _emailSender = emailSender;
            _options = options.Value;

        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(ContactVM vm)
        {
            if (ModelState.IsValid)
            {
                // Send email
                await _emailSender.SendEmailAsync(
                    _options.From,
                    vm.Subject,
                    $"Nom: {vm.Name}\nEmail: {vm.Email}\nMessage: {vm.Message}"
                );

                TempData["SuccessMessage"] = "Votre message a été envoyé avec succès !";
                // Redirect to a confirmation page or display a success message
                return RedirectToAction(nameof(Index));
            }

            return View(vm);
        }
    }
}
