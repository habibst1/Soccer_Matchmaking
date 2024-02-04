using Microsoft.AspNetCore.Hosting;
using System;
using System.IO;

public class ImageHelper
{
    private readonly IWebHostEnvironment _webHostEnvironment;

    public ImageHelper(IWebHostEnvironment webHostEnvironment)
    {
        _webHostEnvironment = webHostEnvironment;
    }

    public string SaveStadiumPhoto(IFormFile photo)
    {
            if (photo == null || photo.Length == 0)
            {
                return null;
            }

            // Generate a unique filename to avoid overwriting existing files
            string uniqueFileName = Guid.NewGuid().ToString() + "_" + photo.FileName;

            // Combine the web root path and the profiles folder to get the full path
            string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "images", uniqueFileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                photo.CopyTo(fileStream);
            }

            return uniqueFileName;
     } 
    

        public string SaveProfilePhoto(IFormFile photo)
        {
        if (photo == null || photo.Length == 0)
        {
            return null;
        }

        // Generate a unique filename to avoid overwriting existing files
        string uniqueFileName = Guid.NewGuid().ToString() + "_" + photo.FileName;

        // Combine the web root path and the profiles folder to get the full path
        string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "images", uniqueFileName);

        using (var fileStream = new FileStream(filePath, FileMode.Create))
        {
            photo.CopyTo(fileStream);
        }

        return uniqueFileName;
    }


}
