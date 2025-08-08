using ApplicationCore.Entities.Users;
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
        public async Task AssignRoleToUsersAsync(IEnumerable<string> userIds, string role)
        {
            var appUsers = await _userManager.Users.Where(u => userIds.Contains(u.Id)).ToListAsync();
            foreach (var user in appUsers)
            {
                bool userIsInRole = await _userManager.IsInRoleAsync(user, role);
                if (!userIsInRole)
                {
                    await _userManager.AddToRoleAsync(user, role);
                }
            }
        }

        public async Task RemoveUsersFromRoleAsync(IEnumerable<string> userIds, string role)
        {
            var appUsers = await _userManager.Users.Where(u => userIds.Contains(u.Id)).ToListAsync();
            foreach (var user in appUsers)
            {
                bool userIsInRole = await _userManager.IsInRoleAsync(user, role);
                if (userIsInRole)
                {
                    await _userManager.RemoveFromRoleAsync(user, role);
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

        private async Task<IdentityRole> GetByIdAsync(string roleId)
        {
            var role = await _roleManager.FindByIdAsync(roleId)
                ?? throw new KeyNotFoundException($"Role ID {roleId} introuvable.");
            return role;
        }
        public async Task<DomainRole> GetRoleByIdAsync(string roleId)
        {
            var role = await GetByIdAsync(roleId);
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

        public async Task UpdateRoleAsync(DomainRole role)
        {
            var identityRole = await GetByIdAsync(role.Id);
            identityRole.Name = role.Name;
            var result = await _roleManager.UpdateAsync(identityRole);
            if (!result.Succeeded) 
            {
                throw new Exception($"Erreur lors de la mise à jour du rôle {role.Name}: " +
                    $"{string.Join(", ", result.Errors.Select(error => error.Description))}");
            }
        }

        public async Task DeleteRoleAsync(string id)
        {
            await _roleManager.DeleteAsync(await _roleManager.FindByIdAsync(id)
                ?? throw new KeyNotFoundException($"Role ID {id} introuvable."));
        }

        public async Task<DomainRole> GetRoleByNameAsync(string role)
        {
            var identityRole = await _roleManager.FindByNameAsync(role)
                ?? throw new Exception($"Role :{role} introuvable.");

            return _mapper.Map<DomainRole>(identityRole);
        }
    }
}
