using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.IRepositories
{
    public interface IScheduleRepository:IGenericRepository<Schedule>
    {

        
        IQueryable<Schedule> GetScheduleByDoctor_Id(int Doctor_Id);
        IQueryable<DayOfWeek> GetScheduleDaysByDoctor_Id(int Doctor_Id);

    }
}
