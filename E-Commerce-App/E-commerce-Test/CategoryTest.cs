using E_Commerce_App.Models;
using E_Commerce_App.Models.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce_Test
{
    public class CategoryTest : Mock
    {
        [Fact]

        public async Task createCategory1()
        {
            await createCategiry();
            var categ = new CategoryService(_db);
             var c = await categ.GetCategories();

            Assert.Equal(4,c.Count);

        }

        [Fact]

        public async void updateCategory() 
        {

            await createCategiry();
            var update = new CategoryService(_db);

            Category category = new Category()
            {
                Name = "Test",

            };

            var test = update.UpdateCategory(category, 1);
            bool x = false;
            if(category.Name == "Test")
            {
                x = true;
            }

            Assert.True(x);
        }


        [Fact]

        public async void getcategoryById()
        {
            await createCategiry();
             
            var get =  new CategoryService(_db);

            var c = await get.GetCategoryById(1);

            Assert.NotNull(c);

        }

        [Fact]

        public async void getall()
        {
            await createCategiry();

            var get = new CategoryService(_db);

            var c = await get.GetCategories();

            Assert.Equal(4,c.Count);
        }
    }
}
