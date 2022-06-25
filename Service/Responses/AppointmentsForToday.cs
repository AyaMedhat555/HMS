using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Responses
{
    public class AppointmentsForToday
    {
        public string PatientName { get; set; }
        public TimeSpan SlotTime { get; set; }
        public int PatientId { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string Complain { get; set; }
        public bool Examined { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string DoctorName { get; set; }




    }
}


