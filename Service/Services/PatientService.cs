using Domain.Models;
using Domain.Models.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Repository.IRepositories;
using Repository.Repositories;
using Service.DTO;
using Service.DTO.Users;
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
    public class PatientService : UserService, IPatientService
    {
        private IAppointmentRepository AppointmentRepository { get; }
        private IPatientRepository PatientRepository { get; }
        private  IIndoorPatientRepository IndoorPatientRepository { get; }
        private IDoctorService DoctorService { get; }
        private IBillRepository BillRepository { get; }

        public PatientService(IUserRepository _UserRepository, IPatientRepository _PatientRepository, IConfiguration _Configuration
            , IDoctorService _DoctorService, IIndoorPatientRepository _IndoorPatientRepository
            , IAppointmentRepository _AppointmentRepository, IBillRepository _BillRepository)
            : base(_UserRepository, _Configuration)
        {
            PatientRepository = _PatientRepository;
            DoctorService = _DoctorService;
            IndoorPatientRepository = _IndoorPatientRepository;
            AppointmentRepository = _AppointmentRepository;
            BillRepository = _BillRepository;
        }

        public async Task<Patient> AddPatient(PatientDto dto)
        {
            Patient patient = UserMapper.ToPatient(dto);
            if(dto.Password != null)
            {
                CreatePasswordHash(dto.Password, out byte[] passwordHash, out byte[] passwordSalt);
                patient.PasswordHash = passwordHash;
                patient.PasswordSalt = passwordSalt;
            }
            return await PatientRepository.Add(patient);
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
                UserName = u.UserName,
                Mail = u.Mail,
                NationalId = u.NationalId,
                Image = u.Image,
                Gender = u.Gender,
                BloodType = u.BloodType,
                PhoneNumber = u.PhoneNumber,
                DepartmentName = u.Department.Department_Name,
                CreatedDtm = u.CreatedDtm,
                IsActive = u.IsActive
            }).ToListAsync();
        }

        public async Task<Patient> UpdatePatient(PatientDto dto)
        {
            Patient currentPatient = await PatientRepository.GetById(dto.Id);
            currentPatient = UserMapper.UpdatePatient(dto, currentPatient);
            if(dto.Password != null)
            {
                CreatePasswordHash(dto.Password, out byte[] passwordHash, out byte[] passwordSalt);
                currentPatient.PasswordHash = passwordHash;
                currentPatient.PasswordSalt = passwordSalt;
            }
            return await PatientRepository.Update(currentPatient);
        }

        public async Task<PatientDto> GetPatientById(int Patient_id)
        {
            Patient patient = await PatientRepository.GetById(Patient_id);
            if(patient != null)
            {
                PatientDto patient_dto = UserMapper.ToPatientDto(patient);
                return patient_dto;
            }
            return null;
        }

        public async Task<PatientDto> GetPatientByName(string Patientname)
        {
            Patient patient = await PatientRepository.FindByName(Patientname);
            if (patient != null)
            {
                PatientDto patient_dto = UserMapper.ToPatientDto(patient);
                return patient_dto;
            }
            return null;
        }

        public async Task<IEnumerable<AppointmentsForToday>> GetAppointmentsByPatientId(int PatientId)
        {
            return await AppointmentRepository.GetAppointmentsByPatientId(PatientId).Select(A => new AppointmentsForToday()
            {
                PatientName = A.Patient.FirstName + A.Patient.LastName,
                PatientId = A.PatientId,
                Age = A.Patient.Age,
                Complain = A.Complain,
                Examined = A.Examined,
                SlotTime = new TimeSpan(A.AppointmentDate.Hour, A.AppointmentDate.Minute, 0),
                Gender = A.Patient.Gender,
                AppointmentDate=A.AppointmentDate,
                DoctorName=A.Doctor.FirstName+A.Doctor.LastName

            }).ToListAsync();
        }

        public  async Task CancelAppointment(int PatientId, DateTime AppointmentDate)
        {
            var _Appointment = await AppointmentRepository.CancelAppointment(PatientId, AppointmentDate);
           await AppointmentRepository.Delete(_Appointment.Id);
        }

        public async Task<BillDto> GetPatientBill(int Patient_id)
        {
            IndoorPatientRecord currRecord = await IndoorPatientRepository.GetLastRecordBeforeDischarging(Patient_id);
            if(currRecord != null)
            {
                BillDto billDto = new BillDto()
                {
                    Id = currRecord.Bill.Id,
                    AppointmentsCharges = currRecord.Bill.AppointmentsCharges,
                    IndoorPatientRecordID = currRecord.Bill.IndoorPatientRecordID,
                    PrescriptionCharges = currRecord.Bill.PrescriptionCharges,
                    RoomCharges = currRecord.Bill.RoomCharges,
                    ScansCharges = currRecord.Bill.ScansCharges,
                    TestCharges = currRecord.Bill.TestCharges
                };
                return billDto;
            }
            return null;
        }
    }
}
