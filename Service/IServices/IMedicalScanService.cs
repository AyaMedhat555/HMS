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
        Task<ScanRequestResponse> GetScanRequestById(int Scan_id);
        Task<IEnumerable<ScanRequestResponse>> GetScanRequestsByPatientId(int Patinet_id);
        Task<IEnumerable<ScanRequestResponse>> GetScanRequestsByDoctorId(int Doctor_id);
        Task<IEnumerable<ScanRequestResponse>> GetDoctorScanRequestsByDate(int Doctor_id, DateTime date);
        Task<IEnumerable<ScanRequestResponse>> GetPatientScanRequestsByDate(int Patient_id, DateTime date);
        Task<IEnumerable<ScanRequestResponse>> GetAllScanRequests();



        Task<PatientScan> AddPatientScan(PatientScanDto Scan);
        Task<PatientScan> DeletePatientScan(int Scan_id);
        Task<PatientScan> UpdatePatientScan(PatientScanDto Scan);
        Task<PatientScanResponse> GetPatientScanById(int Scan_id);
        Task<IEnumerable<PatientScanResponse>> GetPatientScansByPatientId(int Patient_id);
        Task<IEnumerable<PatientScanResponse>> GetPatientScansByDoctorId(int Doctor_id);
        Task<IEnumerable<PatientScanResponse>> GetPatientScansByDate(int Patient_id, DateTime date);
        Task<IEnumerable<PatientScanResponse>> GetDoctorScansByDate(int Doctor_id, DateTime date);
        Task<IEnumerable<PatientScanResponse>> GetallPatientScans();
    }
}
