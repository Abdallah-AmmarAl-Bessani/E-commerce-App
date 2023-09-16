using E_Commerce_App.Models.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Commerce_App.Models
{
    public class Product : IHasImage
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public int Price { get; set; }

        public int Quantity { get; set; }

        public int DepartmentID { get; set; }

        public double? Discount { get; set; } 

        public string? ImageURL { get; set; }

        public Department? Department { get; set; } // Navigation property

    }
}