using Microsoft.Extensions.Configuration;
using System;

namespace Przychodnia.Data.Images
{
    public class ImagesService : IImagesService
    {
        private readonly IConfiguration _configuration;
        private string ImagePath;
        public ImagesService(IConfiguration configuration)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            ImagePath = _configuration.GetSection("StaticFilesPath").Value.ToString();
        }
        

        public string GetImagesPath()
        {
            return ImagePath;
            
        }
    }
}