using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Repository.IRepositories;
using Repository.Repositories;
using Service.DTO;
using Service.Helpers;
using Service.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class PatientService : UserService, IPatientService
    {

        private IPatientRepository PatientRepository { get; }
        private  IIndoorPatientRepository IndoorPatientRepository { get; }
        private IDoctorService DoctorService { get; }

        public PatientService(IUserRepository _UserRepository, IPatientRepository _PatientRepository, IConfiguration _Configuration, IDoctorService _DoctorService, IIndoorPatientRepository _IndoorPatientRepository)
            : base(_UserRepository, _Configuration)
        {
            PatientRepository = _PatientRepository;
            DoctorService = _DoctorService;
            IndoorPatientRepository = _IndoorPatientRepository;
        }

        public async Task<Patient> AddPatient(PatientDto dto)
        {
            CreatePasswordHash(dto.Password, out byte[] passwordHash, out byte[] passwordSalt);
            Patient doctor = UserMapper.ToPatient(dto);
            doctor.PasswordHash = passwordHash;
            doctor.PasswordSalt = passwordSalt;
            return await PatientRepository.Add(doctor);
        }

        public async Task<Patient> DeletePatient(int Patient_id)
        {
            return await PatientRepository.Delete(Patient_id);
        }

        public async Task<IEnumerable<PatientDto>> GetAllPatients()
        {
            return await PatientRepository.GetAll().Select(u => new PatientDto
            {
                Id = u.Id,
                FirstName = u.FirstName,
                LastName = u.LastName,
                DepartmentId = u.DepartmentId
            }).ToListAsync();
        }

        public async Task<Patient> UpdatePatient(PatientDto dto)
        {
            Patient doctor = UserMapper.ToPatient(dto);
            CreatePasswordHash(dto.Password, out byte[] passwordHash, out byte[] passwordSalt);
            doctor.PasswordHash = passwordHash;
            doctor.PasswordSalt = passwordSalt;
            return await PatientRepository.Update(doctor);
        }

        public async Task<PatientDto> GetPatientById(int Patient_id)
        {
            Patient doc = await PatientRepository.GetById(Patient_id);
            PatientDto doc_dto = UserMapper.ToPatientDto(doc);
            return doc_dto;
        }

        public async Task<PatientDto> GetPatientByName(string Patientname)
        {
            Patient doc = await PatientRepository.FindByName(Patientname);
            PatientDto doc_dto = UserMapper.ToPatientDto(doc);
            return doc_dto;
        }

       
    }
}
