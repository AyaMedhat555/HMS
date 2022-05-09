using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Repository;
using Repository.IRepositories;
using Service.DTO;
using Service.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class DoctorService : IDoctorService
    {
        private IDoctorRepository DoctorRepository { get; }
        private IPrescriptionRepository PrescriptionRepository { get; }
       
        public DoctorService(IDoctorRepository _DoctorRepository, IPrescriptionRepository _PrescriptionRepository)
        {
            DoctorRepository = _DoctorRepository;
            PrescriptionRepository = _PrescriptionRepository;
        }

        public async Task<Doctor> AddDoctor(DoctorDto dto)
        {
            var doctor = new Doctor
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Age = dto.Age,
                NationalId = dto.NationalId,
                BloodType = dto.BloodType,
                PhoneNumber = dto.PhoneNumber,
                Gender = dto.Gender,
                
                Address = dto.Address,
                DocDegree = dto.DocDegree,
                Docspecialization = dto.Docspecialization

            };
            return await DoctorRepository.Add(doctor);
        }

        public async Task<Doctor> DeleteDoctor(int Doctor_id)
        {
            return await DoctorRepository.Delete(Doctor_id);
        }

        public async Task<IEnumerable<Doctor>> GetAllDoctors()
        {
            return await DoctorRepository.GetAll().ToListAsync();
        }

       

        public Task<DoctorDto> GetDoctorByName(string Doctorname)
        {
            throw new NotImplementedException();
        }

        public Task<string> Login(LoginRequest logInUser)
        {
            throw new NotImplementedException();
        }

        public Task<Doctor> UpdateDoctor(DoctorDto doc_dto)
        {
            throw new NotImplementedException();
        }

        public Task<DoctorDto> GetDoctorById(int Doctor_id)
        {
            throw new NotImplementedException();
        }

       
       public async Task<Prescription> AddPrescription(PrescriptionDto PrescriptionDto)
        {
            var Prescription = new Prescription
            {
                DoctorId = PrescriptionDto.DoctorId,
                PatientId = PrescriptionDto.PatientId,
                Prescription_Date = PrescriptionDto.Prescription_Date,
                re_appointement_date = PrescriptionDto.re_appointement_date,
                PrescriptionItems = PrescriptionDto.PrescriptionItems

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
