using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Repository;
using Repository.IRepositories;
using Repository.Repositories;
using Service.DTO;
using Service.IServices;
using Service.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class TimeSlotService : ITimeSlotService
    {

        private ITimeSlotsRepository TimeSlotsRepository { get; }
        private IAppointmentRepository AppointmentRepository { get; }

        private IDoctorRepository DoctorRepository { get; }

        private IScheduleRepository ScheduleRepository { get; }
        public TimeSlotService(ITimeSlotsRepository _TimeSlotsRepository, IAppointmentRepository _AppointmentRepository, IScheduleRepository _ScheduleRepository, IDoctorRepository _DoctorRepository)
        {

            TimeSlotsRepository = _TimeSlotsRepository;
            AppointmentRepository = _AppointmentRepository;
            ScheduleRepository = _ScheduleRepository;
            DoctorRepository = _DoctorRepository;

        }

        public IEnumerable<Slots> CalculateDaySlots(scheduleDto scheduleDto)
        {
            DayOfWeek Desired_Day = scheduleDto.DayOfWork;
            TimeSpan Start = TimeSpan.Parse(scheduleDto.StartTime);
            TimeSpan End = TimeSpan.Parse(scheduleDto.EndTime);

            TimeSpan slot1 = Start;

            TimeSpan TimePerPatient = TimeSpan.Parse(scheduleDto.TimePerPatient);

            List<Slots> slots_list = new List<Slots>();


            TimeSpan Lastslot = End;
            int i = 0;
            TimeSpan slot_i = new TimeSpan(0, 0, 0);
            string sloti_s;

            while (slot_i != Lastslot)
            {
                slot_i = slot1 + i * TimePerPatient;



                Slots slot_obj_2 = new Slots() { slot_num = i + 1, slot_time = slot_i, DayOfWork = Desired_Day };
                slots_list.Add(slot_obj_2);
                i++;

            }

            return slots_list;

        }



        public async Task AddTimeSlots(scheduleDto scheduleDto)
        {
            List<Slots> slots_list2 = (List<Slots>)CalculateDaySlots(scheduleDto);

            for (int i = 0; i < slots_list2.Count; i++)
            {
                TimeSlot TimeSlot1 = new TimeSlot()
                {
                    slotnumber = slots_list2[i].slot_num,

                    DoctorId = scheduleDto.DoctorId,

                    slot_time = slots_list2[i].slot_time,

                    Dayofwork = slots_list2[i].DayOfWork

                };
                await TimeSlotsRepository.Add(TimeSlot1);

            }

        }
        public async Task<IEnumerable<TimeSlot>> GetAllTimeSlotsService(int doctor_id)
        {
            return await TimeSlotsRepository.GetAllTimeSlots(doctor_id).ToListAsync();
        }

        public async Task<IEnumerable<TimeSlot>> GetAllTimeSlotsService()
        {
            return await TimeSlotsRepository.GetAll().ToListAsync();
        }

        public int CalculateOffset(DayOfWeek current, DayOfWeek desired)
        {
            // f( c, d ) = [7 - (c - d)] mod 7
            // f( c, d ) = [7 - c + d] mod 7
            // c is current day of week and 0 <= c < 7 
            // d is desired day of the week and 0 <= d < 7
            int c = (int)current;
            int d = (int)desired;
            int offset = (7 - c + d) % 7;
            return offset == 0 ? 7 : offset;
        }

        public DateTime performCalculateOffset(DayOfWeek desired)
        {

            DateTime NOW = DateTime.Now;

            int offset = CalculateOffset(NOW.DayOfWeek, desired);
            DateTime Datedesired = NOW.AddDays(offset);

            return Datedesired.Date;

        }

        public async Task<Appointment> MakeAppointment(AppointmentDto appointment, TimeSlotDto timeslotdto)
        {

            Appointment appointmentDb = new Appointment()
            {
                DoctorId = appointment.DoctorId,
                Complain = appointment.Complain,
                PatientId = appointment.PatientId,
                AppointmentType = appointment.AppointmentType,
                AppointmentDate = appointment.AppointmentDate.Date.Add(TimeSpan.Parse(timeslotdto.slot_time)),
                Examined = appointment.Examined
                //AppointmentDate=  performCalculateOffset(timeslotdto.Dayofwork).Add(TimeSpan.Parse(timeslotdto.slot_time))

            };
            await AppointmentRepository.Add(appointmentDb);


            //TimeSlot timeslot2 = await TimeSlotsRepository.GetById(timeslotdto.id);
            //timeslot2.Reserved = timeslotdto.Reserved;
            //TimeSlotsRepository.Update(timeslot2);

            return appointmentDb;

        }

        public async Task<IEnumerable<FullSlots>> GetFreeTimeSlots(int doctor_id)
        {
            List<Appointment> ReservedAppointments = await TimeSlotsRepository.GetReservedAppointments(doctor_id).ToListAsync();
            TimeSpan ReservedTime;
            List<FullSlots> AllSlots = new List<FullSlots>();

            for (int i = 0; i < (ReservedAppointments.Count - 1); i++)
            {

                ReservedTime = new TimeSpan(ReservedAppointments[i].AppointmentDate.Hour, ReservedAppointments[i].AppointmentDate.Minute, 0);
                List<TimeSlot> FreeSlots = await TimeSlotsRepository.GetFreeSlots(doctor_id, ReservedTime).ToListAsync();

                AllSlots[i].FreeSlots = FreeSlots;
                AllSlots[i].AppointmentDate = ReservedAppointments[i].AppointmentDate;
            }

            return AllSlots;

        }

        public IEnumerable<BusySlotResponce> GetBusySlots(int DoctorId, DateTime StartDate, DateTime EndDate)
        {
            List<BusySlotResponce> busySlotResponces = new List<BusySlotResponce>();

            List<Appointment> Appointments;
            DateTime Day = new DateTime();
            TimeSpan ReservedSlot;

            do
            {

                Appointments = AppointmentRepository.GetAppointmentsByDate(StartDate, DoctorId).ToList();
                List<TimeSpan> ReservedSlots = new List<TimeSpan>();

                BusySlotResponce busySlotResponce = new BusySlotResponce();
                for (int i = 0; i < Appointments.Count; i++)
                {
                    busySlotResponce.Day = Appointments[0].AppointmentDate.Date;
                    ReservedSlot = new TimeSpan(Appointments[i].AppointmentDate.Hour, Appointments[i].AppointmentDate.Minute, 0);

                    ReservedSlots.Add(ReservedSlot);

                }

                busySlotResponce.BusySlots = ReservedSlots;
                busySlotResponces.Add(busySlotResponce);

                StartDate = StartDate.AddDays(1);
            }
            while (StartDate <= EndDate);

            return busySlotResponces;
        }

        public async Task<IEnumerable<WorkScheduleByDept>> GetAllTimeSlotsByDepartmentId(int DepartmentId)
        {


            List<Doctor> Doctors = await DoctorRepository.GetDoctorsByDepartment_Id(DepartmentId).ToListAsync();

            List<TimeSlot> slotsPerDay = new List<TimeSlot>();
            List<DayOfWeek> DoctorDaysOfWork = new List<DayOfWeek>();
            List<slotResponce> slots;
            List<WorkSchedule> WorkSchedulesForDoctorPerDay = new List<WorkSchedule>();


            List<WorkScheduleByDept> WorkScheduleByDepts = new List<WorkScheduleByDept>();


            for (int i = 0; i < Doctors.Count; i++)
            {
                WorkScheduleByDept WorkScheduleByDept = new WorkScheduleByDept();
                WorkScheduleByDept.DoctorId = Doctors[i].Id;
                WorkScheduleByDept.DoctorName = Doctors[i].FirstName + Doctors[i].LastName;
                DoctorDaysOfWork = await ScheduleRepository.GetScheduleDaysByDoctor_Id(Doctors[i].Id).ToListAsync();




                for (int Day = 0; Day < DoctorDaysOfWork.Count; Day++)
                {
                    WorkSchedule WorkSchedule = new WorkSchedule();
                    WorkSchedule.DayOfWork = DoctorDaysOfWork[Day];
                    slotsPerDay = await TimeSlotsRepository.GetSlotsByDayOfWork(DoctorDaysOfWork[Day], Doctors[i].Id).ToListAsync();
                    slots = slotsPerDay.Select(Sl => new slotResponce()

                    {
                        slot_Id = Sl.id,
                        SlotNumber = Sl.slotnumber,
                        SlotTime = Sl.slot_time

                    }).ToList();

                    WorkSchedule.Slots = slots;
                    WorkSchedulesForDoctorPerDay.Add(WorkSchedule);
                }



                WorkScheduleByDept.WorkSchedules = WorkSchedulesForDoctorPerDay;
                WorkScheduleByDepts.Add(WorkScheduleByDept);


            }

            return WorkScheduleByDepts;
        }

        public async Task<WorkScheduleByDept> GetFreeTimeSlotsByDoctorId(int DoctorId)
        {
            List<Appointment> ReservedAppointments = await TimeSlotsRepository.GetReservedAppointments(DoctorId).ToListAsync();
            TimeSpan ReservedTime;

            Doctor Doctor = await DoctorRepository.GetById(DoctorId);

            List<TimeSlot> slotsPerDay = new List<TimeSlot>();
            List<DayOfWeek> DoctorDaysOfWork = new List<DayOfWeek>();
            List<slotResponce> slots;
            List<WorkSchedule> WorkSchedulesForDoctorPerDay = new List<WorkSchedule>();
            List<TimeSlot> FreeSlots = new List<TimeSlot>();


            WorkScheduleByDept _WorkScheduleByDept = new WorkScheduleByDept();
            _WorkScheduleByDept.DoctorId = Doctor.Id;
            _WorkScheduleByDept.DoctorName = Doctor.FirstName + Doctor.LastName;
            DoctorDaysOfWork = await ScheduleRepository.GetScheduleDaysByDoctor_Id(Doctor.Id).ToListAsync();

            for (int i = 0; i < (ReservedAppointments.Count - 1); i++)
            {

                ReservedTime = new TimeSpan(ReservedAppointments[i].AppointmentDate.Hour, ReservedAppointments[i].AppointmentDate.Minute, 0);
                FreeSlots = await TimeSlotsRepository.GetFreeSlots(Doctor.Id, ReservedTime).ToListAsync();
            }

                for (int Day = 0; Day < DoctorDaysOfWork.Count; Day++)
            {
                WorkSchedule WorkSchedule = new WorkSchedule();
                WorkSchedule.DayOfWork = DoctorDaysOfWork[Day];


                   slotsPerDay= FreeSlots.Where(F => F.Dayofwork == DoctorDaysOfWork[Day]).ToList();

                   slots = slotsPerDay.Select(Sl => new slotResponce()

                    {
                        slot_Id = Sl.id,
                        SlotNumber = Sl.slotnumber,
                        SlotTime = Sl.slot_time

                    }).ToList();


                    WorkSchedule.Slots = slots;
                    WorkSchedulesForDoctorPerDay.Add(WorkSchedule);
                }
            

            _WorkScheduleByDept.WorkSchedules = WorkSchedulesForDoctorPerDay;


            return _WorkScheduleByDept;

        }

    }
}
