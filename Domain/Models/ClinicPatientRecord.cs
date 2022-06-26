
using Domain.Models.Users;

namespace Domain.Models
{
    public class ClinicPatientRecord:PatientRecord
    {

        public int Id { get; set; }
        

        // navigational properties
        public Prescription Prescription { get; set; }
        public Appointment  Appointment {get;set;}
        public  Doctor Doctor { get; set; }

        public int DoctorId { get; set; }

    }
}
