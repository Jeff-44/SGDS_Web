using ApplicationCore.Entities.Collectes;
using ApplicationCore.Interfaces.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SGDS_Web.ViewModels;

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
            return View(await _donneurService.GetAllDonneursAsync());
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
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DonneurController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DonneurController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DonneurController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
