using System.Security.Principal;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using twitter_api.Interfaces;
using twitter_api.Models;

namespace twitter_api.Service
{
    public class CloudinaryService : ICloudinaryService
    {
        //private readonly Cloudinary _cloudinary;

        //public CloudinaryService(IConfiguration configuration)
        //{
        //    Account cloudinaryAccount = new Account(
        //        configuration["Cloudinary:dcefbgyqb"],
        //        configuration["Cloudinary:711325842671174"],
        //        configuration["Cloudinary:D7AI02dW_OydFOO-cQ5ALgxzvsY"]);

        //    _cloudinary = new Cloudinary(cloudinaryAccount);
        //    _cloudinary.Api.Secure = true;
        //}

        public async Task<Image> UploadImage(string imageData)
        {
            return null;
            //if (string.IsNullOrEmpty(imageData))
            //{
            //    return null;
            //}

            //byte[] imageBytes = Convert.FromBase64String(imageData);

            //using (MemoryStream stream = new MemoryStream(imageBytes))
            //{
            //    var uploadParams = new ImageUploadParams
            //    {
            //        File = new FileDescription("image.jpg", stream),
            //        Transformation = new Transformation().Crop("limit").Width(100).Height(100)
            //    };

            //    var uploadResult = await _cloudinary.UploadAsync(uploadParams);

            //    return new Image
            //    {
            //        publicId = uploadResult.PublicId,
            //        Url = uploadResult.Url,
            //    };
            //}
        }


    }
}
