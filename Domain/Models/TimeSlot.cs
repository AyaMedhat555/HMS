using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
   public class TimeSlot
    {
        public int id { get; set; } //time_slot_number
        public int slotnumber { get; set; } 
        public  DayOfWeek  Dayofwork { get; set; }
        public TimeSpan  slot_time { get; set; }
        public bool Reserved { get; set; } = false;
        public Doctor Doctor { get; set; }
        public int DoctorId { get; set; }

    }
}
