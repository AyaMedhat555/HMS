
namespace Domain.Models
{
    public class ClinicPatient:PatientRecord
    {
        public int ClinicPatientId { get; set; }
        public float Appointmentcharges { get; set; }

        // navigational properties
      //  public Prescription Prescription { get; set; }
        public  Appointment  Appointment {get;set;}
        public  Doctor Doctor { get; set; }
        

    }
}
