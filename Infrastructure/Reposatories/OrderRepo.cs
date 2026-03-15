using ecommerceAPI.Domain;
using ecommerceAPI.Domain.Entities;
using ecommerceAPI.Interfaces.Reposatories;
using Microsoft.EntityFrameworkCore;

namespace ecommerceAPI.Infrastructure.Reposatories
{
    public class OrderRepo : IOrderRepo
    {
        private readonly MyDBContext context;
        public OrderRepo(MyDBContext _context) 
        {
            this.context = _context;            
        }
        public async Task<int> AddAsync(Order order)
        {
            await context.AddAsync(order);
            return context.SaveChanges();
        }

        public async Task<IEnumerable<Order>> GetAllOrdersAsync()
        {
            return await context.Orders.ToListAsync();
        }

        public async Task<Order> GetByIdAsync(int id)
        {
            return context.Orders.FirstOrDefault(a=> a.Id == id);
        }
    }
}
