using Microsoft.AspNetCore.Mvc;

namespace MrPanchoRestaurant.Services.Interfaces
{
    public interface IImageHandler
    {
        Task<string> SaveImageAsync(IFormFile imageFile);
    }
}
