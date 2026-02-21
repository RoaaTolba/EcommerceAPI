using ecommerceAPI.Domain.Enums;
using Microsoft.AspNetCore.Identity;

namespace ecommerceAPI.Domain.Entities
{
    public class User: IdentityUser
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public ICollection<Order> Orders { get; set; }

    }
}
