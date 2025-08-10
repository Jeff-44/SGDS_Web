using ApplicationCore.Entities.Location;
using ApplicationCore.Entities.Reference;
using ApplicationCore.Interfaces.IServices;
using ApplicationCore.Static;
using AutoMapper;
using Infrastructure.Implementations.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SGDS_Web.ViewModels;
using SGDS_Web.ViewModels.Centres;
using SGDS_Web.ViewModels.Reference;

namespace SGDS_Web.Controllers
{
    [Authorize(Policy = Policies.AdminManager)]
    public class CentresController : Controller
    {
        private readonly ICentreService _centreService;
        private readonly IMapper _mapper;
        private readonly ICommuneService _communeService;
        private readonly IDepartementService _departementService;
        private readonly IArrondissementService _arrondissementService;
        public CentresController(
            ICentreService centreService,
            ICommuneService communeService,
            IDepartementService departementService,
            IArrondissementService arrondissementService,
            IMapper mapper
        )
        {
            _centreService = centreService;
            _communeService = communeService;
            _arrondissementService = arrondissementService;
            _departementService = departementService;
            _mapper = mapper;
        }

        public async Task<IActionResult> GetArrodissementsAsync(int departementId) 
        {
            var result = await _arrondissementService.GetAsync(a => a.DepartementId == departementId);
            var arrondissements = result.Select(a => new
            {
                a.Id,
                a.Nom
            }).ToList();

            return Json(arrondissements);
        }

        public async Task<JsonResult> GetCommunesAsync(int arrondissementId)
        {
            var result = await _communeService.GetAsync(c => c.ArrondissementId == arrondissementId);
            var communes = result.Select(c => new 
            {
                c.Id,
                c.Nom
            }).ToList();
            return Json(communes);
        }

        public async Task<IActionResult> Index()
        {
            var centres = await _centreService.GetAllAsync();
            var centrevms = _mapper.Map<List<CentreVM>>(centres);
            return View(centrevms);
        }

        // GET: centresController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var centre = await _centreService.GetByIdAsync(id);
            var centrevm = _mapper.Map<CentreVM>(centre);
            return View(centrevm);
        }

        // GET: centresController/Create
        public async Task<IActionResult> Create()
        {
            var departements = await _departementService.GetAllAsync();
            var arrondissements = await _arrondissementService.GetAllAsync();
            var communes = await _communeService.GetAllAsync();

            var vm = new CreerModifierCentre
            {
                Departements = new SelectList(departements, "Id", "Nom"),
                Arrondissements = arrondissements
                                    .Select
                                        (
                                            a => new ArrondissementVM
                                            {
                                                Id = a.Id,
                                                Nom = a.Nom,
                                                DepartementId = a.DepartementId
                                            }
                                        ).ToList(),

                Communes = communes
                                .Select
                                    (
                                        c => new CommuneVM
                                        {
                                            Id = c.Id,
                                            Nom = c.Nom,
                                            ArrondissementId = c.ArrondissementId
                                        }
                                    ).ToList(),
            };
            return View(vm);
        }

        // POST: centresController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreerModifierCentre vm)
        {
            try
            {
                if (ModelState.IsValid) 
                {
                    var centre = _mapper.Map<Centre>(vm);
                    await _centreService.AddAsync(centre);
                    return RedirectToAction(nameof(Create));
                }
            }
            catch
            {
                var departements = await _departementService.GetAllAsync();
                var arrondissements =await _arrondissementService.GetAllAsync();
                var communes =await _communeService.GetAllAsync();
                vm.Departements = new SelectList(departements, "Id", "Nom", vm.DepartementId);
                vm.Arrondissements = arrondissements.Select(a => new ArrondissementVM { Id = a.Id, Nom = a.Nom, DepartementId = a.DepartementId }).ToList();
                vm.Communes = communes.Select(c => new CommuneVM { Id=c.Id, Nom=c.Nom, ArrondissementId=c.ArrondissementId }).ToList();
            }
            return View(vm);
        }

        // GET: centresController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var centre = await _centreService.GetByIdAsync(id);
            var departements = await _departementService.GetAllAsync();
            var arrondissements = await _arrondissementService.GetAllAsync();
            var communes = await _communeService.GetAllAsync();
            var vm = _mapper.Map<CreerModifierCentre>(centre);
            vm.Departements = new SelectList(departements, "Id", "Nom", vm.DepartementId);
            vm.Arrondissements = arrondissements.Select(a => new ArrondissementVM { Id = a.Id, Nom = a.Nom, DepartementId = a.DepartementId }).ToList();
            vm.Communes = communes.Select(c => new CommuneVM { Id = c.Id, Nom = c.Nom, ArrondissementId = c.ArrondissementId }).ToList();
            
            return View(vm);
        }

        // POST: centresController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(CreerModifierCentre vm)
        {
            try
            {
                if(ModelState.IsValid) 
                {
                    var centre = await _centreService.GetByIdAsync(vm.Id);
                    centre = _mapper.Map(vm, centre);
                    await _centreService.UpdateAsync(centre);
                    return RedirectToAction(nameof(Details), new { vm.Id });
                }
            }
            catch
            {
                var departements = await _departementService.GetAllAsync();
                var arrondissements = await _arrondissementService.GetAllAsync();
                var communes = await _communeService.GetAllAsync();
                vm.Departements = new SelectList(departements, "Id", "Nom", vm.DepartementId);
                vm.Arrondissements = arrondissements.Select(a => new ArrondissementVM { Id = a.Id, Nom = a.Nom, DepartementId = a.DepartementId }).ToList();
                vm.Communes = communes.Select(c => new CommuneVM { Id = c.Id, Nom = c.Nom, ArrondissementId = c.ArrondissementId }).ToList();
            }
            return View(vm);
        }
        [Authorize(Policy = Policies.AdminOnly)]
        // GET: centresController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var centre = await _centreService.GetByIdAsync(id);
            if (centre == null)
            {
                return NotFound();
            }
            var centrevm = _mapper.Map<CentreVM>(centre);
            return View(centrevm);
        }

        [Authorize(Policy = Policies.AdminOnly)]
        // POST: centresController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, bool? notused = null)
        {
            try
            {
                var centre = await _centreService.GetByIdAsync(id);
                if (centre == null)
                {
                    return NotFound();
                }
                await _centreService.DeleteAsync(centre);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
