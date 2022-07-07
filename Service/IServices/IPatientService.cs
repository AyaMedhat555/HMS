using Domain.Models.Users;
using Service.DTO.Users;
using Service.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.IServices
{
    public interface IPatientService : IUserService
    {
        Task<Patient> AddPatient(PatientDto doc);
        Task<Patient> UpdatePatient(PatientDto doc_dto);
        Task<IEnumerable<PatientDto>> GetAllPatients();
        Task<PatientDto> GetPatientById(int Patient_id);
        Task<Patient> DeletePatient(int Patient_id);
        Task<PatientDto> GetPatientByName(String Patientname);
        Task<IEnumerable<AppointmentsForToday>> GetAppointmentsByPatientId(int PatientId);
        Task CancelAppointment(int AppointmentId);
        Task<IEnumerable<Patient>> GetAllOutPatient();
        Task<Patient> GetPatientByNationalId(string NationalId);
    }
}
