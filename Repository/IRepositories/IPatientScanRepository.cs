using Domain.Models.Labs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.IRepositories
{
    public interface IPatientScanRepository : IGenericRepository<PatientScan>
    {
        IQueryable<PatientScan> GetAllPatientScansByDocId(int doctor_id);
        IQueryable<PatientScan> GetAllPatientScansForAll();
        IQueryable<PatientScan> GetAllPatientScansForPatient(int Patient_id);
        IQueryable<PatientScan> GetAllDoctorToPatientScans(int Patient_id, int doctor_id);
        IQueryable<PatientScan> GetPatientScanByDate(int Patient_id, DateTime PatientScanDate);
        IQueryable<PatientScan> GetDoctorScansByDate(int doctor_id, DateTime PatientScanDate);

        IQueryable<PatientScan> GetInDoorPatientScans(int InDoorPatientRecordId);
    }
}
