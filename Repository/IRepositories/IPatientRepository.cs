using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.IRepositories
{
    public interface IPatientRepository : IGenericRepository<Patient>
    {
        Task<Patient> FindByName(String username);
    }
}
