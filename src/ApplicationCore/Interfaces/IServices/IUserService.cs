using ApplicationCore.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces.IServices
{
    public interface IUserService
    {
        Task<DomainUser> GetUserByIdAsync(string userId);
        Task<IEnumerable<DomainUser>> GetAllUsersAsync();
        Task<IEnumerable<DomainUser>> GetUsersAsync(Expression<Func<DomainUser, bool>> predicate);
        Task<DomainUser> GetUserAsync(Expression<Func<DomainUser, bool>> predicate);
        Task DeleteUserAsync(string userId);
        Task UpdateUserAsync(DomainUser user);
    }
}
