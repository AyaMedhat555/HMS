using Domain.Models;
using Domain.Models.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Repository;
using Repository.IRepositories;
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
    public class DoctorService : UserService, IDoctorService
    {
        private IDoctorRepository DoctorRepository { get; }
        private IUserRepository UserRepository { get; }
        private IPrescriptionRepository PrescriptionRepository { get; }
        private IScheduleRepository ScheduleRepository { get; }
        private IAppointmentRepository AppointmentRepository { get; }
        private IIndoorPatientRepository IndoorPatientRepository { get; }

        public DoctorService(IUserRepository _UserRepository, IConfiguration _Configuration, IDoctorRepository _DoctorRepository, IPrescriptionRepository _PrescriptionRepository, IScheduleRepository _ScheduleRepository, IAppointmentRepository _AppointmentRepository, IIndoorPatientRepository _IndoorPatientRepository)
            : base(_UserRepository, _Configuration)
        {
            DoctorRepository = _DoctorRepository;
            PrescriptionRepository = _PrescriptionRepository;
            ScheduleRepository = _ScheduleRepository;
            AppointmentRepository = _AppointmentRepository;
            IndoorPatientRepository = _IndoorPatientRepository;
        }

        public async Task<Doctor> AddDoctor(DoctorDto dto)
        {
            Doctor doctor = UserMapper.ToDoctor(dto);
            if(dto.Password != null)
            {
                CreatePasswordHash(dto.Password, out byte[] passwordHash, out byte[] passwordSalt);
                doctor.PasswordHash = passwordHash;
                doctor.PasswordSalt = passwordSalt;
            }
            return await DoctorRepository.Add(doctor);
        }

        public async Task<Doctor> DeleteDoctor(int Doctor_id)
        {
            return await DoctorRepository.Delete(Doctor_id);
        }

        public async Task<IEnumerable<DoctorDto>> GetAllDoctors()
        {
            return await DoctorRepository.GetAllDoctors().Select(u => UserMapper.ToDoctorDto(u)).ToListAsync();
        }

        public async Task<IEnumerable<DoctorDto>> GetDoctorsByState(bool state)
        {
            return await DoctorRepository.GetDoctorsByState(state).Select(u => UserMapper.ToDoctorDto(u)).ToListAsync();
        }

        public async Task<IEnumerable<DoctorDto>> GetDoctorsBySpecialization(string specialization)
        {
            return await DoctorRepository.GetDoctorsBySpecialization(specialization).Select(u => UserMapper.ToDoctorDto(u)).ToListAsync();
        }

        public async Task<Doctor> UpdateDoctor(DoctorDto dto)
        {
            Doctor currentDoctor = await DoctorRepository.GetById(dto.Id);
            currentDoctor = UserMapper.UpdateDoctor(dto, currentDoctor);
            if (dto.Password != null)
            {
                CreatePasswordHash(dto.Password, out byte[] passwordHash, out byte[] passwordSalt);
                currentDoctor.PasswordHash = passwordHash;
                currentDoctor.PasswordSalt = passwordSalt;
            }
            return await DoctorRepository.Update(currentDoctor);
        }

        public async Task<DoctorDto> GetDoctorById(int Doctor_id)
        {
            Doctor doc = await DoctorRepository.GetDoctorById(Doctor_id);
            if (doc != null)
            {
                DoctorDto doc_dto = UserMapper.ToDoctorDto(doc);
                return doc_dto;
            }
            return null;
        }

        public async Task<DoctorDto> GetDoctorByName(string Doctorname)
        {
            Doctor doc = await DoctorRepository.FindByName(Doctorname);
            if (doc != null)
            {
                DoctorDto doc_dto = UserMapper.ToDoctorDto(doc);
                return doc_dto;
            }
            return null;
        }


        public async Task<Prescription> AddPrescription(PrescriptionDto PrescriptionDto)
        {
            var Prescription = new Prescription
            {
                DoctorId = PrescriptionDto.DoctorId,
                PatientId = PrescriptionDto.PatientId,
                Diagnosis = PrescriptionDto.Diagnosis,
                Prescription_Date = PrescriptionDto.Prescription_Date,
                re_appointement_date = PrescriptionDto.re_appointement_date,
                PrescriptionItems = PrescriptionDto.PrescriptionItems,
                IndoorPatientRecordId = PrescriptionDto.IndoorPatientRecordId

            };

            return await PrescriptionRepository.Add(Prescription);
        }

        public async Task <DoctorPrescriptionResponce> GetAllPrescriptionsByDoctorId(int doctor_id)
        {

            DoctorPrescriptionResponce _DoctorPrescriptionResponce = new DoctorPrescriptionResponce();
            List<Prescription> Presciptions = await PrescriptionRepository.GetAllPrescriptonsByDocId(doctor_id).ToListAsync();
            _DoctorPrescriptionResponce.Presciption = Presciptions.Select(P =>
              new Prescription
              {
                  PrescriptionId = P.PrescriptionId,
                  DoctorId = P.DoctorId,
                  PatientId = P.PatientId,
                  Diagnosis = P.Diagnosis,
                  Prescription_Date = P.Prescription_Date,
                  re_appointement_date = P.re_appointement_date,
                  PrescriptionItems = P.PrescriptionItems,
                  IndoorPatientRecordId = P.IndoorPatientRecordId
              }).ToList();

            _DoctorPrescriptionResponce.Department = await PrescriptionRepository.GetAllPrescriptonsByDocId(doctor_id).Select(P=> P.Doctor.Department.Department_Name).FirstOrDefaultAsync();
            _DoctorPrescriptionResponce.DoctorFullName = Presciptions.Select(P => P.Doctor.FirstName).FirstOrDefault() + Presciptions.Select(P => P.Doctor.FirstName).FirstOrDefault();
            return _DoctorPrescriptionResponce;

        }

        public async Task<IEnumerable<DoctorPrescriptionResponce>> GetAllPrescriptionsForALL()
        {
            return await PrescriptionRepository.GetAllPrescriptonsForAll().Select(
                P=> new DoctorPrescriptionResponce()
                {
                   Department=P.Doctor.Department.Department_Name,
                   DoctorFullName=P.Doctor.FirstName+P.Doctor.LastName,
                   Prescription=new Prescription()
                   {

                       PrescriptionId = P.PrescriptionId,
                       DoctorId = P.DoctorId,
                       PatientId = P.PatientId,
                       Diagnosis = P.Diagnosis,
                       Prescription_Date = P.Prescription_Date,
                       re_appointement_date = P.re_appointement_date,
                       PrescriptionItems = P.PrescriptionItems,
                       IndoorPatientRecordId = P.IndoorPatientRecordId
                   }

                }

                ).ToListAsync(); 
        }
        public async  Task<IEnumerable<DoctorPrescriptionResponce>> GetAllPrescriptonsForPatient(short Patient_id)
        {
            
          return await PrescriptionRepository.GetAllPrescriptonsForPatient(Patient_id).Select(
               P => new DoctorPrescriptionResponce()
               {
                   Department = P.Doctor.Department.Department_Name,
                   DoctorFullName = P.Doctor.FirstName + P.Doctor.LastName,
                   Prescription = new Prescription()
                   {

                       PrescriptionId = P.PrescriptionId,
                       DoctorId = P.DoctorId,
                       PatientId = P.PatientId,
                       Diagnosis = P.Diagnosis,
                       Prescription_Date = P.Prescription_Date,
                       re_appointement_date = P.re_appointement_date,
                       PrescriptionItems = P.PrescriptionItems,
                       IndoorPatientRecordId = P.IndoorPatientRecordId
                   }

               }

               ).ToListAsync();
        }

        public async Task<IEnumerable<DoctorPrescriptionResponce>> GetAllDoctorToPatientPrescriptions(int Patient_id, int doctor_id)
        {
            return
            await PrescriptionRepository.GetAllDoctorToPatientPrescriptions(Patient_id, doctor_id).Select(
               P => new DoctorPrescriptionResponce()
               {
                   Department = P.Doctor.Department.Department_Name,
                   DoctorFullName = P.Doctor.FirstName + P.Doctor.LastName,
                   Prescription = new Prescription()
                   {

                       PrescriptionId = P.PrescriptionId,
                       DoctorId = P.DoctorId,
                       PatientId = P.PatientId,
                       Diagnosis = P.Diagnosis,
                       Prescription_Date = P.Prescription_Date,
                       re_appointement_date = P.re_appointement_date,
                       PrescriptionItems = P.PrescriptionItems,
                       IndoorPatientRecordId = P.IndoorPatientRecordId
                   }

               }

               ).ToListAsync();
        }

        public async Task<IEnumerable<DoctorPrescriptionResponce>> GetPatientPrescriptionByDate(int Patient_id, DateTime PrescriptionDate)
        {
            return 
            await PrescriptionRepository.GetPatientPrescriptionByDate(Patient_id, PrescriptionDate).Select(
              P => new DoctorPrescriptionResponce()
              {
                  Department = P.Doctor.Department.Department_Name,
                  DoctorFullName = P.Doctor.FirstName + P.Doctor.LastName,
                  Prescription = new Prescription()
                  {

                      PrescriptionId = P.PrescriptionId,
                      DoctorId = P.DoctorId,
                      PatientId = P.PatientId,
                      Diagnosis = P.Diagnosis,
                      Prescription_Date = P.Prescription_Date,
                      re_appointement_date = P.re_appointement_date,
                      PrescriptionItems = P.PrescriptionItems,
                      IndoorPatientRecordId = P.IndoorPatientRecordId
                  }

              }

              ).ToListAsync();
        }

        public async Task<DoctorPrescriptionResponce> GetDoctorPrescriptionsByDate(int doctor_id, DateTime PrescriptionDate)
        {
            
            DoctorPrescriptionResponce _DoctorPrescriptionResponce = new DoctorPrescriptionResponce();
            List<Prescription> Presciptions = await PrescriptionRepository.GetDoctorPrescriptionsByDate(doctor_id, PrescriptionDate).ToListAsync();
            _DoctorPrescriptionResponce.Presciption = Presciptions.Select(P =>
              new Prescription
              {
                  PrescriptionId = P.PrescriptionId,
                  DoctorId = P.DoctorId,
                  PatientId = P.PatientId,
                  Diagnosis = P.Diagnosis,
                  Prescription_Date = P.Prescription_Date,
                  re_appointement_date = P.re_appointement_date,
                  PrescriptionItems = P.PrescriptionItems,
                  IndoorPatientRecordId = P.IndoorPatientRecordId
              }).ToList();

            _DoctorPrescriptionResponce.Department = await PrescriptionRepository.GetDoctorPrescriptionsByDate(doctor_id, PrescriptionDate).Select(P => P.Doctor.Department.Department_Name).FirstOrDefaultAsync();
            _DoctorPrescriptionResponce.DoctorFullName = Presciptions.Select(P => P.Doctor.FirstName).FirstOrDefault() + Presciptions.Select(P => P.Doctor.FirstName).FirstOrDefault();
            return _DoctorPrescriptionResponce;

        }



        public async Task<Prescription> UpdatePrescription(PrescriptionDto PrescriptionDto)
        {
            var Prescription = new Prescription()
            {

                PatientId = PrescriptionDto.PatientId,
                Diagnosis=PrescriptionDto.Diagnosis,
                DoctorId = PrescriptionDto.DoctorId,
                Prescription_Date = PrescriptionDto.Prescription_Date,
                re_appointement_date = PrescriptionDto.re_appointement_date,
                PrescriptionItems = PrescriptionDto.PrescriptionItems
            };

            return await PrescriptionRepository.Update(Prescription);
        }

       

        public async Task<IEnumerable<Doctor>> GetDoctorsByDepartment_Id(int Department_ID)
        {
           return await DoctorRepository.GetDoctorsByDepartment_Id(Department_ID).ToListAsync();
        }

      

        public async Task ExaminedApoointment(ExaminedAppointment ExaminedAppointment)
        {
            Appointment examinedAppointment =await AppointmentRepository.GetById(ExaminedAppointment.AppointmentId);
            examinedAppointment.Examined = ExaminedAppointment.Examined;
            AppointmentRepository.Update(examinedAppointment);
        }

        public async Task<IEnumerable<AppointmentsForToday>> GetAppointmentsForTodayByDoctorId(DateTime Today, int DoctorId)
        {
            return await AppointmentRepository.GetAppointmentsForTodayByDoctorId(Today, DoctorId).Select(A => new AppointmentsForToday()
            {
                PatientName = A.Patient.FirstName + A.Patient.LastName,
                PatientId=A.PatientId,
                Age=A.Patient.Age,
                Complain=A.Complain,
                Examined=A.Examined,
                SlotTime= new TimeSpan (A.AppointmentDate.Hour, A.AppointmentDate.Minute,0),
                Gender=A.Patient.Gender

            }).ToListAsync();
        }

        public async Task<AppointmentDetails> GetAppointmentsDetailsByDoctorId(int DoctorId,DateTime Today)
        {
           Doctor _Doctor=await DoctorRepository.GetDoctorById(DoctorId);
            int? DeptId = _Doctor.DepartmentId;


            AppointmentDetails _AppointmentDetails = new AppointmentDetails();
            _AppointmentDetails.NumberOfTodayAppointment = AppointmentRepository.GetAppointmentsForTodayByDoctorId(Today, DoctorId).Count();
            _AppointmentDetails.NumberOfAllAppointments = AppointmentRepository.GetAllAppointmentsByDoctorId(DoctorId).Count();
            _AppointmentDetails.NumberOfInDoorPatients = IndoorPatientRepository.GetInDoorPatientsByDept(DeptId).Count();
            return _AppointmentDetails;
        }

        public Task<Prescription> GetPrescriptionById(int PrescriptionId)
        {
           return PrescriptionRepository.GetPrescriptionById(PrescriptionId);
        }
    }
}
