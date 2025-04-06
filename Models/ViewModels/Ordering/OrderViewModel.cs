using MrPanchoRestaurant.Models.Entities.Menu;

namespace MrPanchoRestaurant.Models.ViewModels.Ordering
{
    public class OrderViewModel
    {
        public decimal TotalAmount { get; set; }
        public List<OrderItemViewModel> OrderItems { get; set; }
        public IEnumerable<Product> Products { get; set; }
    }
}
