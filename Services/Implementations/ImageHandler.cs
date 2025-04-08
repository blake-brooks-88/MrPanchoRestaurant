using Microsoft.AspNetCore.Hosting;
using MrPanchoRestaurant.Models.Entities.Menu;
using MrPanchoRestaurant.Services.Interfaces;

namespace MrPanchoRestaurant.Services.Implementations
{
    public class ImageHandler : IImageHandler
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly string _imageFolderName = "images";

        public ImageHandler(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }
        public async Task<string> SaveImageAsync(IFormFile imageFile)
        {
            string uploadsFolder = GetImageUploadsFolder();
            string uniqueFileName = GenerateUniqueFileName(imageFile.FileName);
            string filePath = Path.Combine(uploadsFolder, uniqueFileName);
            
            await SaveUploadedFileAsync(imageFile, filePath);

            return uniqueFileName;
        }

        private string GetImageUploadsFolder()
        {
            return Path.Combine(_webHostEnvironment.WebRootPath, _imageFolderName);
        }

        private string GenerateUniqueFileName(string fileName)
        {
            return Guid.NewGuid().ToString()
                + "_"
                + fileName;
        }

        private async Task SaveUploadedFileAsync(IFormFile imageFile, string filePath)
        {
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await imageFile.CopyToAsync(fileStream);
            }
        } 
    }
}
