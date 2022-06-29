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
        Task<Department> AddDepartment(DepartmentResponse department);
        Task<IEnumerable<DepartmentResponse>> GetAllDepartments();
        Task<Department> UpdateDepartment(Department department);
        Task<Department> DeleteDepartment(int id);
        Task<DepartmentResponse> GetDepartmentEmpsById(int id);
        Task<DepartmentResponse> GetDepartmentPatientsById(int id);
        Task<DepartmentResponse> GetDepartmentEmpsByName(string name);
        Task<DepartmentResponse> GetDepartmentPatientsByName(string name);
        Task<IEnumerable<DepartmentResponse>> GetAllDepartmentsEmps();
        Task<IEnumerable<DepartmentResponse>> GetAllDepartmentsPatients();
        Task<IEnumerable<Department>> GetClinicalDepartments();

    }
}
