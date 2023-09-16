using E_Commerce_App.Data;
using E_Commerce_App.Models.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace E_Commerce_App.Models.Services
{
    public class ProductServices : IProduct
	{
		private readonly E_CommerceDBContext _commerceDBContext;
		public ProductServices(E_CommerceDBContext commerceDBContext)
		{
			_commerceDBContext = commerceDBContext;
		}
		public async Task<Product> CreateProductAsync(Product product)
		{
			
			_commerceDBContext.Entry(product).State = EntityState.Added;
			await _commerceDBContext.SaveChangesAsync();
			return product;
		}

		public async Task DeleteProductAsync(int ID)
		{
			var product = await _commerceDBContext.Product.FindAsync(ID);

			if (product != null)
			{
				_commerceDBContext.Entry(product).State = EntityState.Deleted;
				await _commerceDBContext.SaveChangesAsync();
			}
			else
			{
				// Add a debug statement here to check if product is null
				Debug.WriteLine("Product not found!");
			}
		}

		public async Task<List<Product>> GetAllProductAsync(int departmentID)
		{

			return await _commerceDBContext.Product.Include(dp => dp.Department).Where(x=>x.DepartmentID== departmentID)
				.Select(x => new Product
			{
				ID = x.ID,
				Name = x.Name,
				Price = x.Price,
				Quantity = x.Quantity,
				ImageURL = x.ImageURL,
				Discount = x.Discount,
				DepartmentID = x.DepartmentID,
				Department = new Department
				{
					ID = x.Department.ID,
					Name = x.Department.Name,
					CategoryID = x.Department.Category.ID

				}
				
			}).ToListAsync();
		}
		[AllowAnonymous]
        public async Task<List<Product>> GetAllProducts()
        {
			return await _commerceDBContext.Product.Include(x=> x.Department).ToListAsync();
        }

        public async Task<Product> GetProductAsync(int ID)
		{
			var product = await _commerceDBContext.Product.Include(dep => dep.Department)
				.FirstOrDefaultAsync(pro => pro.ID == ID);
			


			return product;
		}

        public async Task<List<Product>> GetProductByName(string name)
        {
			var products = await _commerceDBContext.Product
				.Where(x => x.Name.Contains(name))
				.ToListAsync();
			return products;
        }

        public async Task<Product> UpdateProductAsync(int ID, Product product)
		{
			var product1 = await _commerceDBContext.Product.FindAsync(ID);

			if (product1 != null)
			{
				product1.Price = product.Price;
				product1.Name = product.Name;
				product1.Quantity = product.Quantity;
				product1.Discount = product.Discount;
				if(product.DepartmentID != null)
				{
					product1.DepartmentID = product.DepartmentID;
				}
				
				if (product.ImageURL != null)
				{
					product1.ImageURL = product.ImageURL;
				}
				

				_commerceDBContext.Entry(product1).State = EntityState.Modified;
				await _commerceDBContext.SaveChangesAsync();
			}
			return product1;


		}
	}
}
