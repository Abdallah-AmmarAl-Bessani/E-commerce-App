﻿// <auto-generated />
using System;
using E_Commerce_App.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace E_Commerce_App.Migrations
{
    [DbContext(typeof(E_CommerceDBContext))]
    partial class E_CommerceDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("E_Commerce_App.DTO.ProductDTO", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("DepartmentID")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("ProductDTO");
                });

            modelBuilder.Entity("E_Commerce_App.Models.Category", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Category");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Name = "Electric"
                        },
                        new
                        {
                            ID = 2,
                            Name = "Houseware"
                        },
                        new
                        {
                            ID = 3,
                            Name = "Food"
                        });
                });

            modelBuilder.Entity("E_Commerce_App.Models.Department", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("CategoryID")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("CategoryID");

                    b.ToTable("Department");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            CategoryID = 1,
                            Name = "Screens"
                        },
                        new
                        {
                            ID = 2,
                            CategoryID = 1,
                            Name = "Fridges"
                        },
                        new
                        {
                            ID = 3,
                            CategoryID = 2,
                            Name = "Tables"
                        },
                        new
                        {
                            ID = 4,
                            CategoryID = 2,
                            Name = "Kitchen Tools"
                        },
                        new
                        {
                            ID = 5,
                            CategoryID = 3,
                            Name = "Meats"
                        },
                        new
                        {
                            ID = 6,
                            CategoryID = 3,
                            Name = "Food Stuff"
                        });
                });

            modelBuilder.Entity("E_Commerce_App.Models.Product", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("DepartmentID")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("DepartmentID");

                    b.ToTable("Product");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            DepartmentID = 1,
                            Name = "Samsung",
                            Price = 350,
                            Quantity = 23
                        },
                        new
                        {
                            ID = 2,
                            DepartmentID = 1,
                            Name = "LG",
                            Price = 300,
                            Quantity = 40
                        },
                        new
                        {
                            ID = 3,
                            DepartmentID = 2,
                            Name = "Beko",
                            Price = 250,
                            Quantity = 50
                        },
                        new
                        {
                            ID = 4,
                            DepartmentID = 2,
                            Name = "Toshiba",
                            Price = 280,
                            Quantity = 40
                        },
                        new
                        {
                            ID = 5,
                            DepartmentID = 3,
                            Name = "4 Person lunch Table",
                            Price = 40,
                            Quantity = 100
                        },
                        new
                        {
                            ID = 6,
                            DepartmentID = 3,
                            Name = "8 Person lunch table",
                            Price = 70,
                            Quantity = 100
                        },
                        new
                        {
                            ID = 7,
                            DepartmentID = 4,
                            Name = "Teval Pan",
                            Price = 20,
                            Quantity = 45
                        },
                        new
                        {
                            ID = 8,
                            DepartmentID = 4,
                            Name = "Dishes",
                            Price = 15,
                            Quantity = 100
                        },
                        new
                        {
                            ID = 9,
                            DepartmentID = 5,
                            Name = "Sheep meat",
                            Price = 15,
                            Quantity = 110
                        },
                        new
                        {
                            ID = 10,
                            DepartmentID = 5,
                            Name = "Beef",
                            Price = 10,
                            Quantity = 80
                        },
                        new
                        {
                            ID = 11,
                            DepartmentID = 6,
                            Name = "Sunny frying oil",
                            Price = 10,
                            Quantity = 80
                        },
                        new
                        {
                            ID = 12,
                            DepartmentID = 6,
                            Name = "Durra Bean Box 500g",
                            Price = 1,
                            Quantity = 48
                        });
                });

            modelBuilder.Entity("E_Commerce_App.Models.UserInterface", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "admin",
                            ConcurrencyStamp = "00000000-0000-0000-0000-000000000000",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = "user",
                            ConcurrencyStamp = "00000000-0000-0000-0000-000000000000",
                            Name = "User",
                            NormalizedName = "USER"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 9,
                            ClaimType = "permissions",
                            ClaimValue = "create",
                            RoleId = "admin"
                        },
                        new
                        {
                            Id = 10,
                            ClaimType = "permissions",
                            ClaimValue = "update",
                            RoleId = "admin"
                        },
                        new
                        {
                            Id = 11,
                            ClaimType = "permissions",
                            ClaimValue = "delete",
                            RoleId = "admin"
                        },
                        new
                        {
                            Id = 12,
                            ClaimType = "permissions",
                            ClaimValue = "read",
                            RoleId = "admin"
                        },
                        new
                        {
                            Id = 13,
                            ClaimType = "permissions",
                            ClaimValue = "create",
                            RoleId = "user"
                        },
                        new
                        {
                            Id = 14,
                            ClaimType = "permissions",
                            ClaimValue = "update",
                            RoleId = "user"
                        },
                        new
                        {
                            Id = 15,
                            ClaimType = "permissions",
                            ClaimValue = "delete",
                            RoleId = "user"
                        },
                        new
                        {
                            Id = 16,
                            ClaimType = "permissions",
                            ClaimValue = "read",
                            RoleId = "user"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("E_Commerce_App.Models.Department", b =>
                {
                    b.HasOne("E_Commerce_App.Models.Category", "Category")
                        .WithMany("Departments")
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("E_Commerce_App.Models.Product", b =>
                {
                    b.HasOne("E_Commerce_App.Models.Department", "Department")
                        .WithMany("Products")
                        .HasForeignKey("DepartmentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("E_Commerce_App.Models.UserInterface", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("E_Commerce_App.Models.UserInterface", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("E_Commerce_App.Models.UserInterface", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("E_Commerce_App.Models.UserInterface", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("E_Commerce_App.Models.Category", b =>
                {
                    b.Navigation("Departments");
                });

            modelBuilder.Entity("E_Commerce_App.Models.Department", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
