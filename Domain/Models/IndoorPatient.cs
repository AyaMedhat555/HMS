

using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    public class IndoorPatient : PatientRecord
    {
        public int IndoorPatientId { get; set; }


        public float Room_charges { get; set; }
        //[NotMapped]
        // public Dictionary<string, float> Meals_Time { get; set; } //as breakfast-time=2


        // navigational part


        // public  virtual ICollection<Doctor> Doctors { get; set; } = new HashSet<Doctor>();

        // public virtual ICollection<Nurse> Nurses { get; set; } = new HashSet<Nurse>();

        // public virtual ICollection<PrescriptionItem> Prescriptions { get; set; } = new HashSet<PrescriptionItem>();
        // public virtual ICollection<VitalSigns> VitalSigns { get; set; } = new HashSet<VitalSigns>();

        //  public virtual ICollection<Note> NurseNotes { get; set; } = new HashSet<Note>();

    }
}
