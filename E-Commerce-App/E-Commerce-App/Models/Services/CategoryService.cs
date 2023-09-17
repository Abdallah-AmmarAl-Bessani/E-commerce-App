using E_Commerce_App.Data;
using E_Commerce_App.Models.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce_App.Models.Services
{
    public class CategoryService : ICategory
    {
        private readonly E_CommerceDBContext _dbContext;

        public CategoryService(E_CommerceDBContext dBContext)
        {
            _dbContext = dBContext;
        }

        public async Task<Category> CreateCategory(Category category)
        {
            await _dbContext.Category.AddAsync(category);

            await _dbContext.SaveChangesAsync();

            return category;
        }

        public async Task DeleteCategory(int id)
        {
            var category = await _dbContext.Category.FindAsync(id);

            if (category != null)
            {
                _dbContext.Entry(category).State = EntityState.Deleted;

                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<List<Category>> GetCategories()
        {
            return await _dbContext.Category.Include(dp => dp.Departments).ToListAsync();
        }

        public async Task<Category> GetCategoryById(int id)
        {
            var x = await _dbContext.Category.FindAsync(id);

            return x;
        }

        public async Task<Category> UpdateCategory(Category category, int id)
        {
            var x = await _dbContext.Category.FindAsync(id);

            if (x != null)
            {
                x.ID = category.ID;
                x.Name = category.Name;
                if (category.ImageURL != null)
                {
                    x.ImageURL = category.ImageURL;
                }

                _dbContext.Entry(x).State= EntityState.Modified;

                await _dbContext.SaveChangesAsync();
            }
            return x;
        }
    }
}
