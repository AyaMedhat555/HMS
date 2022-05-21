namespace Domain.Models
{
        public class Patient : User
        {
           
            public virtual ICollection<ClinicPatientRecord> ClinicPatientRecord { get; set; } = new HashSet<ClinicPatientRecord>();
            public virtual ICollection<IndoorPatientRecord> IndoorPatientRecord { get; set; } = new HashSet<IndoorPatientRecord>();

        }
    }
