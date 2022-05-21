using SmartHospital.Models.Labs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.IRepositories
{
    public interface IPatientTestRepository : IGenericRepository<PatientTest>
    {
        IQueryable<PatientTest> GetAllPatientTestsByDocId(int doctor_id);
        IQueryable<PatientTest> GetAllPatientTestsForAll();
        IQueryable<PatientTest> GetAllPatientTestsForPatient(int Patient_id);
        IQueryable<PatientTest> GetAllDoctorToPatientTests(int Patient_id, int doctor_id);
        IQueryable<PatientTest> GetPatientTestByDate(int Patient_id, DateTime PatientTestDate);
        IQueryable<PatientTest> GetDoctorTestsByDate(int doctor_id, DateTime PatientTestDate);

        IQueryable<PatientTest> GetInDoorPatientTests(int InDoorPatientRecordId);

    }
}
