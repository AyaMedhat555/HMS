using Domain.Models;
using Service.DTO;
using Service.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.IServices
{
    public interface IIndoorPatientService
    {
        Task ReservePatient(ReservePatientDto ReservePatientDto);
        Task<IEnumerable<InDoorPatientsInfo>> GetInDoorPatientsByDept(int DepartmentId);
        Task<DoctorPrescriptionResponce> GetLastPrescriptionByIndoorPatientId(int IndoorPatientRecordId);
        Task <IEnumerable<DateTime?>> GetDischargeDatesByPatientId(int PatientId);
        Task<IEnumerable<int>> GetIndoorPatientRecords(int PatientId);
        Task<IEnumerable<PatientRecordResponce>> GetInDoorRecordsByPatientId(int PatientId);
        Task<IEnumerable<IndoorPatientRecord>> GetInDoorRecords();


    }
}
