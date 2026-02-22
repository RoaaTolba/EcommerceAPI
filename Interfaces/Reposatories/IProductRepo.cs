using ecommerceAPI.Domain.Entities;

namespace ecommerceAPI.Interfaces.Reposatories
{
    public interface IProductRepo
    {
        public Task<IEnumerable<Product>> GetAllProductsAsync();
        public Task AddAsync(Product product);
        public void Update(Product product);
        public bool Delete(Product product);
        public Task<Product> GetByIdAsync(int id);
    }
}
