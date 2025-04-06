using Microsoft.AspNetCore.Mvc;
using MrPanchoRestaurant.Models;

namespace MrPanchoRestaurant.Controllers
{
    public class ProductController : Controller
    {
        private Repository<Product> products;

        public ProductController(Repository<Product> products)
        {
            this.products = products;
        }

        public async Task<IActionResult> Index()
        {
            return View(await products.GetAllAsync());

        }
    }
}
