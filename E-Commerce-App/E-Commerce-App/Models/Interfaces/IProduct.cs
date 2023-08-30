using E_Commerce_App.DTO;

namespace E_Commerce_App.Models.Interfaces
{
    public interface IProduct

    {
        public Task<Product> UpdateProductAsync(int ID, Product product);
        public Task DeleteProductAsync(int ID);
        public Task<Product> CreateProductAsync(ProductDTO productdto);

        public Task<List<ProductDTO>> GetAllProductAsync(int departmentID);
        public Task<Product> GetProductAsync(int ID);
    }
}
