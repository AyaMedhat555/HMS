namespace Domain.Models
{
        public class Patient : User
        {
           
           
            public virtual ICollection<ClinicPatient> ClinicPatientRecord { get; set; } = new HashSet<ClinicPatient>();
            public virtual ICollection<IndoorPatient> IndoorPatientRecord { get; set; } = new HashSet<IndoorPatient>();

        }
    }
