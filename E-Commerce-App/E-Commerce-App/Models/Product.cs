using System.ComponentModel.DataAnnotations.Schema;

namespace E_Commerce_App.Models
{
    public class Product
    {
        public int ID { get; set; }

        [ForeignKey("DepartmentID")]
        public int DepartmentID { get; set; }

        public string Name { get; set; }

        public int Price { get; set; }

        public int Quantity { get; set; }

        public Department Department { get; set; }
    }
}
