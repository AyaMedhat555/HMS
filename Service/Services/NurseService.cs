using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Repository.IRepositories;
using Repository.Repositories;
using Service.DTO;
using Service.Helpers;
using Service.IServices;
using Service.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class NurseService : UserService, INurseService
    {
        private INurseRepository NurseRepository { get; }
        private IVitalSignsRepository VitalSignsRepository { get; }

        public NurseService(IUserRepository _UserRepository, INurseRepository _NurseRepository, IConfiguration _Configuration, IVitalSignsRepository _vitalSignsRepository)
            : base(_UserRepository, _Configuration)
        {
            NurseRepository = _NurseRepository;
            VitalSignsRepository = _vitalSignsRepository;
        }

        public async Task<Nurse> AddNurse(NurseDto dto)
        {
            CreatePasswordHash(dto.Password, out byte[] passwordHash, out byte[] passwordSalt);
            Nurse nurse = UserMapper.ToNurse(dto);
            nurse.PasswordHash = passwordHash;
            nurse.PasswordSalt = passwordSalt;
            return await NurseRepository.Add(nurse);
        }

        public async Task<Nurse> DeleteNurse(int Nurse_id)
        {
            return await NurseRepository.Delete(Nurse_id);
        }

        public async Task<IEnumerable<NurseDto>> GetAllNurses()
        {
            return await NurseRepository.GetAll().Select(u => new NurseDto
            {
                Id = u.Id,
                FirstName = u.FirstName,
                LastName = u.LastName,
                UserName = u.UserName,
                Mail = u.Mail,
                NationalId = u.NationalId,
                Image = u.Image,
                Gender = u.Gender,
                PhoneNumber = u.PhoneNumber,
                DepartmentName = u.Department.Department_Name,
                NurseSpecialization = u.NurseSpecialization,
                NurseDegree = u.NurseDegree,
                CreatedDtm = u.CreatedDtm,
                IsActive = u.IsActive
            }).ToListAsync();
        }

        public async Task<IEnumerable<NurseDto>> GetNursesByState(bool state)
        {
            return await NurseRepository.GetNursesByState(state).Select(u => new NurseDto
            {
                Id = u.Id,
                FirstName = u.FirstName,
                LastName = u.LastName,
                UserName = u.UserName,
                Mail = u.Mail,
                NationalId = u.NationalId,
                Image = u.Image,
                Gender = u.Gender,
                PhoneNumber = u.PhoneNumber,
                DepartmentName = u.Department.Department_Name,
                NurseSpecialization = u.NurseSpecialization,
                NurseDegree = u.NurseDegree,
                CreatedDtm = u.CreatedDtm,
                IsActive = u.IsActive
            }).ToListAsync();
        }

        public async Task<IEnumerable<NurseDto>> GetNursesBySpecialization(string specialization)
        {
            return await NurseRepository.GetNursesBySpecialization(specialization).Select(u => new NurseDto
            {
                Id = u.Id,
                FirstName = u.FirstName,
                LastName = u.LastName,
                UserName = u.UserName,
                Mail = u.Mail,
                NationalId = u.NationalId,
                Image = u.Image,
                Gender = u.Gender,
                PhoneNumber = u.PhoneNumber,
                DepartmentName = u.Department.Department_Name,
                NurseSpecialization = u.NurseSpecialization,
                NurseDegree = u.NurseDegree,
                CreatedDtm = u.CreatedDtm,
                IsActive = u.IsActive
            }).ToListAsync();
        }
    

        public async Task<Nurse> UpdateNurse(NurseDto dto)
        {
            Nurse currentNurse = await NurseRepository.GetById(dto.Id);
            currentNurse = UserMapper.UpdateNurse(dto, currentNurse);
            CreatePasswordHash(dto.Password, out byte[] passwordHash, out byte[] passwordSalt);
            currentNurse.PasswordHash = passwordHash;
            currentNurse.PasswordSalt = passwordSalt;
            return await NurseRepository.Update(currentNurse);
        }

        public async Task<NurseDto> GetNurseById(int Nurse_id)
        {
            Nurse nurse = await NurseRepository.GetById(Nurse_id);
            NurseDto nurse_dto = UserMapper.ToNurseDto(nurse);
            return nurse_dto;
        }

        public async Task<NurseDto> GetNurseByName(string Nursename)
        {
            Nurse nurse = await NurseRepository.FindByName(Nursename);
            NurseDto nurse_dto = UserMapper.ToNurseDto(nurse);
            return nurse_dto;
        }


        public async Task<VitalSign> AddVitalSignes(VitalSigneDto VitalSigneDto)

        {
            var vitalsign = new VitalSign
            {
                Pressure = VitalSigneDto.Pressure,
                PulseRate = VitalSigneDto.PulseRate,
                Temperature = VitalSigneDto.Temperature,
                ECG = VitalSigneDto.ECG,
                RespirationRate = VitalSigneDto.RespirationRate,
                vitals_date = VitalSigneDto.vitals_date,
                NurseId = VitalSigneDto.NurseId,
                Patientid = VitalSigneDto.PatientId,

                Note =new Note
                {
                    Body= VitalSigneDto.NoteDto.Body,
                    NurseId= VitalSigneDto.NoteDto.NurseId,
                    CreatedDate= VitalSigneDto.NoteDto.CreatedDate,
                    Subject = VitalSigneDto.NoteDto.Subject,
                    IndoorPatientRecordId= VitalSigneDto.NoteDto.IndoorPatientRecordId


                }

            };
            return await VitalSignsRepository.Add(vitalsign);
        }

        public async Task<IEnumerable<VitalResponce>> GetVitalSignesByRangeOfDate(int PatientId, DateTime StartDate, DateTime EndDate)
        {
            return await VitalSignsRepository.GetVitalSignesByRangeOfDate(PatientId, StartDate, EndDate)
                .Select(r => new VitalResponce()
            { 
                NurseName = r.Nurse.FirstName,
                PatientName = r.Patient.FirstName,
                Pressure=r.Pressure,
                VitalsignId = r.Id,   
                PulseRate = r.PulseRate,
                Temperature = r.Temperature,
                ECG = r.ECG,
                RespirationRate = r.RespirationRate,
                vitals_date = r.vitals_date,
                NoteDto = new NoteDto()
                {
                    Body = r.Note.Body,
                    NurseId = r.Note.NurseId,
                    CreatedDate = r.Note.CreatedDate,
                    Subject = r.Note.Subject,
                    IndoorPatientRecordId = r.Note.IndoorPatientRecordId


                }

                })
                .ToListAsync();
        }
    }
}

