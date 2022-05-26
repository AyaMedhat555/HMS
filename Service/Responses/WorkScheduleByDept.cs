using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Responses
{
    public class WorkScheduleByDept
    { 
        public int DoctorId { get; set; }
        public string DoctorName { get; set; }
       public List<WorkSchedule> WorkSchedules { get; set; }
    }

    public class WorkSchedule
    {
        public DayOfWeek DayOfWork { get; set; }
        public List<slotResponce> Slots { get; set; }

    }

    public class slotResponce
    {
        public int slot_Id { get; set; }
        public int SlotNumber { get; set; }
        public TimeSpan SlotTime { get; set; }

    }
}


