using ecommerceAPI.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ecommerceAPI.Interfaces.Reposatories
{
    public interface IProductRepo
    {
        public Task<IEnumerable<Product>> GetAllProductsAsync();
        public Task AddAsync(Product product);
        public void Update(int id,Product product);
        public Task<bool> Delete(int id);
        public Task GetByIdAsync(int id);
    }
}
