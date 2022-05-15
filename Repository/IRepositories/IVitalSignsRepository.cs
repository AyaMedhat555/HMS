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

         //Task <res> GetVitalSignesByRangeOfDate2(int PatientId, DateTime StartDate, DateTime EndDate);
    }

}
