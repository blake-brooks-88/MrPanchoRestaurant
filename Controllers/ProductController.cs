using Microsoft.AspNetCore.Mvc;
using MrPanchoRestaurant.Data;
using MrPanchoRestaurant.Models;

namespace MrPanchoRestaurant.Controllers
{
    public class ProductController : Controller
    {
        private Repository<Product> products;
        private Repository<Ingredient> ingredients;

        public ProductController(ApplicationDbContext context)
        {
            products = new Repository<Product>(context);
            ingredients = new Repository<Ingredient>(context); ;
        }

        public async Task<IActionResult> Index()
        {
            return View(await products.GetAllAsync());

        }

        [HttpGet]
        public async Task<IActionResult> AddEdit(int id)
        {
            ViewBag.Ingredients = await ingredients.GetAllAsync();
            if (id == 0)
            {
                ViewBag.Operation = "Add";
                return View(new Product());
            }
            else
            {
                ViewBag.Operation = "Edit";
                return View();
            }
        }
    }
}
