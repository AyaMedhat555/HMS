using Domain.Models;
using Service.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.IServices
{
    public interface IDepartmentService
    {
        Task<Department> AddDepartment(Department department);
        Task<IEnumerable<Department>> GetAllDepartments();
        Task<Department> UpdateDepartment(Department department);
        Task<Department> DeleteDepartment(int id);
        Task<IEnumerable<DepartmentResponse>> GetAllDepartmentsEmps();
    }
}
