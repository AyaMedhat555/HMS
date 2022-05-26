using Domain.Models;
using Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.IRepositories
{
    public interface IVitalSignsRepository: IGenericRepository<VitalSign>
    {
     
        IQueryable<VitalSign> GetVitalSignesByRangeOfDate(int PatientId ,DateTime StartDate,DateTime EndDate);


        IQueryable<VitalSign> GetVitalSignesByRangeOfDateOnly(int PatientId, DateTime StartDate, DateTime EndDate);
        IQueryable<VitalSign> GetVitalSignesBySpecificDate(int PatientId, DateTime Date);
    }

}
