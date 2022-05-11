using Domain.Models.Labs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.IRepositories
{
    public interface ILabRequestRepository : IGenericRepository<LabRequest>
    {
        IQueryable<LabRequest> GetAllLabRequestsByDocId(int doctor_id);
        IQueryable<LabRequest> GetAllLabRequestsForAll();
        IQueryable<LabRequest> GetAllLabRequestsForPatient(int Patient_id);
        IQueryable<LabRequest> GetAllDoctorToPatientLabRequests(int Patient_id, int doctor_id);
        IQueryable<LabRequest> GetPatientLabRequestByDate(int Patient_id, DateTime LabRequestDate);
        IQueryable<LabRequest> GetDoctorLabRequestsByDate(int doctor_id, DateTime LabRequestDate);
    }
}
