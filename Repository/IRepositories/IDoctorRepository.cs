using Domain.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.IRepositories
{
    public interface IDoctorRepository: IGenericRepository<Doctor>
    {
        Task<Doctor> FindByName(String username);
        Task<Doctor> GetDoctorById(int id);
        IQueryable<Doctor> GetDoctorsBySpecialization(string specialization);
        IQueryable<Doctor> GetDoctorsByState(bool state);

        IQueryable<Doctor> GetDoctorsByDepartment_Id(int Department_ID);

        IQueryable<Doctor> GetAllDoctors();

    }
}
