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
        Task<IEnumerable<DoctorDto>> GetDoctorsByState(bool state);
        Task<IEnumerable<DoctorDto>> GetDoctorsBySpecialization(string specialization);
        Task<Prescription> AddPrescription(PrescriptionDto PrescriptionDto);
        Task<IEnumerable<Prescription>> GetAllPrescriptionsByDoctorId(int doctor_id);
        Task<IEnumerable<Prescription>> GetAllPrescriptionsForALL();
        Task<Prescription> UpdatePrescription(PrescriptionDto PrescriptionDto);
        Task<IEnumerable<Prescription>> GetAllPrescriptonsForPatient(short Patient_id);
        Task<IEnumerable<Prescription>> GetAllDoctorToPatientPrescriptions(int Patient_id, int doctor_id);
        Task<IEnumerable<Prescription>> GetPatientPrescriptionByDate(int Patient_id, DateTime PrescriptionDate);
        Task<IEnumerable<Prescription>> GetDoctorPrescriptionsByDate(int doctor_id, DateTime PrescriptionDate);
        //Task<IEnumerable<scheduleDto>> GetSchedulesByDoctorId(int Department_ID);

        Task<IEnumerable<ScheduleResponce>> GetSchedulesByDepartment_Id(int Department_ID);
        Task<IEnumerable<Doctor>> GetDoctorsByDepartment_Id(int Department_ID);
        Task<IEnumerable<Schedule>> GetSchedulesByDoctor_Id(int Doctor_Id);

        Task<Schedule> UpdateSchedule(scheduleDto ScheduleDto);




    }
}
