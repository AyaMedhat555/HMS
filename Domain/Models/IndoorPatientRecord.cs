

using Domain.Models.Labs;
using SmartHospital.Models.Labs;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    public class IndoorPatientRecord : PatientRecord
    {
        public int Id { get; set; }

        public DateTime? EnterDate { get; set; }
        public DateTime? DischargeDate { get; set; }
        public  bool Disharged { get; set; }
        public string CauseOfAdmission { get; set; }
        public string? Recommendation { get; set; }
        public Room Room { get; set; }
        public int RoomId { get; set; }

        public Doctor OrderdByDoctor { get; set; }

        public Patient Patient { get; set; }
        public int PatientId { get; set; }
        public virtual ICollection<Doctor> Doctors { get; set; } = new HashSet<Doctor>();

        public virtual ICollection<Nurse> Nurses { get; set; } = new HashSet<Nurse>();
        public virtual ICollection<Prescription> Prescriptions { get; set; } = new HashSet<Prescription>();
        public virtual ICollection<VitalSign> VitalSigns { get; set; } = new HashSet<VitalSign>();

        public virtual ICollection<Note> Notes { get; set; } = new HashSet<Note>();

        //public virtual Bill Bill { get; set; }
       // public int BillId { get; set; }

        public virtual ICollection<PatientScan> Scans { get; set; } = new HashSet<PatientScan>();
        public virtual ICollection<PatientTest> Tests { get; set; } = new HashSet<PatientTest>();




    }
}
