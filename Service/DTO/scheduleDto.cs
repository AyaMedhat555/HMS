using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Service.DTO
{
    public class scheduleDto
    {
        public int DoctorId { get; set; }

        
        public DayOfWeek DayOfWork { get; set; }

        public string StartTime { get; set; }
       
        public string EndTime { get; set; }

        public string TimePerPatient { get; set; }
    }
}
