namespace E_Commerce_App.Models.Interfaces
{
	public interface IAddImage
	{
		Task<Product> uploadImage(IFormFile file, Product product);
		Task<Category> uploadImage(IFormFile file, Category category);
		Task<Department> uploadImage(IFormFile file, Department department);
	}
}
