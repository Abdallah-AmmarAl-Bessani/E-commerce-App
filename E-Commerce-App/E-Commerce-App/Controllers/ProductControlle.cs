using E_Commerce_App.Data;
using E_Commerce_App.DTO;
using E_Commerce_App.Models;
using E_Commerce_App.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;



namespace E_Commerce_App.Controllers
{
    public class ProductController : Controller
	{
		private readonly IProduct _product;
		private readonly E_CommerceDBContext _commerceDBContext;
		public ProductController(IProduct product , E_CommerceDBContext commerceDBContext)
		{
			_product = product;
			_commerceDBContext = commerceDBContext;
		}


		public async Task<IActionResult> product(int departmentID)
		{
			var productsDTO = await _product.GetAllProductAsync(departmentID);


			return View(productsDTO);
		}

		


		[HttpGet]
		public IActionResult AddProduct(int departmentID)
		{
			var product = new Product
			{
				DepartmentID = departmentID
			};

			return View(product);
		}


		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task< IActionResult >CreateProduct(Product product)
		{
			
			var departmentExists = _commerceDBContext.Department.Any(d => d.ID == product.DepartmentID);

			if (!departmentExists)
			{
				
				ModelState.AddModelError("DepartmentID", "The selected department does not exist.");
				return View("AddProduct", product); 
			}

			
			 await _product.CreateProductAsync(product);

			
			return RedirectToAction("product", new { departmentID = product.DepartmentID });
		}


		public async Task<IActionResult> DeleteProduct(int id)
		{
			await _product.DeleteProductAsync(id);
			return RedirectToAction("ProductDetails");
		}

		public async Task<IActionResult> ProductDetails(int id)
		{
			var product = await _product.GetProductAsync(id);
			return View(product);
		}

		public IActionResult EditProduct(int ID)
		{
			return View(new Product { ID = ID });
		}
		[HttpPost]
		public async Task<IActionResult> EditProduct(Product product, int ID)
		{
			await _product.UpdateProductAsync(ID, product);

			return View(product);
		}
	}
}
