using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Components.Forms;

namespace Naruto.Helpers
{
    public class Cloudinary_Manager
    {
        private Cloudinary cloudinary;
        string urlImage = string.Empty;

        public Cloudinary_Manager()
        {
            InitializeCloudinary();
        }

        private void InitializeCloudinary()
        {
            Account account = new Account(
                "erudito",
                "566427932946661",
                "TpG6QKEp7_uXkJQMYpjUVRn6mZs");

            cloudinary = new Cloudinary(account);
            cloudinary.Api.Secure = true;
        }

        public async Task<string> UploadImage(string folder, string nameImage)
        {
            var uploadParams = new ImageUploadParams()
            {
                Folder = folder,
                PublicId = nameImage,
                File = new FileDescription(urlImage)
            };

            var uploadResult = await cloudinary.UploadAsync(uploadParams);

            return uploadResult.SecureUrl.ToString();

        }

        public async Task<string> LoadImage(IBrowserFile file)
        {
            // leer el archivo la imagen y enviarla a la urlImage


            var format = "image/png";
            var imageFile = await file.RequestImageFileAsync(format, 1000, 1000);

            using (var memoryStream = new MemoryStream())
            {
                await imageFile.OpenReadStream().CopyToAsync(memoryStream);
                var fileBytes = memoryStream.ToArray();
                urlImage = $"data:{format};base64,{Convert.ToBase64String(fileBytes)}";
            }
            return urlImage;
        }

        public async Task<string> SelectImage(InputFileChangeEventArgs e)
        {
            var file = e.File;

            await LoadImage(file);

            using (var memoryStream = new MemoryStream())
            {
                await file.OpenReadStream().CopyToAsync(memoryStream);

                var fileBytes = memoryStream.ToArray();



                return $"data:image/png;base64,{Convert.ToBase64String(fileBytes)}";
            }
        }

        public async Task<bool> DeleteImage(string folder, string refImage)
        {

            var deleteParams = new DeletionParams(folder + "/" + refImage);
            var result = await cloudinary.DestroyAsync(deleteParams);
            return result.Result == "ok"
                ? true
                : false;
        }
    }
}