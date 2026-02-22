using ecommerceAPI.Domain.Entities;

namespace ecommerceAPI.Interfaces.Reposatories
{
    public interface ICartRepo
    {
        public Task<IEnumerable<Cart>> GetAllCartsAsync();
        public Task AddAsync(Cart product);
        public void Update(Cart product);
        public bool Delete(Cart product);
        public Cart GetById(int id);
    }
}
