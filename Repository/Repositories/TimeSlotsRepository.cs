using Domain.Models;
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


    public class TimeSlotsRepository : GenericRepository<TimeSlot>, ITimeSlotsRepository
    {
        private IUnitOfWork _unitOfWork;
        public TimeSlotsRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }

        public IQueryable<TimeSlot> GetAllTimeSlots(int doctor_id)
        {
            return _unitOfWork.Context.TimeSlots.Where(T => T.DoctorId == doctor_id);//.Include(T=>T.Doctor);
        }
    }
}


