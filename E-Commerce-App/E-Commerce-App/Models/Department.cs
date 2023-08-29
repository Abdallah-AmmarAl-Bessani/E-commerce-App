using System.ComponentModel.DataAnnotations.Schema;

namespace E_Commerce_App.Models
{
    public class Department
    {
        public int ID { get; set; }

        [ForeignKey("CategoryID")]
        public int CategoryID { get; set; }

        public string Name { get; set; }

        public List<Product> Products { get; set; }

        public Category Category { get; set; }

    }
}
