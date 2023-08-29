namespace E_Commerce_App.Models.Interfaces
{
    public interface ICategory
    {
        Task<List<Category>> GetCategories();

        Task<Category> GetCategoryById(int id);

        Task<Category> CreateCategory(Category category);

        Task<Category> UpdateCategory(Category category, int id);

        Task DeleteCategory(int id);
    }
}
