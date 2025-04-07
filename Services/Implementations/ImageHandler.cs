using Microsoft.AspNetCore.Hosting;
using MrPanchoRestaurant.Models.Entities.Menu;
using MrPanchoRestaurant.Services.Interfaces;

namespace MrPanchoRestaurant.Services.Implementations
{
    public class ImageHandler : IImageHandler
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ImageHandler(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }
        public async Task<string> SaveImageAsync(IFormFile imageFile)
        {
            string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images");
            string uniqueFileName = Guid.NewGuid().ToString()
                + "_"
                + imageFile.FileName;
            string filePath = Path.Combine(uploadsFolder, uniqueFileName);
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await imageFile.CopyToAsync(fileStream);
            }

            return uniqueFileName;
        }
    }
}
