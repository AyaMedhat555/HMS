using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DTO
{
    public class ScheduleResponce
    {

        public int DoctorId { get; set; }
        public string? DoctorName { get; set; }

        public List<ScheduleObject> ScheduleObjects { get; set; }   
    }

    public class ScheduleObject
    {
        public DayOfWeek DayOfWork { get; set; }

        public string StartTime { get; set; }

        public string EndTime { get; set; }

        public string TimePerPatient { get; set; }
        public int ScheduleId { get; set; }
    }
}
