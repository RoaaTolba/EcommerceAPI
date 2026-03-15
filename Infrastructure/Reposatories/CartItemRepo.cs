using ecommerceAPI.Domain;
using ecommerceAPI.Domain.Entities;
using ecommerceAPI.Interfaces.Reposatories;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ecommerceAPI.Infrastructure.Reposatories
{
    public class CartItemRepo : ICartItemRepo
    {
        private readonly MyDBContext context;
        public CartItemRepo(MyDBContext context)
        {
            this.context = context;
        }
        public bool GetItem(int cartId, int productId)
        {
            var product = context.CartItems.FirstOrDefault(c => c.Id == productId && c.CartId==cartId);
            if (product == null)
                return false;
            return true;
        }
        public async Task<bool> RemoveItem(int cartItemId)
        {
            var cartItem = await context.CartItems.FindAsync(cartItemId);
            if (cartItem != null)
            {
                 context.CartItems.Remove(cartItem);
                return true;
            }
            return false;
        }
        public async Task AddItem(int cartItemId, int productId, int quantity)
        {
            var cartItem = await context.CartItems.FirstOrDefaultAsync(c => c.Id == cartItemId && c.ProductId==productId);
            if (cartItem != null)
            {
                UpdateItemQuantity(cartItemId, quantity);
            }
            else
            {
                var newCartItem = new CartItem
                {
                    CartId = cartItemId,
                    ProductId = productId,
                    Quantity = quantity
                };
                await context.CartItems.AddAsync(newCartItem);
            }
        }
        public async Task<bool> UpdateItemQuantity(int cartItemId, int newQuantity)
        {
            var cartItem = await context.CartItems.FindAsync(cartItemId);
            if (cartItem == null)
                return false;

            cartItem.Quantity = newQuantity;
            return true;


        }
    }
}
