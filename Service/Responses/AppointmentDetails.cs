using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Responses
{
    public class AppointmentDetails
    {
        public int NumberOfTodayAppointment { get; set; }
        public int NumberOfAllAppointments { get; set; }
        public int NumberOfInDoorPatients { get; set; }
    }

}
