using Domain.Models.Users;
using Repository.Repositories;
using Service.DTO.Users;
using Service.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.IServices
{
    public interface INurseService : IUserService
    {
        Task<Nurse> AddNurse(NurseDto doc);
        Task<Nurse> UpdateNurse(NurseDto doc_dto);
        Task<IEnumerable<NurseDto>> GetAllNurses();
        Task<NurseDto> GetNurseById(int Nurse_id);
        Task<IEnumerable<NurseDto>> GetNursesByState(bool state);
        Task<IEnumerable<NurseDto>> GetNursesBySpecialization(string specialization);
        Task<Nurse> DeleteNurse(int Nurse_id);
        Task<NurseDto> GetNurseByName(String Nursename);
        
    }
}
