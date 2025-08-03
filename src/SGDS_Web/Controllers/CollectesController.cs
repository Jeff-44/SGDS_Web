using ApplicationCore.Entities.Collectes;
using ApplicationCore.Interfaces.IServices;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SGDS_Web.ViewModels.Collectes;

namespace SGDS_Web.Controllers
{
    public class CollectesController : Controller
    {
        private readonly ICollecteService _collecteService;
        private readonly ICentreService _centreService;
        private readonly IMapper _mapper;
        public CollectesController(
            ICollecteService collecteService,
            ICentreService centreService,
            IMapper mapper)
        {
            _collecteService = collecteService;
            _centreService = centreService;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var collectes = await _collecteService.GetAllCollectesAsync();
            var collectevms = _mapper.Map<List<CollecteVM>>(collectes);
            return View(collectevms);
        }

        // GET: CollectesController/Details/5
        public async Task<IActionResult> Details(long id)
        {
            var collecte = await _collecteService.GetCollecteByIdAsync(id);
            var collectevm = _mapper.Map<CollecteVM>(collecte);
            return View(collectevm);
        }

        // GET: CollectesController/Create
        public async Task<IActionResult>  Create()
        {
            var centres = await _centreService.GetAllAsync();
            var vm = new CreerModifierCollecte
            {
                Centres = new SelectList(centres, "Id", "NomCentre")
            };
            return View(vm);
        }

        // POST: CollectesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreerModifierCollecte vm)
        {
            try
            {
                if (ModelState.IsValid) 
                {
                    var collecte = _mapper.Map<Collecte>(vm);
                    await _collecteService.AddAsync(collecte);
                    return RedirectToAction(nameof(Create));
                }
            }
            catch
            {
                var centres = await _centreService.GetAllAsync();
                vm.Centres = new SelectList(centres, "Id", "NomCentre");
            }
            return View(vm);
        }

        // GET: CollectesController/Edit/5
        public async Task<IActionResult> Edit(long id)
        {
            var collecte = await _collecteService.GetByIdAsync(id);
            var centres = await _centreService.GetAllAsync();
            
            var vm = _mapper.Map<CreerModifierCollecte>(collecte);
            vm.Centres = new SelectList(centres, "Id", "NomCentre");
            return View(vm);
        }

        // POST: CollectesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(CreerModifierCollecte vm)
        {
            try
            {
                if(ModelState.IsValid) 
                {
                    var collecte = await _collecteService.GetByIdAsync(vm.Id) ?? throw new KeyNotFoundException("Collecte not found");
                    collecte = _mapper.Map(vm, collecte);
                    await _collecteService.UpdateAsync(collecte);
                    return RedirectToAction(nameof(Details), new { vm.Id });
                }
            }
            catch
            {
                var centres = await _centreService.GetAllAsync();
                vm.Centres = new SelectList(centres, "Id", "NomCentre");
            }
            return View(vm);
        }

        // GET: CollectesController/Delete/5
        public async Task<IActionResult> Delete(long id)
        {
            var collecte = await _collecteService.GetCollecteByIdAsync(id);
            if (collecte == null)
            {
                return NotFound();
            }
            var collectevm = _mapper.Map<CollecteVM>(collecte);
            return View(collectevm);
        }

        // POST: CollectesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(long id, bool? notused = null)
        {
            try
            {
                var collecte = await _collecteService.GetByIdAsync(id);
                if (collecte == null)
                {
                    return NotFound();
                }
                await _collecteService.DeleteAsync(collecte);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
