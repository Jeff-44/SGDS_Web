using ApplicationCore.Entities.Collectes;
using ApplicationCore.Interfaces.IServices;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using SGDS_Web.ViewModels.Donneurs;
using System.Threading.Tasks;

namespace SGDS_Web.Controllers
{
    public class DonneurController : Controller
    {
        private readonly IDonneurService _donneurService;
        private readonly IEligibilityService _eligibilityService;
        private readonly IMapper _mapper;
        public DonneurController(
                IDonneurService donneurService,
                IEligibilityService eligibilityService,
                IMapper mapper
            )
        {
            _donneurService = donneurService;
            _eligibilityService = eligibilityService;
            _mapper = mapper;
        }
        // GET: DonneurController
        public async Task<IActionResult> Index()
        {
            var donneurs = await _donneurService.GetAllDonneursAsync();
            await _eligibilityService.CheckEligibilityAsync(donneurs);
            var donneursList = _mapper.Map<List<DonneurVM>>(donneurs);
            return View(donneursList);
        }

        // GET: DonneurController/Details/5
        public async Task<IActionResult> Details(long id)
        {
            var donneur = await _donneurService.GetDonneurByIdAsync(id);
            await _eligibilityService.CheckEligibilityAsync(donneur);

            return View(_mapper.Map<DonneurVM>(donneur));
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
                    var donneur = _mapper.Map<Donneur>(vm);
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
            return View(_mapper.Map<DonneurVM>(donneur));
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
            return View(_mapper.Map<DonneurVM>(donneur));
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
