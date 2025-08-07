using ApplicationCore.Entities;
using ApplicationCore.Interfaces.IServices;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SGDS_Web.ViewModels.Users;

namespace SGDS_Web.Controllers
{
    public class RolesController : Controller
    {
        private readonly IUserService _userService;
        private readonly IRoleService _roleService;
        private readonly IMapper _mapper;
        public RolesController(
            IUserService userService,
            IRoleService roleService,
            IMapper mapper
        )
        {
            _userService = userService;
            _roleService = roleService;
            _mapper = mapper;
        }
        // GET: RolesController
        public async Task<IActionResult> Index()
        {
            var roles = await _roleService.GetAllRolesAsync();
            return View(_mapper.Map<List<RoleVM>>(roles));
        }

        // GET: RolesController/Details/5
        public async Task<IActionResult> Details(string id)
        {
            try 
            {
                var role = await _roleService.GetRoleByIdAsync(id);
                var members = await _userService.GetUsersAsync
                                (
                                    u => _roleService.IsInRoleAsync(u, role.Name).GetAwaiter().GetResult()
                                );
                var nonMembers = await _userService.GetUsersAsync
                                (
                                    u => !_roleService.IsInRoleAsync(u, role.Name).GetAwaiter().GetResult()
                                );
                var roleVM = _mapper.Map<RoleVM>(role);
                roleVM.Members = _mapper.Map<List<UserVM>>(members);
                roleVM.NonMembers = _mapper.Map<List<UserVM>>(nonMembers);

                return View(roleVM);
            } catch (Exception ex)
            {
                return View();
            }
            
        }

        // GET: RolesController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RolesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreerModifierRole vm)
        {
            try
            {
                await _roleService.CreateRoleAsync(vm.Name);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(vm);
            }
        }

        // GET: RolesController/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            var role = await _roleService.GetRoleByIdAsync(id);
            var vm = _mapper.Map<RoleVM>(role);
            return View(vm);
        }

        // POST: RolesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(CreerModifierRole vm)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    // Map the view model to the domain model
                    var role = _mapper.Map<DomainRole>(vm);
                    // Update the role
                    await _roleService.UpdateRoleAsync(role.Name);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(vm);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AssignRoleToUsers(IEnumerable<string> userIds, string role) 
        {
            try 
            {
                var users = await _userService.GetUsersAsync(u => userIds.Contains(u.Id));
                await _roleService.AssignRoleToUsersAsync(users, role);
            } catch
            { }
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RemoveUsersFromRole(IEnumerable<string> userIds, string role) 
        {
            try 
            {
                var users = await _userService.GetUsersAsync(u => userIds.Contains(u.Id));
                await _roleService.RemoveUsersFromRoleAsync(users, role);
            } catch
            { }
            return View();
        }

        // GET: RolesController/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            var role = await _roleService.GetRoleByIdAsync(id);
            return View(_mapper.Map<RoleVM>(role));
        }

        // POST: RolesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(string id, bool notused)
        {
            try
            {
                await _roleService.DeleteRoleAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
