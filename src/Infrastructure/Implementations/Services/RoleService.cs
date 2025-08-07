using ApplicationCore.Entities;
using ApplicationCore.Interfaces.IServices;
using AutoMapper;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Implementations.Services
{
    public class RoleService : IRoleService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IMapper _mapper;
        public RoleService(
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,
            IMapper mapper
        )
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _mapper = mapper;
        }

        public async Task AssignRoleAsync(DomainUser user, string role)
        {
            if (await _roleManager.RoleExistsAsync(role))
            {
                if (user != null && !(await _userManager.IsInRoleAsync(_mapper.Map<ApplicationUser>(user), role)))
                {
                    await _userManager.AddToRoleAsync(_mapper.Map<ApplicationUser>(user), role);
                }
            }
        }
        public async Task RemoveRoleAsync(DomainUser user, string role)
        {
            if (await _roleManager.RoleExistsAsync(role))
            {
                if (user != null && (await IsInRoleAsync(user, role)))
                {
                    await _userManager.RemoveFromRoleAsync(_mapper.Map<ApplicationUser>(user), role);
                }
            }
        }
        public async Task AssignRoleToUsersAsync(IEnumerable<DomainUser> users, string role)
        {
            if (await _roleManager.RoleExistsAsync(role)) 
            {
                foreach (var user in users)
                {
                    bool userIsInRole = await _userManager.IsInRoleAsync(_mapper.Map<ApplicationUser>(user), role);
                    if (!userIsInRole)
                    {
                        await _userManager.AddToRoleAsync(_mapper.Map<ApplicationUser>(user), role);
                    }
                }
            }
        }

        public async Task RemoveUsersFromRoleAsync(IEnumerable<DomainUser> users, string role)
        {
            if (await _roleManager.RoleExistsAsync(role))
            {
                foreach (var user in users)
                {
                    bool userIsInRole = await _userManager.IsInRoleAsync(_mapper.Map<ApplicationUser>(user), role);
                    if (userIsInRole)
                    {
                        await _userManager.RemoveFromRoleAsync(_mapper.Map<ApplicationUser>(user), role);
                    }
                }
            }
        }

        public async Task<bool> IsInRoleAsync(DomainUser user, string role)
        {
            return await _userManager.IsInRoleAsync(_mapper.Map<ApplicationUser>(user), role);
        }

        public async Task<IEnumerable<DomainRole>> GetAllRolesAsync()
        {
            var roles = await _roleManager.Roles.ToListAsync();
            var domainRoles = _mapper.Map<List<DomainRole>>(roles);
            return domainRoles;
        }

        public async Task<DomainRole> GetRoleByIdAsync(string roleId)
        {
            var role = await _roleManager.Roles.FirstOrDefaultAsync(role => role.Id == roleId)
                ?? throw new KeyNotFoundException($"Role ID {roleId} introuvable.");
            var domainRole = _mapper.Map<DomainRole>(role);
            return domainRole;
        }

        public async Task CreateRoleAsync(string role)
        {
            if (await _roleManager.RoleExistsAsync(role)) 
            {
                throw new Exception($"Role {role} existe déjà.");
            }
            await _roleManager.CreateAsync(new IdentityRole(role));
        }

        public async Task UpdateRoleAsync(string role)
        {
            var existingRole = await _roleManager.FindByNameAsync(role)
                ?? throw new KeyNotFoundException($"Role {role} introuvable.");
            existingRole.Name = role;
            await _roleManager.UpdateAsync(existingRole);
        }

        public async Task DeleteRoleAsync(string id)
        {
            await _roleManager.DeleteAsync(await _roleManager.FindByIdAsync(id)
                ?? throw new KeyNotFoundException($"Role ID {id} introuvable."));
        }
    }
}
