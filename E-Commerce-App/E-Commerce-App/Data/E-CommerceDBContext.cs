using E_Commerce_App.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using E_Commerce_App.Models.DTO;

namespace E_Commerce_App.Data
{
    public class E_CommerceDBContext : IdentityDbContext<UserInterface>
    {
        public E_CommerceDBContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    ID = 1,
                    Name = "Electric"
                },
                new Category
                {
                    ID = 2,
                    Name = "Houseware"
                },
                new Category
                {
                    ID = 3,
                    Name = "Food"
                }
                );

            modelBuilder.Entity<Department>().HasData(
                new Department
                {
                    ID = 1,
                    CategoryID = 1,
                    Name = "Screens"
                },
                new Department
                {
                    ID = 2,
                    CategoryID = 1,
                    Name = "Fridges"
                },
                new Department
                {
                    ID = 3,
                    CategoryID = 2,
                    Name = "Tables"
                },
                new Department
                {
                    ID = 4,
                    CategoryID = 2,
                    Name = "Kitchen Tools"
                },
                new Department
                {
                    ID = 5,
                    CategoryID = 3,
                    Name = "Meats"
                },
                new Department
                {
                    ID = 6,
                    CategoryID = 3,
                    Name = "Food Stuff"
                }
                );

            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    ID = 1,
                    Name = "Samsung",
                    Price = 350,
                    Quantity = 23,
                    DepartmentID = 1
                },
                new Product
                {
                    ID = 2,
                    Name = "LG",
                    Price = 300,
                    Quantity = 40,
                    DepartmentID = 1
                },
                new Product
                {
                    ID = 3,
                    Name = "Beko",
                    Price = 250,
                    Quantity = 50,
                    DepartmentID = 2
                },
                new Product
                {
                    ID = 4,
                    Name = "Toshiba",
                    Price = 280,
                    Quantity = 40,
                    DepartmentID = 2
                },
                new Product
                {
                    ID = 5,
                    Name = "4 Person lunch Table",
                    Price = 40,
                    Quantity = 100,
                    DepartmentID = 3
                },
                new Product
                {
                    ID = 6,
                    Name = "8 Person lunch table",
                    Price = 70,
                    Quantity = 100,
                    DepartmentID = 3
                },
                new Product
                {
                    ID = 7,
                    Name = "Teval Pan",
                    Price = 20,
                    Quantity = 45,
                    DepartmentID = 4
                },
                new Product
                {
                    ID = 8,
                    Name = "Dishes",
                    Price = 15,
                    Quantity = 100,
                    DepartmentID = 4
                },
                new Product
                {
                    ID = 9,
                    Name = "Sheep meat",
                    Price = 15,
                    Quantity = 110,
                    DepartmentID = 5
                },
                new Product
                {
                    ID = 10,
                    Name = "Beef",
                    Price = 10,
                    Quantity = 80,
                    DepartmentID = 5
                },
                new Product
                {
                    ID = 11,
                    Name = "Sunny frying oil",
                    Price = 10,
                    Quantity = 80,
                    DepartmentID = 6
                },
                new Product
                {
                    ID = 12,
                    Name = "Durra Bean Box 500g",
                    Price = 1,
                    Quantity = 48,
                    DepartmentID = 6

                });


            modelBuilder.Entity<Department>().HasKey(x => new
            {
                x.ID,
            });

            var hasher = new PasswordHasher<UserInterface>();
            var Admin = new UserInterface
            {
                Id = "1",
                UserName = "Admin",
                NormalizedUserName = "ADMIN",
                Email = "adminUser@example.com",
                PhoneNumber = "1234567890",
                NormalizedEmail = "adminUser@EXAMPLE.COM",
                EmailConfirmed = true,
                LockoutEnabled = false
            };
            //Admin.PasswordHash = hasher.HashPassword(Admin, "Admin@1+");

            //modelBuilder.Entity<UserInterface>().HasData(Admin);

            //List<IdentityUserRole<string>> userRoles = new List<IdentityUserRole<string>>()
            // {
            //new IdentityUserRole<string> { UserId ="1" , RoleId = "admin" }
    
            //  };
            //modelBuilder.Entity<IdentityUserRole<string>>().HasData(userRoles);

            seedRole(modelBuilder, "Admin", "create", "update", "delete", "read");

            seedRole(modelBuilder, "User", "create", "update", "delete", "read");
        }
        int nextId = 1;
        private void seedRole(ModelBuilder modelBuilder, string roleName, params string[] permissions)
        {
            var role = new IdentityRole()
            {
                Id = roleName.ToLower(),
                Name = roleName,
                NormalizedName = roleName.ToUpper(),
                ConcurrencyStamp = Guid.Empty.ToString()
            };

            modelBuilder.Entity<IdentityRole>().HasData(role);

            var roleClaim = permissions.Select(permission =>
            new IdentityRoleClaim<string>
            {
                Id = nextId++,
                RoleId = role.Id,
                ClaimType = "permissions",
                ClaimValue = permission
            }).ToArray();

            modelBuilder.Entity<IdentityRoleClaim<string>>().HasData(roleClaim);
        }

        public DbSet<Category> Category { get; set; }

        public DbSet<Department> Department { get; set; }

        public DbSet<Product> Product { get; set; }

        public DbSet<ProductDTO> ProductDTO { get; set; } = default!;
    }
}
