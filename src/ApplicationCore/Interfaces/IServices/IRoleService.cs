using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces.IServices
{
    public interface IRoleService
    {
        // Role management methods
        Task<IEnumerable<DomainRole>> GetAllRolesAsync();
        Task<DomainRole> GetRoleByIdAsync(string roleId);
        Task<bool> IsInRoleAsync(DomainUser user, string roleId);
        Task CreateRoleAsync(string role);
        Task UpdateRoleAsync(string role);
        Task DeleteRoleAsync(string id);
        Task AssignRoleAsync(DomainUser user, string role);
        Task RemoveRoleAsync(DomainUser user, string role);
        Task AssignRoleToUsersAsync(IEnumerable<DomainUser> users, string role);
        Task RemoveUsersFromRoleAsync(IEnumerable<DomainUser> users, string role);
    }
}
