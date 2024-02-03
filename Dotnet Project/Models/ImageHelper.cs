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

    public string SaveStadiumPhoto(string filePath)
    {
        if (string.IsNullOrEmpty(filePath))
        {
            return null;
        }

        // Generate a unique filename to avoid overwriting existing files
        string uniqueFileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(filePath);

        // Combine the web root path and the images folder to get the full path
        string destinationPath = Path.Combine(_webHostEnvironment.WebRootPath, "images", uniqueFileName);

        // Copy the file to the destination path
        File.Copy(filePath, destinationPath);

        return uniqueFileName;
    }
}
