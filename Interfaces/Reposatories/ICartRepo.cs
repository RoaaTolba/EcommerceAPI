using ecommerceAPI.Domain.Entities;

namespace ecommerceAPI.Interfaces.Reposatories
{
    public interface ICartRepo
    {
        public Task<bool> AddAsync(Cart cart);
        public Cart GetByUserId(string id);
        public Task<IEnumerable<Cart>> GetAllCartsAsync();
        public bool Delete(Cart cart);
       // public bool Update(Cart Cart);
    }
}
