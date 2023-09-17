using E_Commerce_App.Data;
using E_Commerce_App.Models;
using E_Commerce_App.Models.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace E_Commerce_App.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProduct _product;
        private readonly IDepartment _department;
        private readonly IAddImage _addImage;

        public ProductController(IProduct product, IAddImage addImage, IDepartment department)
        {
            _product = product;
            _department = department;
            _addImage = addImage;

        }


        public async Task<IActionResult> product(int departmentID)
        {
            var productsDTO = await _product.GetAllProductAsync(departmentID);


            return View(productsDTO);
        }



        [HttpGet]
        [Authorize(Roles = "Admin", Policy = "create")]

        public IActionResult AddProduct(int departmentID)
        {

            var product = new Product();

            return View(product);
        }

        [HttpPost]
        [Authorize(Roles = "Admin", Policy = "create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateProduct(Product product, IFormFile file)
        {

            if (file != null)
            {
                await _addImage.UploadImage(file, product);
            }
            else
            {
                product.ImageURL = "";
            }
            await _product.CreateProductAsync(product);
            return RedirectToAction("product", new { departmentID = product.DepartmentID });
        }


        [Authorize(Roles = "Admin", Policy = "create")]

        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _product.GetProductAsync(id);
            await _product.DeleteProductAsync(id);
            return RedirectToAction("product", new { departmentID = product.DepartmentID });
        }

        public async Task<IActionResult> ProductDetails(int id)
        {
            var product = await _product.GetProductAsync(id);
            return View(product);
        }

        [Authorize(Roles = "User", Policy = "update")]
        public async Task<IActionResult> EditProduct(int ID)
        {
            var existProduct = await _product.GetProductAsync(ID);
            return View(existProduct);
        }

        [HttpPost]
        [Authorize(Roles = "User", Policy = "update")]
        public async Task<IActionResult> EditProduct(Product product, int ID, IFormFile file)
        {
            if (file != null)
            {
                await _addImage.UploadImage(file, product);

            }


            await _product.UpdateProductAsync(ID, product);

            return RedirectToAction("ProductDetails", new { product.ID });
        }


        public async Task<IActionResult> GetSuggestions(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return Json(new List<Product>());
            }

            List<Product> suggestions = await _product.GetProductByName(input);
            return Json(suggestions);
        }

        [HttpGet]
        public async Task<IActionResult> GetProductsList()
        {
            var products = await _product.GetAllProducts();
            return View(products);
        }
        public IActionResult Search()
        {
            return View();
        }
    }
}
