using ecommerceAPI.Domain;
using ecommerceAPI.Domain.Entities;
using ecommerceAPI.Interfaces.Reposatories;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ecommerceAPI.Infrastructure.Reposatories
{
    public class ProductRepo : IProductRepo
    {
        private readonly MyDBContext _context;
        public ProductRepo(MyDBContext context) { _context = context; }
        public Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            throw new NotImplementedException();
        }
        public async Task AddAsync(Product product)
        {
            //Product newproduct = new Product()
            //{
            //    Name = product.Name,
            //    CategoryId=product.CategoryId,
            //    ImageUrl = product.ImageUrl,
            //    Stock = product.Stock,
            //    Price = product.Price,
            //    Description = product.Description,
            //    productStatus = product.productStatus,
            //    CreatedAt = DateTime.Now
            //};
            await _context.AddAsync(product);
            
            
        }
        public void Update(int id,Product product)
        {
            //var preProduct = await _context.Products.FindAsync(id);
            //if (preProduct == null)
            //    return false;

            //preProduct.TotalPrice= product.Price;


            //return true;
        }
        public async Task<bool> Delete(int id)
        {
            var product = await _context.Products.FindAsync(id);

            if (product == null)
                return false;

            _context.Products.Remove(product);
            return true;
        }
        public async Task GetByIdAsync(int id)
        {
            await _context.Products.FindAsync(id);
        }
 
    }
}
