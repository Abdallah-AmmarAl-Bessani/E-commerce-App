using E_Commerce_App.Models;
using E_Commerce_App.Models.Interfaces;
using E_Commerce_App.Models.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce_App.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategory _category;
        private readonly IAddImage _addImage;
        public CategoryController(ICategory category , IAddImage addImage)
        {
            _category = category;
            _addImage = addImage;
        }

        
        public async Task<IActionResult> Index()
        {
            var categories = await _category.GetCategories();
            return View(categories);
        }

        public async Task<IActionResult> CategoryDetails(int id)
        {
            var category = await _category.GetCategoryById(id);

            return View(category);
        }

        [Authorize(Policy ="update", Roles = "User")]
        public async Task<IActionResult> EditCategory(int ID)
        {
            var category = await _category.GetCategoryById(ID);
            return View(category);
        }

        [HttpPost]
        [Authorize(Policy = "update", Roles = "User")]
        public async Task<IActionResult> EditCategory(Category category, int ID,IFormFile file)
        {
            if (file != null)
            {
                await _addImage.UploadImage(file, category);
            }
            await _category.UpdateCategory(category, ID);

            return RedirectToAction("CategoryDetails", new { category.ID});
        }
        [Authorize(Roles ="Admin")]
        public IActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddCategory(Category category)
        {
            await _category.CreateCategory(category);
            return RedirectToAction("Index", "Category");
        }

        //[HttpGet]
        //public async Task<IActionResult> EditCategory(int id)
        //{
        //    Category category = await _category.GetCategoryById(id);
        //    if (category == null)
        //    {
        //        return NotFound(); // Handle category not found
        //    }

        //    return View(category);
        //}

        //[HttpPost]
        //public async Task<IActionResult> EditCategory(Category category , int ID)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        await _category.UpdateCategory( category, ID);
        //        return RedirectToAction("Index", "Home"); // Redirect after successful update
        //    }

        //    return View(category); // Show the view with validation errors
        //}

        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            await _category.DeleteCategory(id);
            return RedirectToAction("Index");
        }
    }
}
