using Microsoft.AspNetCore.Identity;

namespace MrPanchoRestaurant.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ICollection<Order>? Orders { get; set; }

    }
}
