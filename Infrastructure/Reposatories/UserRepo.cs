using ecommerceAPI.Domain;
using ecommerceAPI.Domain.Entities;
using ecommerceAPI.Interfaces.Reposatories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ecommerceAPI.Infrastructure.Reposatories
{
    public class UserRepo : IUserRepo
    {
        private MyDBContext _dbContext;
        private UserManager<User> _userManager;
        public UserRepo(MyDBContext context,UserManager<User> userManager)
        {
            _dbContext = context;
            _userManager= userManager;
        }
        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
           List<User> users= await _userManager.Users.ToListAsync();
            return users;
        }

        public async Task<User> GetByIdAsync(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            return user;
        }
    }
}
