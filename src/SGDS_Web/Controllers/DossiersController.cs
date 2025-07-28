using ApplicationCore.Entities.Collectes;
using ApplicationCore.Interfaces.IServices;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SGDS_Web.ViewModels;

namespace SGDS_Web.Controllers
{
    public class DossiersController : Controller
    {
        private readonly IDossierService _dossierService;
        private readonly IMapper _mapper;
        public DossiersController(IDossierService dossierService, IMapper mapper)
        {
            _dossierService = dossierService;
            _mapper = mapper;
        }
        // GET: DossiersController
        public async Task<IActionResult> Index()
        {
            var dossiers = await _dossierService.GetAllAsync();
            var dossiervms = _mapper.Map<List<DossierVM>>(dossiers);
            return View(dossiervms);
        }

        // GET: DossiersController/Details/5
        public async Task<IActionResult> Details(long id)
        {
            var dossier = await _dossierService.GetByIdAsync(id);
            var dossiervm = _mapper.Map<DossierVM>(dossier);
            return View(dossiervm);
        }

        // GET: DossiersController/Create
        public IActionResult Create(long donneurId, string? CIN, string? NIF)
        {
            var vm = new DossierVM { DonneurId = donneurId, Donneur = new Donneur { Id = donneurId, CIN = CIN ?? "", NIF = NIF ?? "" } };
            return View(vm);
        }

        // POST: DossiersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DossierVM vm)
        {
            try
            {
                if (ModelState.IsValid) 
                {
                    var dossier = _mapper.Map<Dossier>(vm);
                    await _dossierService.AddAsync(dossier);
                    return RedirectToAction(nameof(Index));
                }
            }
            catch
            {
                return View();
            }
            return View(vm);
        }

        // GET: DossiersController/Edit/5
        public async Task<IActionResult> Edit(long id)
        {
            var dossier = await _dossierService.GetByIdAsync(id);
            var dossiervm = _mapper.Map<DossierVM>(dossier);
            return View(dossiervm);
        }

        // POST: DossiersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(DossierVM vm)
        {
            try
            {
                if (ModelState.IsValid) 
                {
                    var dossier = await _dossierService.GetByIdAsync(vm.Id);
                    dossier = _mapper.Map<Dossier>(vm);
                    await _dossierService.UpdateAsync(dossier);
                    return RedirectToAction(nameof(Details), new { vm.Id });
                }
            }
            catch
            {
                return View();
            }
            return View(vm);
        }

        // GET: DossiersController/Delete/5
        public async Task<IActionResult> Delete(long id)
        {
            var dossier = await _dossierService.GetByIdAsync(id);
            if (dossier != null)
            {
                var vm = _mapper.Map<DossierVM>(dossier);
                return View(vm);
            }
            return RedirectToAction(nameof(Index));
        }

        // POST: DossiersController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(DossierVM vm)
        {
            try
            {
                var dossier = await _dossierService.GetByIdAsync(vm.Id);
                if (dossier != null) 
                {
                    await _dossierService.DeleteAsync(dossier);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
