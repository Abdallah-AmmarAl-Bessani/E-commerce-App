using E_Commerce_App.Data;
using E_Commerce_App.Models.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce_App.Models.Services
{
    public class DepartmentService : IDepartment
    {

        private readonly E_CommerceDBContext _dbContext;

        public DepartmentService(E_CommerceDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Department> CreateDepartment(Department department)
        {
            await _dbContext.Department.AddAsync(department);

            await _dbContext.SaveChangesAsync();

            return department;
        }

        public async Task DeleteDepartment(int id)
        {
            var department = await _dbContext.Department.FindAsync(id);

            if (department != null)
            {
                _dbContext.Entry(department).State = EntityState.Deleted;

                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<Department> GetDepartmentById(int id)
        {
            var departmentDetails = await _dbContext.Department.FindAsync(id);

            return departmentDetails;
        }

        public async Task<List<Department>> GetDepartments(int categoryId)
        {

            var departments = await _dbContext.Department.Include(x=>x.Category).Where(cId => cId.CategoryID == categoryId).ToListAsync();

            return departments;
        }

        public async Task<Department> UpdateDepartment(Department department, int id)
        {
            var departmentDetails = await _dbContext.Department.FindAsync(id);

            if (departmentDetails != null)
            {
                departmentDetails.Name = department.Name;
                departmentDetails.ImageURL = department.ImageURL;

                _dbContext.Entry(departmentDetails).State = EntityState.Modified;
                await _dbContext.SaveChangesAsync();

            }
            return departmentDetails;
        }
    }
}
