using ApplicationCore.Entities.Users;
using ApplicationCore.Interfaces.IServices;
using ApplicationCore.Static;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SGDS_Web.ViewModels.Users;

namespace SGDS_Web.Controllers
{
    [Authorize(Policy = Policies.AdminManager)]
    public class UsersController : Controller
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public UsersController(
            IUserService userService,
            IMapper mapper
        )
        {
            _userService = userService;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var users = await _userService.GetAllUsersAsync();
            var vm = _mapper.Map<List<UserVM>>(users);
            return View(vm);
        }

        // GET: UsersController/Details/5
        public async Task<IActionResult> Details(string Id)
        {
            var user = await _userService.GetUserByIdAsync(Id);
            return View(_mapper.Map<UserVM>(user));
        }

        // GET: UsersController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UsersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(IFormCollection collection)
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

        // GET: UsersController/Edit/5
        public async Task<IActionResult> Edit(string Id)
        {
            var user = await _userService.GetUserByIdAsync(Id);
            return View(_mapper.Map<EditUserVM>(user));
        }

        // POST: UsersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditUserVM vm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var domainUser = _mapper.Map<DomainUser>(vm);
                    await _userService.UpdateUserAsync(domainUser);
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex)
            {
                vm.error = ex.Message;
            }

            return View(vm);
        }

        [Authorize(Policy = Policies.AdminOnly)]
        // GET: UsersController/Delete/5
        public async Task<IActionResult> Delete(string Id)
        {
            try 
            {
                var user = await _userService.GetUserByIdAsync(Id);
                var vm = _mapper.Map<UserVM>(user);
                return View(vm);
            } catch (Exception ex)
            {
                return View();
            }
        }

        [Authorize(Policy = Policies.AdminOnly)]
        // POST: UsersController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(string Id, bool notused)
        {
            try
            {
                await _userService.DeleteUserAsync(Id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
