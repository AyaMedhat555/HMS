using Microsoft.EntityFrameworkCore;
using Repository.IRepositories;
using Repository.UnitOfWorks;
using SmartHospital.Models.Labs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class PatientTestRepository : GenericRepository<PatientTest>, IPatientTestRepository
    {
        private IUnitOfWork _unitOfWork;
        public PatientTestRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }

        public IQueryable<PatientTest> GetAllDoctorToPatientTests(int Patient_id, int doctor_id)
        {
            return _unitOfWork.Context.PatientTests.Where(

               P => (P.PatientId == Patient_id) && (P.DoctorId== doctor_id)).Include(P => P.CategoricalDetails).Include(P => P.NumericalDetails).OrderByDescending(P => P.TestDate);

        }

        public IQueryable<PatientTest> GetAllPatientTestsByDocId(int doctor_id)
        {
            return _unitOfWork.Context.PatientTests.Where(

                P => P.DoctorId == doctor_id).Include(P => P.CategoricalDetails).Include(P => P.NumericalDetails).OrderByDescending(P => P.TestDate); ;
        }

        public IQueryable<PatientTest> GetAllPatientTestsForAll()
        {

            return _unitOfWork.Context.PatientTests.Include(P => P.CategoricalDetails).Include(P => P.NumericalDetails).OrderByDescending(P => P.TestDate);

        }

        public IQueryable<PatientTest> GetAllPatientTestsForPatient(int Patient_id)
        {
            return _unitOfWork.Context.PatientTests.Where(

                P => P.PatientId== Patient_id).Include(P => P.CategoricalDetails).Include(P => P.NumericalDetails).OrderByDescending(P => P.TestDate);

        }

        public IQueryable<PatientTest> GetDoctorTestsByDate(int doctor_id, DateTime PatientTestDate)
        {
            return _unitOfWork.Context.PatientTests.Where(

               P => (P.DoctorId == doctor_id) && (P.TestDate == PatientTestDate)).Include(P => P.CategoricalDetails).Include(P => P.NumericalDetails);

        }

        public IQueryable<PatientTest> GetInDoorPatientTests(int InDoorPatientRecordId)
        {
            return _unitOfWork.Context.PatientTests.Where(P =>P.IndoorPatientRecordId== InDoorPatientRecordId).Include(P=>P.Test);
        }

        public IQueryable<PatientTest> GetPatientTestByDate(int Patient_id, DateTime PatientTestDate)
        {
            return _unitOfWork.Context.PatientTests.Where(

               P => (P.PatientId == Patient_id) && (P.TestDate == PatientTestDate)).Include(P => P.CategoricalDetails).Include(P => P.NumericalDetails);


        }
    }
}
