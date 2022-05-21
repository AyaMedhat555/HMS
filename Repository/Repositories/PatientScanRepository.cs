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
    public class PatientScanRepository : GenericRepository<PatientScan>, IPatientScanRepository
    {
        private IUnitOfWork _unitOfWork;
        public PatientScanRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }

        public IQueryable<PatientScan> GetAllDoctorToPatientScans(int Patient_id, int doctor_id)
        {
            return _unitOfWork.Context.PatientScans.Where(

               P => (P.PatientId == Patient_id) && (P.DoctorId== doctor_id)).OrderByDescending(P => P.ScanDate);

        }

        public IQueryable<PatientScan> GetAllPatientScansByDocId(int doctor_id)
        {
            return _unitOfWork.Context.PatientScans.Where(

                P => P.DoctorId == doctor_id).OrderByDescending(P => P.ScanDate); ;
        }

        public IQueryable<PatientScan> GetAllPatientScansForAll()
        {

            return _unitOfWork.Context.PatientScans.OrderByDescending(P => P.ScanDate);

        }

        public IQueryable<PatientScan> GetAllPatientScansForPatient(int Patient_id)
        {
            return _unitOfWork.Context.PatientScans.Where(

                P => P.PatientId== Patient_id).OrderByDescending(P => P.ScanDate);

        }

        public IQueryable<PatientScan> GetDoctorScansByDate(int doctor_id, DateTime PatientScanDate)
        {
            return _unitOfWork.Context.PatientScans.Where(

               P => (P.DoctorId == doctor_id) && (P.ScanDate == PatientScanDate));

        }

        public IQueryable<PatientScan> GetInDoorPatientScans(int InDoorPatientRecordId)
        {
            return _unitOfWork.Context.PatientScans.Where(P => P.IndoorPatientRecordId == InDoorPatientRecordId).Include(P => P.Scan);
        }

        public IQueryable<PatientScan> GetPatientScanByDate(int Patient_id, DateTime PatientScanDate)
        {
            return _unitOfWork.Context.PatientScans.Where(

               P => (P.PatientId == Patient_id) && (P.ScanDate == PatientScanDate));


        }
    }
}
