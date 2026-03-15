using ecommerceAPI.Domain;
using ecommerceAPI.Domain.Entities;
using ecommerceAPI.Interfaces.Reposatories;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ecommerceAPI.Infrastructure.Reposatories
{
    public class CartRepo : ICartRepo
    {
        private readonly MyDBContext context;
        public CartRepo(MyDBContext context)
        {
            this.context = context;
        }
        public async Task<bool> AddAsync(Cart cart)
        {
            var success= await context.Carts.AddAsync(cart);
            if (success == null)
                return false;
            return true;
        }
        public Cart GetByUserId(string id)=>context.Carts.FirstOrDefault(c => c.UserId == id);
        public async Task<IEnumerable<Cart>> GetAllCartsAsync()
        {
            return await context.Carts.ToListAsync();
        }
        public bool Delete(Cart cart)
        {
            context.Carts.Remove(cart);
            return true;
        }
        //public bool Update(Cart Cart)
        //{
        //    var cart = context.Carts.FirstOrDefault(a=> a.Id == Cart.Id);
        //    if (cart == null)
        //        return false;
        //    cart.CartItems = Cart.CartItems; 
        //    //ازاي هتتعدل من غير ما ال cartitems تتعدل.
        //    context.SaveChanges();
        //    return true;
        //}
    }
}
