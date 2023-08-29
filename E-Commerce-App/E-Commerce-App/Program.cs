using E_Commerce_App.Data;
using E_Commerce_App.Models.Interfaces;
using E_Commerce_App.Models.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace E_Commerce_App
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            
           // Add Database Connection
            string? connString = builder.Configuration.GetConnectionString("DefaultConnection");

            builder.Services
                .AddDbContext<E_CommerceDBContext>
                (options => options.UseSqlServer(connString));
            
            builder.Services.AddControllers().AddNewtonsoftJson(options =>
       options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
     );

            builder.Services.AddTransient<ICategory, CategoryService>();
            builder.Services.AddTransient<IDepartment, DepartmentService>();
			builder.Services.AddTransient<IProduct, ProductServices>();

			// Add services to the container.
			builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
