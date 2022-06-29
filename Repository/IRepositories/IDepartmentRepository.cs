using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.IRepositories
{
    public interface IDepartmentRepository : IGenericRepository<Department>
    {
        Task<Department> GetEmpsByName(String name);
        Task<Department> GetEmpsById(int id);
        Task<Department> GetPatientsByName(String name);
        Task<Department> GetPatientsById(int id);
        IQueryable<Department> GetClinicalDepartments();

    }
}
