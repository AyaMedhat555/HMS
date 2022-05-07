using Domain.Models;
using Repository;
using Service.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.IServices
{
    public interface IDoctorService : IUserService
    {
        Task<Doctor> AddDoctor(DoctorDto doc);
        Task<Doctor> UpdateDoctor(DoctorDto doc_dto);
        Task<IEnumerable<DoctorDto>> GetAllDoctors();
        Task<DoctorDto> GetDoctorById(int Doctor_id);
        Task<Doctor> DeleteDoctor(int Doctor_id);
        Task<DoctorDto> GetDoctorByName(String Doctorname);
    }
}
