using E_Commerce_App.Data;
using E_Commerce_App.Models;
using E_Commerce_App.Models.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;



namespace E_Commerce_App.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProduct _product;
        private readonly E_CommerceDBContext _commerceDBContext;
        private readonly IAddImage _addImage;
        private readonly IFormFile _formFile;
        public ProductController(IProduct product, E_CommerceDBContext commerceDBContext, IAddImage addImage)
        {
            _product = product;
            _commerceDBContext = commerceDBContext;
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
            var product = new Product
            {
                DepartmentID = departmentID
            };

            return View(product);
        }

        [HttpPost]
        [Authorize(Roles = "Admin", Policy = "create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateProduct(Product product, IFormFile file)
        {
            var departmentExists = _commerceDBContext.Department.Any(d => d.ID == product.DepartmentID);
            if (!departmentExists)
            {
                ModelState.AddModelError("DepartmentID", "The selected department does not exist.");
                return View("AddProduct", product);
            }
            if (file != null)
                await _addImage.uploadImage(file, product);
            else
            {
                product.imageURL = "";
            }
            await _product.CreateProductAsync(product);
            return RedirectToAction("product", new { departmentID = product.DepartmentID });
        }


        [Authorize(Roles = "Admin", Policy = "create")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            await _product.DeleteProductAsync(id);
            return RedirectToAction("product", new { id });
        }

        public async Task<IActionResult> ProductDetails(int id)
        {
            var product = await _product.GetProductAsync(id);
            return View(product);
        }

        [Authorize(Roles = "User", Policy = "update")]
        public IActionResult EditProduct(int ID)
        {
            return View(new Product { ID = ID });
        }

        [HttpPost]
        [Authorize(Roles = "User", Policy = "update")]
        public async Task<IActionResult> EditProduct(Product product, int ID, IFormFile file)
        {
            await _addImage.uploadImage(file, product);

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
