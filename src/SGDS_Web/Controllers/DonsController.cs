using ApplicationCore.Entities.Collectes;
using ApplicationCore.Entities.Location;
using ApplicationCore.Interfaces.IServices;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SGDS_Web.ViewModels.Dons;

namespace SGDS_Web.Controllers
{
    public class DonsController : Controller
    {
        private readonly IDonService _donService;
        private readonly IDonneurService _donneurService;
        private readonly ICollecteService _collecteService;
        private readonly IMapper _mapper;
        public DonsController(
            IDonService donService,
            IDonneurService donneurService,
            ICollecteService collecteService,
            IMapper mapper)
        {
            _donService = donService;
            _donneurService = donneurService;
            _collecteService = collecteService;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var dons = await _donService.GetAllDonsAsync();
            var donvms = _mapper.Map<List<DonVM>>(dons);
            return View(donvms);
        }

        // GET: donsController/Details/5
        public async Task<IActionResult> Details(long id)
        {
            var don = await _donService.GetDonByIdAsync(id);
            var vm = _mapper.Map<DonVM>(don);
            return View(vm);
        }

        // GET: donsController/Create
        public async Task<IActionResult> Create(long donneurId)
        {
            var today = DateOnly.FromDateTime(DateTime.Now);
            var donneurs = await _donneurService.GetAsync(donneur => donneur.EstEligible);
            var collecte = await _collecteService.GetAsync(collecte => collecte.DateCollecte == today);
            var vm = new CreerModifierDon
            {
                Donneurs = new SelectList(donneurs, "Id", "NIF"),
                Collectes = new SelectList(collecte, "Id", "Libelle"),
            };
            return View(vm);
        }

        // POST: donsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreerModifierDon vm)
        {
            try
            {
                if (ModelState.IsValid) 
                {
                    var don = _mapper.Map<Don>(vm);
                    await _donService.AddAsync(don);//s'assurer que le donneur est eligible avant d'ajouter un don pour ce donneur
                    return RedirectToAction(nameof(Index));
                }
            }
            catch
            {
                var today = DateOnly.FromDateTime(DateTime.Now);
                var donneurs = await _donneurService.GetAsync(donneur => donneur.EstEligible);
                var collecte = await _collecteService.GetAsync(collecte => collecte.DateCollecte == today);
                vm.Donneurs = new SelectList(donneurs, "Id", "NIF");
                vm.Collectes = new SelectList(collecte, "Id", "Libelle");
            }
            return View(vm);
        }

        // GET: donsController/Edit/5
        public async Task<IActionResult> Edit(long id)
        {
            var donneurs = await _donneurService.GetAsync(donneur => donneur.EstEligible);
            var collecte = await _collecteService.GetAllAsync();
            var don = await _donService.GetByIdAsync(id);
            var vm = _mapper.Map<CreerModifierDon>(don);
            vm.Donneurs = new SelectList(donneurs, "Id", "NIF");
            vm.Collectes = new SelectList(collecte, "Id", "Libelle");
            return View(vm);
        }

        // POST: donsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(CreerModifierDon vm)
        {
            try
            {
                if(ModelState.IsValid) 
                {
                    var don = await _donService.GetByIdAsync(vm.Id);
                    don = _mapper.Map(vm, don);
                    await _donService.UpdateAsync(don);
                    return RedirectToAction(nameof(Details), new { vm.Id });
                }
            }
            catch
            {
                var donneurs = await _donneurService.GetAllAsync();
                var collecte = await _collecteService.GetAllAsync();
                vm.Donneurs = new SelectList(donneurs, "Id", "NIF");
                vm.Collectes = new SelectList(collecte, "Id", "Libelle");
            }
            return View(vm);
        }

        // GET: donsController/Delete/5
        public async Task<IActionResult> Delete(long id)
        {
            var don = await _donService.GetDonByIdAsync(id);
            var vm = _mapper.Map<DonVM>(don);
            return View(vm);
        }

        // POST: donsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(long id, bool? notused = null)
        {
            try
            {
                var don = await _donService.GetByIdAsync(id);
                if (don == null)
                {
                    return NotFound();
                }
                await _donService.DeleteAsync(don);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
