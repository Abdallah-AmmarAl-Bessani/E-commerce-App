using E_Commerce_App.DTO;

namespace E_Commerce_App.Models.Interfaces
{
    public interface IProduct

    {
        public Task<Product> UpdateProductAsync(int ID, Product product);
        public Task DeleteProductAsync(int ID);
        public Task<Product> CreateProductAsync(Product product);

        public Task<List<Product>> GetAllProductAsync(int departmentID);
        public Task<Product> GetProductAsync(int ID);
        public Task<List<Product>> GetProductByName(string name);
    }
}
