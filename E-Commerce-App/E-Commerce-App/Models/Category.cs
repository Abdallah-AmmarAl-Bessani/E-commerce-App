using E_Commerce_App.Models.Interfaces;

namespace E_Commerce_App.Models
{
    public class Category : IHasImage
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string? ImageURL { get; set; }

        public List<Department>? Departments { get; set; }

    }
}
