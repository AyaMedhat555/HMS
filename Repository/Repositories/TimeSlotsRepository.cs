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

        public IQueryable<TimeSlot> GetFreeSlots(int doctor_id, TimeSpan ReservedTime)
        {
            return _unitOfWork.Context.TimeSlots.Where(T => (T.DoctorId == doctor_id) && (T.slot_time != ReservedTime));
        }

        public IQueryable<TimeSlot> GetFreeSlotsWithDay(DayOfWeek DayOfWeek, int doctor_id, TimeSpan ReservedTime)
        {
            return _unitOfWork.Context.TimeSlots.Where(T => (T.DoctorId == doctor_id) && (T.slot_time != ReservedTime)&&(T.Dayofwork== DayOfWeek)) ;
        }

        //public IQueryable<FullSlots> GetFreeTimeSlots(int doctor_id)
        //{

        //    List<Appointment> ReservedAppointments = _unitOfWork.Context.Appointments.Where(A => A.DoctorId == doctor_id).ToList();
        //    TimeSpan ReservedTime;
        //    List<FullSlots> AllSlots = new List<FullSlots>();
        //    List<TimeSlot> FreeSlots;


        //    for (int i = 0; i < (ReservedAppointments.Count-1); i++)
        //    {

        //        ReservedTime = new TimeSpan(ReservedAppointments[i]. AppointmentDate.Hour, ReservedAppointments[i].AppointmentDate.Minute, 0);
        //        FreeSlots = _unitOfWork.Context.TimeSlots.Where(T => (T.DoctorId == doctor_id) && (T.slot_time != ReservedTime)).ToList();
        //        AllSlots[i].FreeSlots= FreeSlots;
        //        AllSlots[i].AppointmentDate = ReservedAppointments[i].AppointmentDate;

        //    }

        //    var queryable = AllSlots.AsQueryable();


        //    return queryable;
        //}

        public IQueryable<Appointment> GetReservedAppointments(int doctor_id)
        {
            return _unitOfWork.Context.Appointments.Where(A => A.DoctorId == doctor_id);
        }

        public IQueryable<TimeSlot> GetSlotsByDayOfWork(DayOfWeek DayOfWeek, int doctor_id)
        {
            return _unitOfWork.Context.TimeSlots.Where(T => (T.Dayofwork == DayOfWeek)&&(T.DoctorId== doctor_id));
        }

        
    }
}


