using ecommerceAPI.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ecommerceAPI.Domain
{
    public class MyDBContext: IdentityDbContext<User>
    {
       public MyDBContext() :base() { }
        public MyDBContext(DbContextOptions options) : base(options) { }

        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Products { get; set; }
        //public DbSet<User> Users { get; set; }




    }
    
}
