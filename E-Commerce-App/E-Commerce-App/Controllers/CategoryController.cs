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
        public CategoryController(ICategory category)
        {
            _category = category;
        }

        [Authorize]
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

        public IActionResult EditCategory(int ID)
        {
            return View(new Category { ID = ID });
        }

        [HttpPost]
        public async Task<IActionResult> EditCategory(Category category, int ID)
        {
            await _category.UpdateCategory(category, ID);

            return View(category);
        }

        public IActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddCategory(Category category)
        {
            await _category.CreateCategory(category);
            return View(category);
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

        public async Task<IActionResult> DeleteCategory(int id)
        {
            await _category.DeleteCategory(id);
            return RedirectToAction("Index");
        }
    }
}
