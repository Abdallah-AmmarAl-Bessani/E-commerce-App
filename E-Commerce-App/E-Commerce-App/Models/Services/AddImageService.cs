using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using E_Commerce_App.Models.Interfaces;

namespace E_Commerce_App.Models.Services
{
	public class AddImageService : IAddImage
	{
		private readonly IConfiguration _configuration;
        public AddImageService(IConfiguration configuration )
        {
            _configuration = configuration;
        }
        public async Task<Product> uploadImage(IFormFile file, Product product)
		{
			BlobContainerClient blobContainerClient =
				new BlobContainerClient(_configuration.GetConnectionString("StorageAccount"), "images");

			// Create if images container not exist 
			await blobContainerClient.CreateIfNotExistsAsync();


			BlobClient blobClient = blobContainerClient.GetBlobClient(file.FileName);

			using var fileStream = file.OpenReadStream();

			BlobUploadOptions blobUploadOptions = new BlobUploadOptions()
			{
				HttpHeaders = new BlobHttpHeaders { ContentType = file.ContentType }
			};

			if (!blobClient.Exists())
			{
				await blobClient.UploadAsync(fileStream, blobUploadOptions);
			}
			product.imageURL=blobClient.Uri.ToString();

			return product;
		}

        public async Task<Category> uploadImage(IFormFile file, Category category)
        {
            BlobContainerClient blobContainerClient =
                new BlobContainerClient(_configuration.GetConnectionString("StorageAccount"), "images");

            // Create if images container not exist 
            await blobContainerClient.CreateIfNotExistsAsync();


            BlobClient blobClient = blobContainerClient.GetBlobClient(file.FileName);

            using var fileStream = file.OpenReadStream();

            BlobUploadOptions blobUploadOptions = new BlobUploadOptions()
            {
                HttpHeaders = new BlobHttpHeaders { ContentType = file.ContentType }
            };

            if (!blobClient.Exists())
            {
                await blobClient.UploadAsync(fileStream, blobUploadOptions);
            }
            category.ImageURL = blobClient.Uri.ToString();

            return category;
        }

        public async Task<Department> uploadImage(IFormFile file, Department department)
        {
            BlobContainerClient blobContainerClient =
                new BlobContainerClient(_configuration.GetConnectionString("StorageAccount"), "images");

            // Create if images container not exist 
            await blobContainerClient.CreateIfNotExistsAsync();


            BlobClient blobClient = blobContainerClient.GetBlobClient(file.FileName);

            using var fileStream = file.OpenReadStream();

            BlobUploadOptions blobUploadOptions = new BlobUploadOptions()
            {
                HttpHeaders = new BlobHttpHeaders { ContentType = file.ContentType }
            };

            if (!blobClient.Exists())
            {
                await blobClient.UploadAsync(fileStream, blobUploadOptions);
            }
            department.ImageURL = blobClient.Uri.ToString();

            return department;
        }
    }
}
