namespace E_Commerce_App.Models.Interfaces
{
    public interface IDepartment
    {
        Task<Department> CreateDepartment(Department department);

        Task<List<Department>> GetDepartments(int categoryId);

        Task<Department> GetDepartmentById(int id);

        Task<Department> UpdateDepartment(Department department, int id);

        Task DeleteDepartment(int id);

    }
}
