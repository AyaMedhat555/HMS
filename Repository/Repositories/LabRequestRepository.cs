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
    public class LabRequestRepository : GenericRepository<LabRequest>, ILabRequestRepository
    {
        private IUnitOfWork _unitOfWork;
        public LabRequestRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }

        public IQueryable<LabRequest> GetAllDoctorToPatientLabRequests(int Patient_id, int doctor_id)
        {
            return _unitOfWork.Context.LabRequests.Where(

               P => (P.PatientId == Patient_id) && (P.DoctorId== doctor_id)).Include(L => L.Doctor).Include(L => L.Patient).Include(L => L.Test).OrderByDescending(P => P.CreatedDtm);

        }

        public IQueryable<LabRequest> GetAllLabRequestsByDocId(int doctor_id)
        {
            return _unitOfWork.Context.LabRequests.Where(

                P => P.DoctorId == doctor_id).Include(L => L.Doctor).Include(L => L.Patient).Include(L => L.Test).OrderByDescending(P => P.CreatedDtm); ;
        }

        public IQueryable<LabRequest> GetAllLabRequestsForAll()
        {

            return _unitOfWork.Context.LabRequests.Include(L => L.Doctor).Include(L => L.Patient).Include(L => L.Test).OrderByDescending(P => P.CreatedDtm);

        }

        public IQueryable<LabRequest> GetAllLabRequestsForPatient(int Patient_id)
        {
            return _unitOfWork.Context.LabRequests.Where(

                P => P.PatientId== Patient_id).Include(L => L.Doctor).Include(L => L.Patient).Include(L => L.Test).OrderByDescending(P => P.CreatedDtm);

        }

        public IQueryable<LabRequest> GetDoctorLabRequestsByDate(int doctor_id, DateTime LabRequestDate)
        {
            return _unitOfWork.Context.LabRequests.Where(

               P => (P.DoctorId == doctor_id) && (P.CreatedDtm == LabRequestDate)).Include(L => L.Doctor).Include(L => L.Patient).Include(L => L.Test);

        }

        public IQueryable<LabRequest> GetPatientLabRequestByDate(int Patient_id, DateTime LabRequestDate)
        {
            return _unitOfWork.Context.LabRequests.Where(

               P => (P.PatientId == Patient_id) && (P.CreatedDtm == LabRequestDate)).Include(L => L.Doctor).Include(L => L.Patient).Include(L => L.Test);


        }
    }
}
