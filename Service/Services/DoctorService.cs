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
        private IPrescriptionRepository PrescriptionRepository { get; }
       
        public DoctorService(IUserRepository _UserRepository, IDoctorRepository _DoctorRepository, IConfiguration _Configuration, IPrescriptionRepository _PrescriptionRepository)
            : base(_UserRepository, _Configuration)
        {
            DoctorRepository = _DoctorRepository;
            PrescriptionRepository = _PrescriptionRepository;
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
                UserName = u.UserName,
                Mail = u.Mail,
                NationalId = u.NationalId,
                Image = u.Image,
                Gender = u.Gender,
                PhoneNumber = u.PhoneNumber,
                DepartmentName = u.Department.Department_Name,
                DocSpecialization = u.DocSpecialization,
                DocDegree = u.DocDegree,
                CreatedDtm = u.CreatedDtm,
                IsActive = u.IsActive
            }).ToListAsync();
        }

        public async Task<IEnumerable<DoctorDto>> GetDoctorsByState(bool state)
        {
            return await DoctorRepository.GetDoctorsByState(state).Select(u => new DoctorDto
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
                DocSpecialization = u.DocSpecialization,
                DocDegree = u.DocDegree,
                CreatedDtm = u.CreatedDtm,
                IsActive = u.IsActive
            }).ToListAsync();
        }

        public async Task<IEnumerable<DoctorDto>> GetDoctorsBySpecialization(string specialization)
        {
            return await DoctorRepository.GetDoctorsBySpecialization(specialization).Select(u => new DoctorDto
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
                DocSpecialization = u.DocSpecialization,
                DocDegree = u.DocDegree,
                CreatedDtm = u.CreatedDtm,
                IsActive = u.IsActive
            }).ToListAsync();
        }

        public async Task<Doctor> UpdateDoctor(DoctorDto dto)
        {
            Doctor currentDoctor = await DoctorRepository.GetById(dto.Id);
            currentDoctor = UserMapper.UpdateDoctor(dto, currentDoctor);
            CreatePasswordHash(dto.Password, out byte[] passwordHash, out byte[] passwordSalt);
            currentDoctor.PasswordHash = passwordHash;
            currentDoctor.PasswordSalt = passwordSalt;
            return await DoctorRepository.Update(currentDoctor);
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


        public async Task<Prescription> AddPrescription(PrescriptionDto PrescriptionDto)
        {
            var Prescription = new Prescription
            {
                DoctorId = PrescriptionDto.DoctorId,
                PatientId = PrescriptionDto.PatientId,
                Prescription_Date = PrescriptionDto.Prescription_Date,
                re_appointement_date = PrescriptionDto.re_appointement_date,
                PrescriptionItems = PrescriptionDto.PrescriptionItems,
                IndoorPatientRecordId = PrescriptionDto.IndoorPatientRecordId

            };

            return await PrescriptionRepository.Add(Prescription);
        }

        public async Task<IEnumerable<Prescription>> GetAllPrescriptionsByDoctorId(int doctor_id)
        {
            return await PrescriptionRepository.GetAllPrescriptonsByDocId(doctor_id).ToListAsync(); 
        }

        public async Task<IEnumerable<Prescription>> GetAllPrescriptionsForALL()
        {
            return await PrescriptionRepository.GetAllPrescriptonsForAll().ToListAsync(); 
        }

        public async  Task<IEnumerable<Prescription>> GetAllPrescriptonsForPatient(short Patient_id)
        {
            return await PrescriptionRepository.GetAllPrescriptonsForPatient(Patient_id).ToListAsync();
        }

        public async Task<IEnumerable<Prescription>> GetAllDoctorToPatientPrescriptions(int Patient_id, int doctor_id)
        {
            return await PrescriptionRepository.GetAllDoctorToPatientPrescriptions(Patient_id, doctor_id).ToListAsync();
        }

        public async Task<IEnumerable<Prescription>> GetPatientPrescriptionByDate(int Patient_id, DateTime PrescriptionDate)
        {
            return await PrescriptionRepository.GetPatientPrescriptionByDate(Patient_id, PrescriptionDate).ToListAsync();
        }

        public async Task<IEnumerable<Prescription>> GetDoctorPrescriptionsByDate(int doctor_id, DateTime PrescriptionDate)
        {
            return await PrescriptionRepository.GetDoctorPrescriptionsByDate(doctor_id, PrescriptionDate).ToListAsync();
        }



        public async Task<Prescription> UpdatePrescription(PrescriptionDto PrescriptionDto)
        {
            var Prescription = new Prescription()
            {

                PatientId = PrescriptionDto.PatientId,
                DoctorId = PrescriptionDto.DoctorId,
                Prescription_Date = PrescriptionDto.Prescription_Date,
                re_appointement_date = PrescriptionDto.re_appointement_date,
                PrescriptionItems = PrescriptionDto.PrescriptionItems
            };

            return await PrescriptionRepository.Update(Prescription);
        }
    }
}
