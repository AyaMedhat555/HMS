using Domain.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.IRepositories
{
    public interface IPatientRepository : IGenericRepository<Patient>
    {
        Task<Patient> GetPatientById(int id);
        Task<Patient> FindByName(String username);
        IQueryable<Patient> GetAllPatients();
        
    }
}
