using E_Commerce_App.Models;
using E_Commerce_App.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace E_Commerce_App.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartment _department;

        private readonly ILogger<DepartmentController> _logger;

        public DepartmentController(ILogger<DepartmentController> logger ,IDepartment department)
        {
            _logger = logger;
             _department = department;
        }

        public async Task<IActionResult> Departments(int categoryId)
        {
            var x = await _department.GetDepartments(categoryId);

            return View(x);
        }

        public async Task<IActionResult> DepartmentDetails(int departmentId, int categoryId)
        {
            var departmentDetails = await _department.GetDepartmentById(departmentId, categoryId);

            return View(departmentDetails);
        }

        public IActionResult EditDepartment(int ID, int CategoryID)
        {
            return View(new Department { ID = ID, CategoryID = CategoryID });
        }

        [HttpPost]
        public async Task<IActionResult> EditDepartment(Department department, int ID, int CategoryID)
        {
           await _department.UpdateDepartment(department, ID, CategoryID);

           return View(department);
        }


        public async Task<IActionResult> DeleteDepartment(int departmentId, int categoryId)
        {
            await _department.DeleteDepartment(departmentId, categoryId);

            return RedirectToAction("Departments", new { categoryId });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
