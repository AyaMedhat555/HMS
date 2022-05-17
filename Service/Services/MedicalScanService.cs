using Domain.Models.Labs;
using Microsoft.EntityFrameworkCore;
using Repository.IRepositories;
using Service.DTO;
using Service.IServices;
using Service.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class MedicalScanService : IMedicalScanService
    {
        private IGenericRepository<Scan> ScanRepository { get; }
        private IPatientScanRepository PatientScanRepository { get; }
        private IScanRequestRepository ScanRequestRepository { get; }

        public MedicalScanService(IGenericRepository<Scan> scanRepository, IPatientScanRepository patientScanRepository, IScanRequestRepository scanRequestRepository)
        {
            ScanRepository=scanRepository;
            PatientScanRepository=patientScanRepository;
            ScanRequestRepository=scanRequestRepository;
        }


        //######################################################################################################
        //Scan

        public async Task<Scan> AddScan(Scan Scan)
        {
            return await ScanRepository.Add(Scan);
        }
        public async Task<Scan> DeleteScan(int Scan_id)
        {
            return await ScanRepository.Delete(Scan_id);
        }
        public async Task<Scan> UpdateScan(Scan Scan_dto)
        {
            return await ScanRepository.Update(Scan_dto);
        }
        public async Task<IEnumerable<Scan>> GetAllScans()
        {
            return await ScanRepository.GetAll().ToListAsync();
        }

        public async Task<Scan> GetScanById(int Scan_id)
        {
            return await ScanRepository.GetById(Scan_id);
        }

        public async Task<Scan> GetScanByName(string Scanname)
        {
            var Scans = GetAllScans().Result;
            return Scans.SingleOrDefault(T => T.ScanName == Scanname);
        }



        //######################################################################################################
        //Scan REQUEST

        public async Task<ScanRequest> AddScanRequest(ScanRequestDto ScanRequest)
        {
            int scanId = await ScanRepository.GetAll().Where(S => S.ScanName == ScanRequest.ScanName).Select(T => T.Id).SingleOrDefaultAsync();
            ScanRequest newScanRequest = new ScanRequest()
            {
                ScanId = scanId,
                CreatedDtm = DateTime.Now,
                DoctorId = ScanRequest.DoctorId,
                PatientId = ScanRequest.PatientId
            };
            return await ScanRequestRepository.Add(newScanRequest);
        }

        public async Task<ScanRequest> DeleteScanRequest(int Scan_id)
        {
            return await ScanRequestRepository.Delete(Scan_id);
        }

        public async Task<ScanRequest> UpdateScanRequest(ScanRequestDto ScanRequest)
        {
            int scanId = await ScanRepository.GetAll().Where(S => S.ScanName == ScanRequest.ScanName).Select(T => T.Id).SingleOrDefaultAsync();
            ScanRequest newScanRequest = new ScanRequest()
            {
                ScanId = scanId,
                CreatedDtm = DateTime.Now,
                DoctorId = ScanRequest.DoctorId,
                PatientId = ScanRequest.PatientId
            };
            return await ScanRequestRepository.Update(newScanRequest);
        }

        public async Task<ScanRequestResponse> GetScanRequestById(int Scan_id)
        {
            ScanRequest scanRequest = await ScanRequestRepository.GetById(Scan_id);
            ScanRequestResponse scanRequestResponse = new ScanRequestResponse()
            {
                Id = scanRequest.Id,
                ScanName = scanRequest.Scan.ScanName,
                ScanId = scanRequest.Scan.Id,
                CreatedDtm = scanRequest.CreatedDtm,
                DoctorName = scanRequest.Doctor.FirstName+" "+scanRequest.Doctor.LastName,
                PatientName = scanRequest.Patient.FirstName+" "+scanRequest.Patient.LastName,
                DoctorId = scanRequest.DoctorId,
                PatientId = scanRequest.PatientId
            };
            return scanRequestResponse;
        }

        public async Task<IEnumerable<ScanRequestResponse>> GetScanRequestsByPatientId(int Patinet_id)
        {
            List<ScanRequest> requests = await ScanRequestRepository.GetAllScanRequestsForPatient(Patinet_id).ToListAsync();
            List<ScanRequestResponse> requestsResponse = new List<ScanRequestResponse>();
            foreach (ScanRequest scanRequest in requests)
            {
                ScanRequestResponse response = new ScanRequestResponse()
                {
                    Id = scanRequest.Id,
                    ScanName = scanRequest.Scan.ScanName,
                    ScanId = scanRequest.Scan.Id,
                    CreatedDtm = scanRequest.CreatedDtm,
                    DoctorName = scanRequest.Doctor.FirstName+" "+scanRequest.Doctor.LastName,
                    PatientName = scanRequest.Patient.FirstName+" "+scanRequest.Patient.LastName,
                    DoctorId = scanRequest.DoctorId,
                    PatientId = scanRequest.PatientId
                };
                requestsResponse.Add(response);
            }
            return requestsResponse;
        }

        public async Task<IEnumerable<ScanRequestResponse>> GetScanRequestsByDoctorId(int Doctor_id)
        {
            List<ScanRequest> requests = await ScanRequestRepository.GetAllScanRequestsByDocId(Doctor_id).ToListAsync();
            List<ScanRequestResponse> requestsResponse = new List<ScanRequestResponse>();
            foreach (ScanRequest scanRequest in requests)
            {
                ScanRequestResponse response = new ScanRequestResponse()
                {
                    Id = scanRequest.Id,
                    ScanName = scanRequest.Scan.ScanName,
                    ScanId = scanRequest.Scan.Id,
                    CreatedDtm = scanRequest.CreatedDtm,
                    DoctorName = scanRequest.Doctor.FirstName+" "+scanRequest.Doctor.LastName,
                    PatientName = scanRequest.Patient.FirstName+" "+scanRequest.Patient.LastName,
                    DoctorId = scanRequest.DoctorId,
                    PatientId = scanRequest.PatientId
                };
                requestsResponse.Add(response);
            }
            return requestsResponse;
        }

        public async Task<IEnumerable<ScanRequestResponse>> GetDoctorScanRequestsByDate(int Doctor_id, DateTime date)
        {
            List<ScanRequest> requests = await ScanRequestRepository.GetDoctorScanRequestsByDate(Doctor_id, date).ToListAsync();
            List<ScanRequestResponse> requestsResponse = new List<ScanRequestResponse>();
            foreach (ScanRequest scanRequest in requests)
            {
                ScanRequestResponse response = new ScanRequestResponse()
                {
                    Id = scanRequest.Id,
                    ScanName = scanRequest.Scan.ScanName,
                    ScanId = scanRequest.Scan.Id,
                    CreatedDtm = scanRequest.CreatedDtm,
                    DoctorName = scanRequest.Doctor.FirstName+" "+scanRequest.Doctor.LastName,
                    PatientName = scanRequest.Patient.FirstName+" "+scanRequest.Patient.LastName,
                    DoctorId = scanRequest.DoctorId,
                    PatientId = scanRequest.PatientId
                };
                requestsResponse.Add(response);
            }
            return requestsResponse;
        }

        public async Task<IEnumerable<ScanRequestResponse>> GetPatientScanRequestsByDate(int Patient_id, DateTime date)
        {
            List<ScanRequest> requests = await ScanRequestRepository.GetPatientScanRequestByDate(Patient_id, date).ToListAsync();
            List<ScanRequestResponse> requestsResponse = new List<ScanRequestResponse>();
            foreach (ScanRequest scanRequest in requests)
            {
                ScanRequestResponse response = new ScanRequestResponse()
                {
                    Id = scanRequest.Id,
                    ScanName = scanRequest.Scan.ScanName,
                    ScanId = scanRequest.Scan.Id,
                    CreatedDtm = scanRequest.CreatedDtm,
                    DoctorName = scanRequest.Doctor.FirstName+" "+scanRequest.Doctor.LastName,
                    PatientName = scanRequest.Patient.FirstName+" "+scanRequest.Patient.LastName,
                    DoctorId = scanRequest.DoctorId,
                    PatientId = scanRequest.PatientId
                };
                requestsResponse.Add(response);
            }
            return requestsResponse;
        }

        public async Task<IEnumerable<ScanRequestResponse>> GetAllScanRequests()
        {
            List<ScanRequest> requests = await ScanRequestRepository.GetAll().ToListAsync();
            List<ScanRequestResponse> requestsResponse = new List<ScanRequestResponse>();
            foreach (ScanRequest scanRequest in requests)
            {
                ScanRequestResponse response = new ScanRequestResponse()
                {
                    Id = scanRequest.Id,
                    ScanName = scanRequest.Scan.ScanName,
                    ScanId = scanRequest.Scan.Id,
                    CreatedDtm = scanRequest.CreatedDtm,
                    DoctorName = scanRequest.Doctor.FirstName+" "+scanRequest.Doctor.LastName,
                    PatientName = scanRequest.Patient.FirstName+" "+scanRequest.Patient.LastName,
                    DoctorId = scanRequest.DoctorId,
                    PatientId = scanRequest.PatientId
                };
                requestsResponse.Add(response);
            }
            return requestsResponse;
        }



        //######################################################################################################
        //PATIENT Scan

        public async Task<PatientScan> AddPatientScan(PatientScanDto Scan)
        {
            int ReqId = Scan.ScanRequestId;
            ScanRequest scanRequest = await ScanRequestRepository.GetById(ReqId);
            PatientScan newScan = new PatientScan()
            {
                Image = Scan.Image,
                WrittenReport = Scan.WrittenReport,
                ScanDate = DateTime.Now,
                DoctorId = scanRequest.DoctorId,
                PatientId = scanRequest.PatientId,
                ScanId = scanRequest.ScanId
            };
            await DeleteScanRequest(ReqId);
            return await PatientScanRepository.Add(newScan);
        }

        public async Task<PatientScan> DeletePatientScan(int Scan_id)
        {
            return await PatientScanRepository.Delete(Scan_id);
        }

        public async Task<PatientScan> UpdatePatientScan(PatientScanDto Scan)
        {
            int ReqId = Scan.ScanRequestId;
            ScanRequest scanRequest = await ScanRequestRepository.GetById(ReqId);
            PatientScan newScan = new PatientScan()
            {
                Image = Scan.Image,
                WrittenReport = Scan.WrittenReport,
                ScanDate = Scan.ScanDate,
                DoctorId = scanRequest.DoctorId,
                PatientId = scanRequest.PatientId,
                ScanId = scanRequest.ScanId
            };
            return await PatientScanRepository.Update(newScan);
        }

        public async Task<PatientScanResponse> GetPatientScanById(int Scan_id)
        {
            PatientScan patientScan = await PatientScanRepository.GetById(Scan_id);
            PatientScanResponse pateintScanResponse = new PatientScanResponse()
            {
                Image = patientScan.Image,
                WrittenReport = patientScan.WrittenReport,
                DoctorId = patientScan.DoctorId,
                PatientId = patientScan.PatientId,
                ScanName = patientScan.Scan.ScanName,
                PatientScanId = patientScan.PatientScanId,
                ScanDate = patientScan.ScanDate
            };
            return pateintScanResponse;
        }

        public async Task<IEnumerable<PatientScanResponse>> GetPatientScansByPatientId(int Patient_id)
        {
            List<PatientScan> patientScans =  await PatientScanRepository.GetAllPatientScansForPatient(Patient_id).ToListAsync();
            List<PatientScanResponse> patientScansResponses = new List<PatientScanResponse>();
            foreach(var patientScan in patientScans)
            {
                PatientScanResponse pateintScanResponse = new PatientScanResponse()
                {
                    Image = patientScan.Image,
                    WrittenReport = patientScan.WrittenReport,
                    DoctorId = patientScan.DoctorId,
                    PatientId = patientScan.PatientId,
                    ScanName = patientScan.Scan.ScanName,
                    PatientScanId = patientScan.PatientScanId,
                    ScanDate = patientScan.ScanDate
                };
                patientScansResponses.Add(pateintScanResponse);
            }
            return patientScansResponses;
        }

        public async Task<IEnumerable<PatientScanResponse>> GetPatientScansByDoctorId(int Doctor_id)
        {
            List<PatientScan> patientScans = await PatientScanRepository.GetAllPatientScansByDocId(Doctor_id).ToListAsync();
            List<PatientScanResponse> patientScansResponses = new List<PatientScanResponse>();
            foreach (var patientScan in patientScans)
            {
                PatientScanResponse pateintScanResponse = new PatientScanResponse()
                {
                    Image = patientScan.Image,
                    WrittenReport = patientScan.WrittenReport,
                    DoctorId = patientScan.DoctorId,
                    PatientId = patientScan.PatientId,
                    ScanName = patientScan.Scan.ScanName,
                    PatientScanId = patientScan.PatientScanId,
                    ScanDate = patientScan.ScanDate
                };
                patientScansResponses.Add(pateintScanResponse);
            }
            return patientScansResponses;
        }

        public async Task<IEnumerable<PatientScanResponse>> GetPatientScansByDate(int Patient_id, DateTime date)
        {
            List<PatientScan> patientScans = await PatientScanRepository.GetPatientScanByDate(Patient_id, date).ToListAsync();
            List<PatientScanResponse> patientScansResponses = new List<PatientScanResponse>();
            foreach (var patientScan in patientScans)
            {
                PatientScanResponse pateintScanResponse = new PatientScanResponse()
                {
                    Image = patientScan.Image,
                    WrittenReport = patientScan.WrittenReport,
                    DoctorId = patientScan.DoctorId,
                    PatientId = patientScan.PatientId,
                    ScanName = patientScan.Scan.ScanName,
                    PatientScanId = patientScan.PatientScanId,
                    ScanDate = patientScan.ScanDate
                };
                patientScansResponses.Add(pateintScanResponse);
            }
            return patientScansResponses;
        }

        public async Task<IEnumerable<PatientScanResponse>> GetDoctorScansByDate(int Doctor_id, DateTime date)
        {
            List<PatientScan> patientScans = await PatientScanRepository.GetDoctorScansByDate(Doctor_id, date).ToListAsync();
            List<PatientScanResponse> patientScansResponses = new List<PatientScanResponse>();
            foreach (var patientScan in patientScans)
            {
                PatientScanResponse pateintScanResponse = new PatientScanResponse()
                {
                    Image = patientScan.Image,
                    WrittenReport = patientScan.WrittenReport,
                    DoctorId = patientScan.DoctorId,
                    PatientId = patientScan.PatientId,
                    ScanName = patientScan.Scan.ScanName,
                    PatientScanId = patientScan.PatientScanId,
                    ScanDate = patientScan.ScanDate
                };
                patientScansResponses.Add(pateintScanResponse);
            }
            return patientScansResponses;
        }

        public async Task<IEnumerable<PatientScanResponse>> GetallPatientScans()
        {
            List<PatientScan> patientScans = await PatientScanRepository.GetAll().ToListAsync();
            List<PatientScanResponse> patientScansResponses = new List<PatientScanResponse>();
            foreach (var patientScan in patientScans)
            {
                PatientScanResponse pateintScanResponse = new PatientScanResponse()
                {
                    Image = patientScan.Image,
                    WrittenReport = patientScan.WrittenReport,
                    DoctorId = patientScan.DoctorId,
                    PatientId = patientScan.PatientId,
                    ScanName = patientScan.Scan.ScanName,
                    PatientScanId = patientScan.PatientScanId,
                    ScanDate = patientScan.ScanDate
                };
                patientScansResponses.Add(pateintScanResponse);
            }
            return patientScansResponses;
        }

    }
}
