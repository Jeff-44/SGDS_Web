using ApplicationCore.Entities.Collectes;
using ApplicationCore.Interfaces.IServices;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SGDS_Web.ViewModels;

namespace SGDS_Web.Controllers
{
    public class CollectesController : Controller
    {
        private readonly ICollecteService _collecteService;
        private readonly IMapper _mapper;
        public CollectesController(ICollecteService collecteService, IMapper mapper)
        {
            _collecteService = collecteService;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var collectes = await _collecteService.GetAllAsync();
            var collectevms = _mapper.Map<List<CollecteVM>>(collectes);
            return View(collectevms);
        }

        // GET: CollectesController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var collecte = await _collecteService.GetByIdAsync(id);
            var collectevm = _mapper.Map<CollecteVM>(collecte);
            return View(collectevm);
        }

        // GET: CollectesController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CollectesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CollecteVM vm)
        {
            try
            {
                if (ModelState.IsValid) 
                {
                    var collecte = _mapper.Map<Collecte>(vm);
                    await _collecteService.AddAsync(collecte);
                    return RedirectToAction(nameof(Index));
                }
            }
            catch
            {
                return View();
            }
            return View(vm);
        }

        // GET: CollectesController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var collecte = await _collecteService.GetByIdAsync(id);
            if (collecte == null)
            {
                return NotFound();
            }
            var collectevm = _mapper.Map<CollecteVM>(collecte);
            return View(collectevm);
        }

        // POST: CollectesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(CollecteVM vm)
        {
            try
            {
                if(ModelState.IsValid) 
                {
                    var collecte = await _collecteService.GetByIdAsync(vm.Id) ?? throw new KeyNotFoundException("Collecte not found");
                    collecte = _mapper.Map<Collecte>(vm);
                    await _collecteService.UpdateAsync(collecte);
                    return RedirectToAction(nameof(Details), new { vm.Id });
                }
            }
            catch
            {
                return View();
            }
            return View(vm);
        }

        // GET: CollectesController/Delete/5
        public async Task<IActionResult> Delete(long id)
        {
            var collecte = await _collecteService.GetByIdAsync(id);
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
