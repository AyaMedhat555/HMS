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
            ScanRequest scanRequest = await ScanRequestRepository.GetScanRequestById(Scan_id);
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
            return await ScanRequestRepository.GetAllScanRequestsForPatient(Patinet_id).Select(S => new ScanRequestResponse()
            {
                Id = S.Id,
                ScanName = S.Scan.ScanName,
                ScanId = S.Scan.Id,
                CreatedDtm = S.CreatedDtm,
                DoctorName = S.Doctor.FirstName+" "+S.Doctor.LastName,
                PatientName = S.Patient.FirstName+" "+S.Patient.LastName,
                DoctorId = S.DoctorId,
                PatientId = S.PatientId
            }).ToListAsync();
        }

        public async Task<IEnumerable<ScanRequestResponse>> GetScanRequestsByDoctorId(int Doctor_id)
        {
            return await ScanRequestRepository.GetAllScanRequestsByDocId(Doctor_id).Select(S => new ScanRequestResponse()
            {
                Id = S.Id,
                ScanName = S.Scan.ScanName,
                ScanId = S.Scan.Id,
                CreatedDtm = S.CreatedDtm,
                DoctorName = S.Doctor.FirstName+" "+S.Doctor.LastName,
                PatientName = S.Patient.FirstName+" "+S.Patient.LastName,
                DoctorId = S.DoctorId,
                PatientId = S.PatientId
            }).ToListAsync();
        }

        public async Task<IEnumerable<ScanRequestResponse>> GetDoctorScanRequestsByDate(int Doctor_id, DateTime date)
        {
            return await ScanRequestRepository.GetDoctorScanRequestsByDate(Doctor_id, date).Select(S => new ScanRequestResponse()
            {
                Id = S.Id,
                ScanName = S.Scan.ScanName,
                ScanId = S.Scan.Id,
                CreatedDtm = S.CreatedDtm,
                DoctorName = S.Doctor.FirstName+" "+S.Doctor.LastName,
                PatientName = S.Patient.FirstName+" "+S.Patient.LastName,
                DoctorId = S.DoctorId,
                PatientId = S.PatientId
            }).ToListAsync();
        }

        public async Task<IEnumerable<ScanRequestResponse>> GetPatientScanRequestsByDate(int Patient_id, DateTime date)
        {
            return await ScanRequestRepository.GetPatientScanRequestByDate(Patient_id, date).Select(S => new ScanRequestResponse()
            {
                Id = S.Id,
                ScanName = S.Scan.ScanName,
                ScanId = S.Scan.Id,
                CreatedDtm = S.CreatedDtm,
                DoctorName = S.Doctor.FirstName+" "+S.Doctor.LastName,
                PatientName = S.Patient.FirstName+" "+S.Patient.LastName,
                DoctorId = S.DoctorId,
                PatientId = S.PatientId
            }).ToListAsync();
        }

        public async Task<IEnumerable<ScanRequestResponse>> GetAllScanRequests()
        {
            return await ScanRequestRepository.GetAllScanRequests().Select(S => new ScanRequestResponse()
            {
                Id = S.Id,
                ScanName = S.Scan.ScanName,
                ScanId = S.Scan.Id,
                CreatedDtm = S.CreatedDtm,
                DoctorName = S.Doctor.FirstName+" "+S.Doctor.LastName,
                PatientName = S.Patient.FirstName+" "+S.Patient.LastName,
                DoctorId = S.DoctorId,
                PatientId = S.PatientId
            }).ToListAsync();
        }

        public async Task<IEnumerable<ScanRequest>> AddScanRequests(List<ScanRequestDto> scanRequestsDtos)
        {
            List<Scan> scans = await ScanRepository.GetAll().ToListAsync();
            List<ScanRequest> scanRequests = scanRequestsDtos.Select(S => new ScanRequest()
            {
                ScanId = scans.Where(p => p.ScanName == S.ScanName).Select(T => T.Id).SingleOrDefault(),
                CreatedDtm = DateTime.Now,
                DoctorId = S.DoctorId,
                PatientId = S.PatientId
            }).ToList();
            foreach(ScanRequest scanRequest in scanRequests)
            {
                await ScanRequestRepository.Add(scanRequest);
            }
            return scanRequests;
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
                ScanId = scanRequest.ScanId,
                IndoorPatientRecordId= Scan. IndoorPatientRecordId 
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
            PatientScan currentScan = await PatientScanRepository.GetById(Scan.PatientScanId);
            currentScan.Image = Scan.Image;
            currentScan.WrittenReport = Scan.WrittenReport;
            return await PatientScanRepository.Update(currentScan);
        }

        public async Task<PatientScanResponse> GetPatientScanById(int Scan_id)
        {
            PatientScan patientScan = await PatientScanRepository.GetPatientScanById(Scan_id);
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
            return await PatientScanRepository.GetAllPatientScansForPatient(Patient_id).Select(S => new PatientScanResponse()
            {
                Image = S.Image,
                WrittenReport = S.WrittenReport,
                DoctorId = S.DoctorId,
                PatientId = S.PatientId,
                ScanName = S.Scan.ScanName,
                PatientScanId = S.PatientScanId,
                ScanDate = S.ScanDate
            }).ToListAsync();
        }

        public async Task<IEnumerable<PatientScanResponse>> GetPatientScansByDoctorId(int Doctor_id)
        {
            return await PatientScanRepository.GetAllPatientScansByDocId(Doctor_id).Select(S => new PatientScanResponse()
            {
                Image = S.Image,
                WrittenReport = S.WrittenReport,
                DoctorId = S.DoctorId,
                PatientId = S.PatientId,
                ScanName = S.Scan.ScanName,
                PatientScanId = S.PatientScanId,
                ScanDate = S.ScanDate
            }).ToListAsync();
        }

        public async Task<IEnumerable<PatientScanResponse>> GetPatientScansByDate(int Patient_id, DateTime date)
        {
            return await PatientScanRepository.GetPatientScanByDate(Patient_id, date).Select(S => new PatientScanResponse()
            {
                Image = S.Image,
                WrittenReport = S.WrittenReport,
                DoctorId = S.DoctorId,
                PatientId = S.PatientId,
                ScanName = S.Scan.ScanName,
                PatientScanId = S.PatientScanId,
                ScanDate = S.ScanDate
            }).ToListAsync();
        }

        public async Task<IEnumerable<PatientScanResponse>> GetDoctorScansByDate(int Doctor_id, DateTime date)
        {
            return await PatientScanRepository.GetDoctorScansByDate(Doctor_id, date).Select(S => new PatientScanResponse()
            {
                Image = S.Image,
                WrittenReport = S.WrittenReport,
                DoctorId = S.DoctorId,
                PatientId = S.PatientId,
                ScanName = S.Scan.ScanName,
                PatientScanId = S.PatientScanId,
                ScanDate = S.ScanDate
            }).ToListAsync();
        }

        public async Task<IEnumerable<PatientScanResponse>> GetallPatientScans()
        {
            return await PatientScanRepository.GetAllPatientsScans().Select(S => new PatientScanResponse()
            {
                Image = S.Image,
                WrittenReport = S.WrittenReport,
                DoctorId = S.DoctorId,
                PatientId = S.PatientId,
                ScanName = S.Scan.ScanName,
                PatientScanId = S.PatientScanId,
                ScanDate = S.ScanDate
            }).ToListAsync();
        }

    }
}
