using Domain.Models;
using Domain.Models.Users;
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
    public class IndoorPatientRepository : GenericRepository<IndoorPatientRecord>, IIndoorPatientRepository
    {
        private IUnitOfWork _unitOfWork;
        public IndoorPatientRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IQueryable<DateTime?> GetDischargeDatesByPatientId(int PatientId)
        {
       
            return _unitOfWork.Context.IndoorPatients.Where(I => I.PatientId == PatientId).Select(I => I.DischargeDate);

           
        }

        public IQueryable<IndoorPatientRecord> GetDischargedPatients()
        {
            return _unitOfWork.Context.IndoorPatients.Where(I => I.Disharged == true);
        }

        public IQueryable<int> GetIndoorPatientRecords(int PatientId)
        {
            return _unitOfWork.Context.IndoorPatients.Where(I => I.PatientId == PatientId).Select(I=>I.Id);
        }

        public IQueryable<IndoorPatientRecord> GetInDoorPatients()
        {
            return _unitOfWork.Context.IndoorPatients.Where(I => I.Disharged == false);
        }

        public  IQueryable<IndoorPatientRecord> GetInDoorPatientsByDept(int? DepartmentId)
        {
            
            return _unitOfWork.Context.IndoorPatients.Where(I => (I.DepartmentId == DepartmentId) && (I.Disharged==false)).Include(I=>I.Patient).Include(I=>I.Room).Include(I=>I.Bed);
            
        }

        public IQueryable<IndoorPatientRecord> GetInDoorRecords()
        {
            return _unitOfWork.Context.IndoorPatients;
        }

        public IQueryable<IndoorPatientRecord> GetInDoorRecordsByPatientId(int PatientId)
        {
            return _unitOfWork.Context.IndoorPatients.Where(I => (I.PatientId == PatientId)).Include(I=>I.Room).Include(I=>I.Bed); 
        }

        public async Task < IndoorPatientRecord> GetLastRecordBeforeDischarging(int PatientId)
        {
            return await _unitOfWork.Context.IndoorPatients.Include(I=>I.Scans).Include(I=>I.Tests)
                .Include(I=>I.Prescriptions).Include(I => I.Bill).OrderByDescending( I=>I.Id)
                .LastAsync(I => (I.PatientId == PatientId) && (I.Disharged == false)); 
        }

        public IndoorPatientRecord GetPatientReport(int PatientId, DateTime DateOfDischarge)
        {
            return _unitOfWork.Context.IndoorPatients.SingleOrDefault(I=>(I.PatientId == PatientId)&&(I.DischargeDate== DateOfDischarge));
        }

        public IQueryable<IndoorPatientRecord> GetPatientsDiscahrgedToday(DateTime? Today)
        {
            return _unitOfWork.Context.IndoorPatients.Where(I => (I.DischargeDate == Today)).Include(I=>I.Patient);
        }
    }
}
