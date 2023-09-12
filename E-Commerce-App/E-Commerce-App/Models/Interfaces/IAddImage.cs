namespace E_Commerce_App.Models.Interfaces
{
	public interface IAddImage
	{
		Task<Product> uploadImage(IFormFile file, Product product);
	}
}
