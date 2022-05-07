using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Repository;
using Repository.IRepositories;
using Service.DTO;
using Service.Helpers;
using Service.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class DoctorService : UserService, IDoctorService
    {
       
        private IDoctorRepository DoctorRepository { get; }

        public DoctorService(IUserRepository _UserRepository, IDoctorRepository _DoctorRepository, IConfiguration _Configuration)
            :base(_UserRepository, _Configuration)
        {
            DoctorRepository = _DoctorRepository;
        }

        public async Task<Doctor> AddDoctor(DoctorDto dto)
        {
            CreatePasswordHash(dto.Password, out byte[] passwordHash, out byte[] passwordSalt);
            Doctor doctor = UserMapper.ToDoctor(dto);
            doctor.PasswordHash = passwordHash;
            doctor.PasswordSalt = passwordSalt;
            return await DoctorRepository.Add(doctor);
        }

        public async Task<Doctor> DeleteDoctor(int Doctor_id)
        {
            return await DoctorRepository.Delete(Doctor_id);
        }

        public async Task<IEnumerable<DoctorDto>> GetAllDoctors()
        {
            return await DoctorRepository.GetAll().Select(u => new DoctorDto
            {
                Id = u.Id,
                FirstName = u.FirstName,
                LastName = u.LastName,
                DepartmentId = u.DepartmentId
            }).ToListAsync();
        }

        public async Task<Doctor> UpdateDoctor(DoctorDto dto)
        {
            Doctor doctor = UserMapper.ToDoctor(dto);
            CreatePasswordHash(dto.Password, out byte[] passwordHash, out byte[] passwordSalt);
            doctor.PasswordHash = passwordHash;
            doctor.PasswordSalt = passwordSalt;
            return await DoctorRepository.Update(doctor);
        }

        public async Task<DoctorDto> GetDoctorById(int Doctor_id)
        {
            Doctor doc = await DoctorRepository.GetById(Doctor_id);
            DoctorDto doc_dto = UserMapper.ToDoctorDto(doc);
            return doc_dto;
        }

        public async Task<DoctorDto> GetDoctorByName(string Doctorname)
        {
            Doctor doc = await DoctorRepository.FindByName(Doctorname);
            DoctorDto doc_dto = UserMapper.ToDoctorDto(doc);
            return doc_dto;
        }
    }
}
