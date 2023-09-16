using System.ComponentModel.DataAnnotations.Schema;

namespace E_Commerce_App.Models.DTO
{
    public class ProductDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public int Price { get; set; }

        public int Quantity { get; set; }

        [ForeignKey("DepartmentID")]
        public int DepartmentID { get; set; }

    }
}
