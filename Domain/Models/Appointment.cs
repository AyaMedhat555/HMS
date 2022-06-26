
using Domain.Models.Users;

namespace Domain.Models
{
    public class Appointment
    {
        public int Id { get; set; }

        public bool Examined { get; set; }
        public DateTime AppointmentDate { get; set; }
        
        public string AppointmentType { get; set; }
        public string Complain { get; set; }    
        public Patient Patient { get; set; }

         public int PatientId { get; set; }

         public Doctor Doctor { get; set; }

         public int DoctorId { get; set; }

        public  float AppointmentCharge  { get; set; }


    }
}
