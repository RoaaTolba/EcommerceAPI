using System.Web.Http.Controllers;

namespace ecommerceAPI.Interfaces.Reposatories
{
    public interface ICartItemRepo
    {
        public Task AddItem(int cartItemId, int productId , int quantity);
        public Task<bool> RemoveItem(int cartItemId);
        public bool GetItem(int cartId, int productId);
        public Task<bool> UpdateItemQuantity(int cartItemId, int newQuantity);
        

    }
}
