using twitter_api.Models;

namespace twitter_api.Interfaces
{
    public interface ICloudinaryService
    {
        Task<Image> UploadImage(string imageData);
    }
}
