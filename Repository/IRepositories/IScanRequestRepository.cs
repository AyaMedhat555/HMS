using Domain.Models.Labs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.IRepositories
{
    public interface IScanRequestRepository : IGenericRepository<ScanRequest>
    {
        IQueryable<ScanRequest> GetAllScanRequestsByDocId(int doctor_id);
        IQueryable<ScanRequest> GetAllScanRequestsForAll();
        IQueryable<ScanRequest> GetAllScanRequestsForPatient(int Patient_id);
        IQueryable<ScanRequest> GetAllDoctorToPatientScanRequests(int Patient_id, int doctor_id);
        IQueryable<ScanRequest> GetPatientScanRequestByDate(int Patient_id, DateTime ScanRequestDate);
        IQueryable<ScanRequest> GetDoctorScanRequestsByDate(int doctor_id, DateTime ScanRequestDate);
    }
}
