using ecommerceAPI.Domain.Entities;

namespace ecommerceAPI.Interfaces.Reposatories
{
    public interface IOrderRepo
    {
        public Task<IEnumerable<Order>> GetAllOrdersAsync();
        public Task<int> AddAsync(Order order);
        public Task<Order> GetByIdAsync(int id);
    }
}
