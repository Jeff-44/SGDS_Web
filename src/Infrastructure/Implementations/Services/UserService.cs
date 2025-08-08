using ApplicationCore.Entities.Users;
using ApplicationCore.Interfaces.IServices;
using AutoMapper;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Infrastructure.Implementations.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;
        public UserService(
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,
            IMapper mapper
        )
        {
            _userManager = userManager;
            _mapper = mapper;
        }
        
        public async Task<DomainUser> GetUserAsync(Expression<Func<DomainUser, bool>> predicate)
        {
            //var users = await _userManager.Users.Where(predicate).FirstOrDefaultAsync()
            //         ?? throw new KeyNotFoundException("Utilisateur introuvable.");

            //return _mapper.Map<List<DomainUser>>(users);

            throw new NotImplementedException();
        }
        private async Task<ApplicationUser> GetByIdAsync(string id) 
        {
            var user = await _userManager.FindByIdAsync(id)
                   ?? throw new KeyNotFoundException($"Utilisateur ID {id} introuvable.");
            return user;
        }
        public async Task<DomainUser> GetUserByIdAsync(string userId)
        {
            var user = await GetByIdAsync(userId);
            return _mapper.Map<DomainUser>(user);
        }

        public async Task<IEnumerable<DomainUser>> GetAllUsersAsync()
        {
            var users = await _userManager.Users.ToListAsync();
            var domainuser = _mapper.Map<List<DomainUser>>(users);
            return domainuser;
        }

        public async Task<IEnumerable<DomainUser>> GetUsersAsync(Expression<Func<DomainUser, bool>> predicate)
        {
            var appUserPredicate = _mapper.Map<Expression<Func<ApplicationUser, bool>>>(predicate);
            var appUsers = await _userManager.Users
                .Where(appUserPredicate)
                .ToListAsync();
            return _mapper.Map<List<DomainUser>>(appUsers); 
        }
        
        public async Task UpdateUserAsync(DomainUser user)
        {
            var appUser = await GetByIdAsync(user.Id);

            _mapper.Map(user, appUser);
            if (appUser.UserName != user.Email)
            {
                var setEmailResult = await _userManager.SetUserNameAsync(appUser, user.Email);
                if (!setEmailResult.Succeeded)
                {
                    throw new Exception($"Erreur lors de la modification de l'email : {string.Join(", ", setEmailResult.Errors.Select(e => e.Description))}");
                }
            }

            var result = await _userManager.UpdateAsync(appUser);
            if (!result.Succeeded) 
            {
                throw new Exception($"Erreur lors de la modification de l'utilisateur: {string.Join(", ", result.Errors.Select(e => e.Description))}");
            }
        }

        public async Task DeleteUserAsync(string userId)
        {
            var user = await GetByIdAsync(userId);
            await _userManager.DeleteAsync(user);
        }  
    }
}
