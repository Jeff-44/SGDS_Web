using ApplicationCore.Entities.Location;
using ApplicationCore.Interfaces.IServices;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SGDS_Web.ViewModels;

namespace SGDS_Web.Controllers
{
    public class CentresController : Controller
    {
        private readonly ICentreService _centreService;
        private readonly IMapper _mapper;
        public CentresController(ICentreService centreService, IMapper mapper)
        {
            _centreService = centreService;
            _mapper = mapper;
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
        public IActionResult Create()
        {
            return View();
        }

        // POST: centresController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CentreVM vm)
        {
            try
            {
                if (ModelState.IsValid) 
                {
                    var centre = _mapper.Map<Centre>(vm);
                    await _centreService.AddAsync(centre);
                    return RedirectToAction(nameof(Index));
                }
            }
            catch
            {
                return View();
            }
            return View(vm);
        }

        // GET: centresController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var centre = await _centreService.GetByIdAsync(id);
            if (centre == null)
            {
                return NotFound();
            }
            var centrevm = _mapper.Map<CentreVM>(centre);
            return View(centrevm);
        }

        // POST: centresController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(CentreVM vm)
        {
            try
            {
                if(ModelState.IsValid) 
                {
                    var centre = await _centreService.GetByIdAsync(vm.Id) ?? throw new KeyNotFoundException("centre not found");
                    centre = _mapper.Map<Centre>(vm);
                    await _centreService.UpdateAsync(centre);
                    return RedirectToAction(nameof(Details), new { vm.Id });
                }
            }
            catch
            {
                return View();
            }
            return View(vm);
        }

        // GET: centresController/Delete/5
        public async Task<IActionResult> Delete(long id)
        {
            var centre = await _centreService.GetByIdAsync(id);
            if (centre == null)
            {
                return NotFound();
            }
            var centrevm = _mapper.Map<CentreVM>(centre);
            return View(centrevm);
        }

        // POST: centresController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(long id, bool? notused = null)
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
