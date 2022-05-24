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
    public class VitalSignsRepository : GenericRepository<VitalSign>, IVitalSignsRepository
    {
        private IUnitOfWork _unitOfWork;
        public VitalSignsRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }



        public IQueryable<VitalSign> GetVitalSignesByRangeOfDate(int PatientId, DateTime StartDate, DateTime EndDate)
        {
           

            return _unitOfWork.Context.VitalSigns.Where(

               V => (V.Patientid == PatientId) && (V.vitals_date >= StartDate && V.vitals_date <= EndDate)).Include(V => V.Nurse).Include(V=>V.Patient).Include(V=>V.Note);


            
        }

    }
    
}