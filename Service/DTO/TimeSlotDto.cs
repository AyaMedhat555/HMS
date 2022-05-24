using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DTO
{
    public class TimeSlotDto
    {
        public int id { get; set; }
        public int slotnumber { get; set; }
        public DayOfWeek Dayofwork { get; set; }
        public string slot_time { get; set; }
        public bool Reserved { get; set; } 
  
        public int DoctorId { get; set; }
    }
}
