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
               P => (P.PatientId == Patient_id) && (P.DoctorId== doctor_id))
                .Include(P => P.CategoricalDetails).Include(P => P.NumericalDetails).Include(P => P.Test)
                .Include(P => P.Doctor).Include(P => P.Patient).OrderByDescending(P => P.TestDate);
        }

        public IQueryable<PatientTest> GetAllPatientsTests()
        {
            return _unitOfWork.Context.PatientTests.Include(P => P.CategoricalDetails)
                .Include(P => P.NumericalDetails).Include(P => P.Test)
                .Include(P => P.Doctor).Include(P => P.Patient);
        }

        public IQueryable<PatientTest> GetAllPatientTestsByDocId(int doctor_id)
        {
            return _unitOfWork.Context.PatientTests.Where(

                P => P.DoctorId == doctor_id).Include(P => P.CategoricalDetails)
                .Include(P => P.NumericalDetails).Include(P => P.Test)
                .Include(P => P.Doctor).Include(P => P.Patient).OrderByDescending(P => P.TestDate); ;
        }

        public IQueryable<PatientTest> GetAllPatientTestsForAll()
        {

            return _unitOfWork.Context.PatientTests.Include(P => P.CategoricalDetails)
                .Include(P => P.NumericalDetails).Include(P => P.Test)
                .Include(P => P.Doctor).Include(P => P.Patient).OrderByDescending(P => P.TestDate);

        }

        public IQueryable<PatientTest> GetAllPatientTestsForPatient(int Patient_id)
        {
            return _unitOfWork.Context.PatientTests.Where(

                P => P.PatientId== Patient_id).Include(P => P.CategoricalDetails)
                .Include(P => P.NumericalDetails).Include(P => P.Test)
                .Include(P => P.Doctor).Include(P => P.Patient).OrderByDescending(P => P.TestDate);

        }

        public IQueryable<PatientTest> GetDoctorTestsByDate(int doctor_id, DateTime PatientTestDate)
        {
            return _unitOfWork.Context.PatientTests.Where(

               P => (P.DoctorId == doctor_id) && (P.TestDate.Date == PatientTestDate.Date))
                .Include(P => P.CategoricalDetails).Include(P => P.NumericalDetails)
                .Include(P => P.Doctor).Include(P => P.Patient).Include(P => P.Test);

        }

        public IQueryable<PatientTest> GetInDoorPatientTests(int InDoorPatientRecordId)
        {
            return _unitOfWork.Context.PatientTests.Where(P =>P.IndoorPatientRecordId== InDoorPatientRecordId)
                .Include(P=>P.Test).Include(P => P.Doctor).Include(P => P.Patient)
                .Include(P => P.CategoricalDetails).Include(P => P.NumericalDetails);
        }

        public IQueryable<PatientTest> GetPatientTestByDate(int Patient_id, DateTime PatientTestDate)
        {
            return _unitOfWork.Context.PatientTests.Where(
               P => (P.PatientId == Patient_id) && (P.TestDate.Date == PatientTestDate.Date))
                .Include(P => P.CategoricalDetails).Include(P => P.NumericalDetails).Include(P => P.Test)
                .Include(P => P.Doctor).Include(P => P.Patient);
        }

        public async Task<PatientTest> GetPatientTestById(int id)
        {
            return await _unitOfWork.Context.PatientTests.Include(P => P.CategoricalDetails)
                .Include(P => P.NumericalDetails).Include(P => P.Test)
                .Include(P => P.Doctor).Include(P => P.Patient).FirstOrDefaultAsync(P => P.PatientTestId == id);
        }
    }
}
