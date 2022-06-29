using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.IRepositories
{
    public interface IIndoorPatientRepository : IGenericRepository<IndoorPatientRecord>
    {
       IQueryable <IndoorPatientRecord> GetInDoorPatientsByDept(int? DepartmentId);

       Task< IndoorPatientRecord> GetLastRecordBeforeDischarging(int PatientId);

        IndoorPatientRecord GetPatientReport(int PatientId, DateTime DateOfDischarge);

        IQueryable<DateTime?> GetDischargeDatesByPatientId(int PatientId);
        IQueryable<int> GetIndoorPatientRecords(int PatientId);
        IQueryable<IndoorPatientRecord> GetInDoorPatients();
        IQueryable<IndoorPatientRecord> GetDischargedPatients();

        IQueryable<IndoorPatientRecord> GetInDoorRecordsByPatientId(int PatientId);
       




    }
}
