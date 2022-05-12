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
            ScanRequest newScanRequest = new ScanRequest()
            {
                ScanName = ScanRequest.ScanName,
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
            ScanRequest newScanRequest = new ScanRequest()
            {
                Id = ScanRequest.Id,
                ScanName = ScanRequest.ScanName,
                CreatedDtm = DateTime.Now,
                DoctorId = ScanRequest.DoctorId,
                PatientId = ScanRequest.PatientId
            };
            return await ScanRequestRepository.Update(newScanRequest);
        }

        public async Task<ScanRequest> GetScanRequestById(int Scan_id)
        {
            return await ScanRequestRepository.GetById(Scan_id);
        }

        public async Task<IEnumerable<ScanRequest>> GetScanRequestsByPatientId(int Patinet_id)
        {
            return await ScanRequestRepository.GetAllScanRequestsForPatient(Patinet_id).ToListAsync();
        }

        public async Task<IEnumerable<ScanRequest>> GetScanRequestsByDoctorId(int Doctor_id)
        {
            return await ScanRequestRepository.GetAllScanRequestsByDocId(Doctor_id).ToListAsync();
        }

        public async Task<IEnumerable<ScanRequest>> GetDoctorScanRequestsByDate(int Doctor_id, DateTime date)
        {
            return await ScanRequestRepository.GetDoctorScanRequestsByDate(Doctor_id, date).ToListAsync();
        }

        public async Task<IEnumerable<ScanRequest>> GetPatientScanRequestsByDate(int Patient_id, DateTime date)
        {
            return await ScanRequestRepository.GetPatientScanRequestByDate(Patient_id, date).ToListAsync();
        }

        public async Task<IEnumerable<ScanRequest>> GetAllScanRequests()
        {
            return await ScanRequestRepository.GetAll().ToListAsync();
        }



        //######################################################################################################
        //PATIENT Scan

        public async Task<PatientScan> AddPatientScan(PatientScanDto Scan)
        {
            int ReqId = Scan.ScanRequestId;
            ScanRequest scanRequest = GetScanRequestById(ReqId).Result;

            int ScanId = await ScanRepository.GetAll().Where(T => T.ScanName == scanRequest.ScanName).Select(T => T.Id).SingleOrDefaultAsync();
            PatientScan newScan = new PatientScan()
            {
                Image = Scan.Image,
                WrittenReport = Scan.WrittenReport,
                ScanDate = Scan.ScanDate,
                DoctorId = scanRequest.DoctorId,
                PatientId = scanRequest.PatientId,
                ScanId = ScanId
            };
            DeleteScanRequest(ReqId);
            return await PatientScanRepository.Add(newScan);
        }

        public async Task<PatientScan> DeletePatientScan(int Scan_id)
        {
            return await PatientScanRepository.Delete(Scan_id);
        }

        public async Task<PatientScan> UpdatePatientScan(PatientScanDto Scan)
        {
            int ReqId = Scan.ScanRequestId;
            ScanRequest scanRequest = GetScanRequestById(ReqId).Result;

            int ScanId = await ScanRepository.GetAll().Where(T => T.ScanName == scanRequest.ScanName).Select(T => T.Id).SingleOrDefaultAsync();
            PatientScan newScan = new PatientScan()
            {
                Image = Scan.Image,
                WrittenReport = Scan.WrittenReport,
                ScanDate = Scan.ScanDate,
                DoctorId = scanRequest.DoctorId,
                PatientId = scanRequest.PatientId,
                ScanId = ScanId
            };
            return await PatientScanRepository.Update(newScan);
        }

        public async Task<PateintScanResponse> GetPatientScanById(int Scan_id)
        {
            PatientScan patientScan = await PatientScanRepository.GetById(Scan_id);
            string ScanName = ScanRepository.GetAll().Where(T => T.Id == patientScan.ScanId).Select(T => T.ScanName).SingleOrDefault();
            PateintScanResponse pateintScanResponse = new PateintScanResponse()
            {
                Image = patientScan.Image,
                WrittenReport = patientScan.WrittenReport,
                DoctorId = patientScan.DoctorId,
                PatientId = patientScan.PatientId,
                ScanName = ScanName,
                PatientScanId = patientScan.PatientScanId,
                ScanDate = patientScan.ScanDate
            };
            return pateintScanResponse;
        }

        public async Task<IEnumerable<PatientScan>> GetPatientScansByPatientId(int Patient_id)
        {
            return await PatientScanRepository.GetAllPatientScansForPatient(Patient_id).ToListAsync();
        }

        public async Task<IEnumerable<PatientScan>> GetPatientScansByDoctorId(int Doctor_id)
        {
            return await PatientScanRepository.GetAllPatientScansByDocId(Doctor_id).ToListAsync();
        }

        public async Task<IEnumerable<PatientScan>> GetPatientScansByDate(int Patient_id, DateTime date)
        {
            return await PatientScanRepository.GetPatientScanByDate(Patient_id, date).ToListAsync();
        }

        public async Task<IEnumerable<PatientScan>> GetDoctorScansByDate(int Doctor_id, DateTime date)
        {
            return await PatientScanRepository.GetDoctorScansByDate(Doctor_id, date).ToListAsync();
        }

        public async Task<IEnumerable<PatientScan>> GetallPatientScans()
        {
            return await PatientScanRepository.GetAll().ToListAsync();
        }

    }
}
