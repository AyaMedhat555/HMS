namespace Domain.Models
{
    public class PatientRecord
    {
        public string OralMedicalHistory { get; set; }
        public string complain { get; set; }
        public Department Department { get; set; }
        public string Diagnosis { get; set; }

        //recommendation
    }
}
