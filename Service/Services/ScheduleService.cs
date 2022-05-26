using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Repository.IRepositories;
using Service.DTO;
using Service.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class ScheduleService : IScheduleService
    {


        private IScheduleRepository scheduleRepository { get; }
        private IDoctorRepository DoctorRepository { get; }


        public ScheduleService(IScheduleRepository _IscheduleRepository, IDoctorRepository _DoctorRepository)
        {
            scheduleRepository = _IscheduleRepository;
            DoctorRepository = _DoctorRepository;
        }

        public async Task<Schedule> AddSchedule(scheduleDto scheduledto)
        {
            var schedule = new Schedule
            {
                DoctorId = scheduledto.DoctorId,
                StartTime = TimeSpan.Parse(scheduledto.StartTime),
                EndTime =TimeSpan.Parse( scheduledto.EndTime),
                DayOfWork = (scheduledto.DayOfWork),
                TimePerPatient = TimeSpan.Parse(scheduledto.TimePerPatient)
            };
            return await scheduleRepository.Add(schedule);
        }

        public async Task<Schedule> UpdateSchedule(scheduleDto ScheduleDto)
        {

            var Schedule = new Schedule()
            {
                Id = ScheduleDto.Id,
                DoctorId = ScheduleDto.DoctorId,
                StartTime = TimeSpan.Parse(ScheduleDto.StartTime),
                EndTime = TimeSpan.Parse(ScheduleDto.EndTime),
                TimePerPatient = TimeSpan.Parse(ScheduleDto.TimePerPatient),
                DayOfWork = ScheduleDto.DayOfWork
            };
            return await scheduleRepository.Update(Schedule);
        }

        public async Task DeleteSchedule(int ScheduleId)
        {

            await scheduleRepository.Delete(ScheduleId);
            
        }

        public async Task<IEnumerable<ScheduleResponce>> GetSchedulesByDepartment_Id(int Department_ID)
        {
            List<Doctor> Doctors = await DoctorRepository.GetDoctorsByDepartment_Id(Department_ID).ToListAsync();

            List<Schedule> schedules;
            List<ScheduleResponce> ScheduleResponces = new List<ScheduleResponce>();

            for (int i = 0; i < Doctors.Count; i++)
            {

                schedules = await scheduleRepository.GetScheduleByDoctor_Id(Doctors[i].Id).ToListAsync();
                ScheduleResponces.Add(new ScheduleResponce()
                {
                    DoctorId = Doctors[i].Id,
                    DoctorName = Doctors[i].FirstName + Doctors[i].LastName,
                    ScheduleObjects = schedules.Select(S => new ScheduleObject()
                    {
                        DayOfWork = S.DayOfWork,
                        StartTime = S.StartTime.ToString(),
                        EndTime = S.EndTime.ToString(),
                        TimePerPatient = S.TimePerPatient.ToString()

                    }).ToList()

                });
            }
            return ScheduleResponces;
        }


        public async Task<IEnumerable<Schedule>> GetSchedulesByDoctor_Id(int Doctor_Id)
        {
            return await scheduleRepository.GetScheduleByDoctor_Id(Doctor_Id).ToListAsync();
        }
    }
}
