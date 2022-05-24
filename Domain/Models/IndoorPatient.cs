

using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    public class IndoorPatient : PatientRecord
    {
      
        public float Room_charges { get; set; }
        public bool In { get; set; }

        // navigational part

        public virtual ICollection<Doctor> Doctors { get; set; } = new HashSet<Doctor>();

        public virtual ICollection<Nurse> Nurses { get; set; } = new HashSet<Nurse>();

        public virtual ICollection<PrescriptionItem> Prescriptions { get; set; } = new HashSet<PrescriptionItem>();
        public virtual ICollection<VitalSign> VitalSigns { get; set; } = new HashSet<VitalSign>();

        public virtual ICollection<Note> NurseNotes { get; set; } = new HashSet<Note>();


    }
}
