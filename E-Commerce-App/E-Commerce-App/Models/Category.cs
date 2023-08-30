namespace E_Commerce_App.Models
{
    public class Category
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public List<Department>? Departments { get; set; }

    }
}
