using ecommerceAPI.Domain.Entities;

namespace ecommerceAPI.Interfaces.Reposatories
{
    public interface IUserRepo
    {
        public Task<IEnumerable<User>> GetAllUsersAsync();
        public Task<User> GetByIdAsync(int id);
    }
}
