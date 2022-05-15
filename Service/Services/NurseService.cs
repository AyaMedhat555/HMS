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
                DepartmentId = u.DepartmentId
            }).ToListAsync();
        }

        public async Task<Nurse> UpdateNurse(NurseDto dto)
        {
            Nurse nurse = UserMapper.ToNurse(dto);
            CreatePasswordHash(dto.Password, out byte[] passwordHash, out byte[] passwordSalt);
            nurse.PasswordHash = passwordHash;
            nurse.PasswordSalt = passwordSalt;
            return await NurseRepository.Update(nurse);
        }

        public async Task<NurseDto> GetNurseById(int Nurse_id)
        {
            Nurse doc = await NurseRepository.GetById(Nurse_id);
            NurseDto doc_dto = UserMapper.ToNurseDto(doc);
            return doc_dto;
        }

        public async Task<NurseDto> GetNurseByName(string Nursename)
        {
            Nurse doc = await NurseRepository.FindByName(Nursename);
            NurseDto doc_dto = UserMapper.ToNurseDto(doc);
            return doc_dto;
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
                Note = VitalSigneDto.Note

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
                 Note = r.Note

                })

                .ToListAsync();
        }

       


    }
}

