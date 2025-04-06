using Microsoft.AspNetCore.Mvc;
using MrPanchoRestaurant.Data;
using MrPanchoRestaurant.Models;

namespace MrPanchoRestaurant.Controllers
{
    public class ProductController : Controller
    {
        private Repository<Product> products;

        public ProductController(ApplicationDbContext context)
        {
            products = new Repository<Product>(context);
        }

        public async Task<IActionResult> Index()
        {
            return View(await products.GetAllAsync());

        }
    }
}
