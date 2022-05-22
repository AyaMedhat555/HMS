using Domain.Models.Labs;
using Microsoft.EntityFrameworkCore;
using Repository.IRepositories;
using Repository.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class ScanRequestRepository : GenericRepository<ScanRequest>, IScanRequestRepository
    {
        private IUnitOfWork _unitOfWork;
        public ScanRequestRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }

        public IQueryable<ScanRequest> GetAllDoctorToPatientScanRequests(int Patient_id, int doctor_id)
        {
            return _unitOfWork.Context.ScanRequests.Where(

               P => (P.PatientId == Patient_id) && (P.DoctorId== doctor_id)).Include(S => S.Doctor).Include(S => S.Patient).Include(S => S.Scan).OrderByDescending(P => P.CreatedDtm);

        }

        public IQueryable<ScanRequest> GetAllScanRequestsByDocId(int doctor_id)
        {
            return _unitOfWork.Context.ScanRequests.Where(

                P => P.DoctorId == doctor_id).Include(S => S.Doctor).Include(S => S.Patient).Include(S => S.Scan).OrderByDescending(P => P.CreatedDtm); ;
        }

        public IQueryable<ScanRequest> GetAllScanRequestsForAll()
        {

            return _unitOfWork.Context.ScanRequests.Include(S => S.Doctor).Include(S => S.Patient).Include(S => S.Scan).OrderByDescending(P => P.CreatedDtm);

        }

        public IQueryable<ScanRequest> GetAllScanRequestsForPatient(int Patient_id)
        {
            return _unitOfWork.Context.ScanRequests.Where(

                P => P.PatientId== Patient_id).Include(S => S.Doctor).Include(S => S.Patient).Include(S => S.Scan).OrderByDescending(P => P.CreatedDtm);

        }

        public IQueryable<ScanRequest> GetDoctorScanRequestsByDate(int doctor_id, DateTime ScanRequestDate)
        {
            return _unitOfWork.Context.ScanRequests.Where(

               P => (P.DoctorId == doctor_id) && (P.CreatedDtm.Date == ScanRequestDate.Date)).Include(S => S.Doctor).Include(S => S.Patient).Include(S => S.Scan);

        }

        public IQueryable<ScanRequest> GetPatientScanRequestByDate(int Patient_id, DateTime ScanRequestDate)
        {
            return _unitOfWork.Context.ScanRequests.Where(

               P => (P.PatientId == Patient_id) && (P.CreatedDtm.Date == ScanRequestDate.Date)).Include(S => S.Doctor).Include(S => S.Patient).Include(S => S.Scan);
        }

        public IQueryable<ScanRequest> GetAllScanRequests()
        {
            return _unitOfWork.Context.ScanRequests.Include(S => S.Doctor).Include(S => S.Patient).Include(S => S.Scan);
        }

        public async Task<ScanRequest> GetScanRequestById(int id)
        {
            return await _unitOfWork.Context.ScanRequests.Include(S => S.Doctor).Include(S => S.Patient).Include(S => S.Scan).SingleOrDefaultAsync(S => S.Id == id);
        }

        //public IQueryable<ScanRequest> AddScanRequests(List<ScanRequest> scanRequests)
        //{
        //    foreach(var scanRequest in scanRequests)
        //    {
        //        _unitOfWork.Context.ScanRequests.Add(scanRequest);
        //        _unitOfWork.Commit();
        //    }
        //    return scanRequests.AsQueryable();
        //}

    }
}
