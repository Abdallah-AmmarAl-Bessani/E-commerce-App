using E_Commerce_App.Models;
using E_Commerce_App.Models.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace E_Commerce_App.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartment _department;
        private readonly ICategory _category;
        private readonly IAddImage _addImage;

        private readonly ILogger<DepartmentController> _logger;

        public DepartmentController(ILogger<DepartmentController> logger, IDepartment department, ICategory category, IAddImage addImage)
        {
            _logger = logger;
            _department = department;
            _category = category;
            _addImage = addImage;
        }

        public async Task<IActionResult> Departments(int categoryId)
        {
            var x = await _department.GetDepartments(categoryId);

            return View(x);
        }


        public async Task<IActionResult> DepartmentDetails(int departmentId)
        {
            var departmentDetails = await _department.GetDepartmentById(departmentId);

            return View(departmentDetails);
        }

        [Authorize(Policy = "Update")]
        public IActionResult EditDepartment(int ID, int CategoryID)
        {

            return View(new Department { ID = ID, CategoryID = CategoryID });
        }
        [Authorize(Policy = "Update")]
        [HttpPost]
        public async Task<IActionResult> EditDepartment(Department department, int ID, int CategoryID, IFormFile file)
        {
            await _addImage.UploadImage(file, department);
            await _department.UpdateDepartment(department, ID);

            return View(department);
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteDepartment(int departmentId, int categoryId)
        {
            await _department.DeleteDepartment(departmentId);

            return RedirectToAction("Departments", new { categoryId });
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddDepartment(int categoryId)
        {
            var categories = await _category.GetCategories();
            var department = new Department();
            // for drop down list
            ViewBag.Category = new SelectList(categories, "ID", "Name");
            //department.CategoryID = categoryId;
            return View(department);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> AddDepartment(Department department)
        {
            await _department.CreateDepartment(department);
            return View(department);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
