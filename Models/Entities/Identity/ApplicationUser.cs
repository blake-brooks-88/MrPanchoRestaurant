using Microsoft.AspNetCore.Identity;
using MrPanchoRestaurant.Models.Entities.Ordering;

namespace MrPanchoRestaurant.Models.Entities.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public ICollection<Order>? Orders { get; set; }

    }
}
