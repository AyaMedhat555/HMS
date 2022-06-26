using Domain.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.IRepositories
{
    public interface INurseRepository: IGenericRepository<Nurse>
    {
        Task<Nurse> FindByName(String username);
        Task<Nurse> GetNurseById(int id);
        IQueryable<Nurse> GetNursesBySpecialization(string specialization);
        IQueryable<Nurse> GetNursesByState(bool state);
        IQueryable<Nurse> GetAllNurses();

    }
}
