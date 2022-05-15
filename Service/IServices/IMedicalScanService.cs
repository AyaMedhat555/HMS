using Domain.Models.Labs;
using Service.DTO;
using Service.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.IServices
{
    public interface IMedicalScanService
    {
        Task<Scan> AddScan(Scan Scan);
        Task<Scan> DeleteScan(int Scan_id);
        Task<Scan> UpdateScan(Scan Scan_dto);
        Task<IEnumerable<Scan>> GetAllScans();
        Task<Scan> GetScanById(int Scan_id);
        Task<Scan> GetScanByName(String ScanName);




        Task<ScanRequest> AddScanRequest(ScanRequestDto ScanRequest);
        Task<ScanRequest> DeleteScanRequest(int Scan_id);
        Task<ScanRequest> UpdateScanRequest(ScanRequestDto ScanRequest);
        Task<ScanRequest> GetScanRequestById(int Scan_id);
        Task<IEnumerable<ScanRequest>> GetScanRequestsByPatientId(int Patinet_id);
        Task<IEnumerable<ScanRequest>> GetScanRequestsByDoctorId(int Doctor_id);
        Task<IEnumerable<ScanRequest>> GetDoctorScanRequestsByDate(int Doctor_id, DateTime date);
        Task<IEnumerable<ScanRequest>> GetPatientScanRequestsByDate(int Patient_id, DateTime date);
        Task<IEnumerable<ScanRequest>> GetAllScanRequests();



        Task<PatientScan> AddPatientScan(PatientScanDto Scan);
        Task<PatientScan> DeletePatientScan(int Scan_id);
        Task<PatientScan> UpdatePatientScan(PatientScanDto Scan);
        Task<PateintScanResponse> GetPatientScanById(int Scan_id);
        Task<IEnumerable<PatientScan>> GetPatientScansByPatientId(int Patient_id);
        Task<IEnumerable<PatientScan>> GetPatientScansByDoctorId(int Doctor_id);
        Task<IEnumerable<PatientScan>> GetPatientScansByDate(int Patient_id, DateTime date);
        Task<IEnumerable<PatientScan>> GetDoctorScansByDate(int Doctor_id, DateTime date);
        Task<IEnumerable<PatientScan>> GetallPatientScans();
    }
}
