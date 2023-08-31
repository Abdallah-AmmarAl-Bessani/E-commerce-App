using E_Commerce_App.Models;
using E_Commerce_App.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce_App.Controllers
{
    public class ProductController : Controller
	{
		private readonly IProduct _product;
		public ProductController(IProduct product)
		{
			_product = product;
		}


		public async Task<IActionResult> product(int departmentID)
		{
			var productsDTO = await _product.GetAllProductAsync(departmentID);


			return View(productsDTO);
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
