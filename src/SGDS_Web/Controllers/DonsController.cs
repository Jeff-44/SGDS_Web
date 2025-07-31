using ApplicationCore.Entities.Collectes;
using ApplicationCore.Entities.Location;
using ApplicationCore.Interfaces.IServices;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SGDS_Web.ViewModels;

namespace SGDS_Web.Controllers
{
    public class DonsController : Controller
    {
        private readonly IDonService _donService;
        private readonly IMapper _mapper;
        public DonsController(IDonService donService, IMapper mapper)
        {
            _donService = donService;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var dons = await _donService.GetAllAsync();
            var donvms = _mapper.Map<List<DonVM>>(dons);
            return View(donvms);
        }

        // GET: donsController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var don = await _donService.GetByIdAsync(id);
            var donvm = _mapper.Map<DonVM>(don);
            return View(donvm);
        }

        // GET: donsController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: donsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DonVM vm)
        {
            try
            {
                if (ModelState.IsValid) 
                {
                    var don = _mapper.Map<Don>(vm);
                    await _donService.AddAsync(don);
                    return RedirectToAction(nameof(Index));
                }
            }
            catch
            {
                return View();
            }
            return View(vm);
        }

        // GET: donsController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var don = await _donService.GetByIdAsync(id);
            if (don == null)
            {
                return NotFound();
            }
            var donvm = _mapper.Map<DonVM>(don);
            return View(donvm);
        }

        // POST: donsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(DonVM vm)
        {
            try
            {
                if(ModelState.IsValid) 
                {
                    var don = await _donService.GetByIdAsync(vm.Id) ?? throw new KeyNotFoundException($"Don {vm.Id} not found");
                    don = _mapper.Map<Don>(vm);
                    await _donService.UpdateAsync(don);
                    return RedirectToAction(nameof(Details), new { vm.Id });
                }
            }
            catch
            {
                return View();
            }
            return View(vm);
        }

        // GET: donsController/Delete/5
        public async Task<IActionResult> Delete(long id)
        {
            var don = await _donService.GetByIdAsync(id);
            if (don == null)
            {
                return NotFound();
            }
            var donvm = _mapper.Map<DonVM>(don);
            return View(donvm);
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
