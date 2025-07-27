using ApplicationCore.Entities.Collectes;
using ApplicationCore.Interfaces.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using SGDS_Web.ViewModels;
using System.Threading.Tasks;

namespace SGDS_Web.Controllers
{
    public class DonneurController : Controller
    {
        private readonly IDonneurService _donneurService;
        public DonneurController(IDonneurService donneurService)
        {
            _donneurService = donneurService;
        }
        // GET: DonneurController
        public async Task<IActionResult> Index()
        {
            var donneurs = await _donneurService.GetAllDonneursAsync();
            var donneurvms = donneurs.Select(vm => new DonneurVM
            {
                Id = vm.Id,
                CIN = vm.CIN,
                NIF = vm.NIF,
                Nom = vm.Nom,
                Prenom = vm.Prenom,
                Sexe = vm.Sexe,
                GroupeSanguin = vm.GroupeSanguin,
                DateNaissance = vm.DateNaissance,
                StatutMatrimonial = vm.StatutMatrimonial,
                Occupation = vm.Occupation,
                Adresse = vm.Adresse,
                Telephone = vm.Telephone,
                Email = vm.Email,
            });
            return View(donneurvms);
        }

        // GET: DonneurController/Details/5
        public async Task<IActionResult> Details(long id)
        {
            return View(await _donneurService.GetDonneurByIdAsync(id));
        }

        // GET: DonneurController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DonneurController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DonneurVM vm)
        {
            try
            {
                if (ModelState.IsValid) 
                {
                    var donneur = new Donneur 
                    {
                        CIN = vm.CIN,
                        NIF = vm.NIF,
                        Nom = vm.Nom,
                        Prenom = vm.Prenom,
                        Sexe = vm.Sexe,
                        GroupeSanguin = vm.GroupeSanguin,
                        DateNaissance = vm.DateNaissance,
                        StatutMatrimonial = vm.StatutMatrimonial,
                        Occupation = vm.Occupation,
                        Adresse = vm.Adresse,
                        Telephone = vm.Telephone,
                        Email = vm.Email,
                    };
                    await _donneurService.AddDonneurAsync(donneur);
                    return RedirectToAction(nameof(Index));
                }
            }
            catch
            {
                return View();
            }

            return View(vm);
        }

        // GET: DonneurController/Edit/5
        public async Task<IActionResult> Edit(long id)
        {
            var donneur = await _donneurService.GetDonneurByIdAsync(id);
            return View(new DonneurVM
            {
                Id = donneur.Id,
                CIN = donneur.CIN,
                NIF = donneur.NIF,
                Nom = donneur.Nom,
                Prenom = donneur.Prenom,
                Sexe = donneur.Sexe,
                GroupeSanguin = donneur.GroupeSanguin,
                DateNaissance = donneur.DateNaissance,
                StatutMatrimonial = donneur.StatutMatrimonial,
                Occupation = donneur.Occupation,
                Adresse = donneur.Adresse,
                Telephone = donneur.Telephone,
                Email = donneur.Email,
            });
        }

        // POST: DonneurController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(DonneurVM vm)
        {
            try
            {
                if (ModelState.IsValid) 
                {
                    var donneur = await _donneurService.GetDonneurByIdAsync(vm.Id);
                    //donneur.Id = vm.Id;
                    donneur.CIN = vm.CIN;
                    donneur.NIF = vm.NIF;
                    donneur.Nom = vm.Nom;
                    donneur.Prenom = vm.Prenom;
                    donneur.Sexe =  vm.Sexe;
                    donneur.GroupeSanguin = vm.GroupeSanguin;
                    donneur.DateNaissance = vm.DateNaissance;
                    donneur.StatutMatrimonial = vm.StatutMatrimonial;
                    donneur.Occupation = vm.Occupation;
                    donneur.Adresse = vm.Adresse;
                    donneur.Telephone = vm.Telephone;
                    donneur.Email = vm.Email;

                    await _donneurService.UpdateDonneurAsync(donneur);
                    return RedirectToAction(nameof(Details), new { vm.Id });
                }
            }
            catch
            {
                return View();
            }

            return View(vm);
        }

        // GET: DonneurController/Delete/5
        public async Task<IActionResult> Delete(long id)
        {
            var donneur = await _donneurService.GetDonneurByIdAsync(id);
            return View(new DonneurVM
            {
                Id = donneur.Id,
                CIN = donneur.CIN,
                NIF = donneur.NIF,
                Nom = donneur.Nom,
                Prenom = donneur.Prenom,
                Sexe = donneur.Sexe,
                GroupeSanguin = donneur.GroupeSanguin,
                DateNaissance = donneur.DateNaissance,
                StatutMatrimonial = donneur.StatutMatrimonial,
                Occupation = donneur.Occupation,
                Adresse = donneur.Adresse,
                Telephone = donneur.Telephone,
                Email = donneur.Email,
            });
        }

        // POST: DonneurController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(long id, bool notUsed)
        {
            try
            {
                var donneur = await _donneurService.GetDonneurByIdAsync(id);
                if (donneur != null) 
                {
                    await _donneurService.DeleteDonneurAsync(donneur);
                    return RedirectToAction(nameof(Index));
                }
            }
            catch
            {
                return View();
            }

            return RedirectToAction(nameof(Delete), new { id });
        }
    }
}
