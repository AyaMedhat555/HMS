using Domain.Models;
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

        public IQueryable<int> GetIndoorPatientRecords(int PatientId)
        {
            return _unitOfWork.Context.IndoorPatients.Where(I => I.PatientId == PatientId).Select(I=>I.Id);
        }

        public  IQueryable<IndoorPatientRecord> GetInDoorPatientsByDept(int? DepartmentId)
        {
            
            return  _unitOfWork.Context.IndoorPatients.Where(I => (I.DepartmentId == DepartmentId) && (I.Disharged==false)).Include(I=>I.Patient).Include(I=>I.Room).Include(I=>I.Bed);
            
        }

        public IndoorPatientRecord GetLastRecordBeforeDischarging(int PatientId)
        {
            return _unitOfWork.Context.IndoorPatients.Include(I=>I.Scans).Include(I=>I.Tests)
                .Include(I=>I.Prescriptions).OrderByDescending( I=>I.Id)
                .Last(I => (I.PatientId == PatientId) && (I.Disharged == false)); 
        }

        public IndoorPatientRecord GetPatientReport(int PatientId, DateTime DateOfDischarge)
        {
            return _unitOfWork.Context.IndoorPatients.SingleOrDefault(I=>(I.PatientId == PatientId)&&(I.DischargeDate== DateOfDischarge));
        }
    }
}
