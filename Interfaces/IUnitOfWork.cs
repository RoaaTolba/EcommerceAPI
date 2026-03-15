using ecommerceAPI.Interfaces.Reposatories;

namespace ecommerceAPI.Interfaces
{
    public interface IUnitOfWork: IDisposable
    {
        IProductRepo Products {  get; }
        IUserRepo Users { get; }
        IOrderRepo Orders { get; }
        ICartRepo Carts { get; }
        ICartItemRepo CartItem { get; }
        Task<int> saveChangesAsync();
    }
}
