namespace E_Commerce_App.Models.Interfaces
{
    public interface IDepartment
    {
        Task<Department> CreateDepartment(Department department);

        Task<List<Department>> GetDepartments(int categoryId);

        Task<Department> GetDepartmentById(int id, int categoryId);

        Task<Department> UpdateDepartment(Department department, int id, int categoryId);

        Task DeleteDepartment(int id, int categoryId);

    }
}
