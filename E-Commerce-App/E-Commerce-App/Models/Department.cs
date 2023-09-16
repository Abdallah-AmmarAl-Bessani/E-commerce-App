using System.ComponentModel.DataAnnotations.Schema;

namespace E_Commerce_App.Models
{
    public class Department
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int CategoryID { get; set; }
        public string? ImageURL { get; set; }

        public Category Category { get; set; } // Navigation property

        public List<Product>? Products { get; set; }
    }
}
