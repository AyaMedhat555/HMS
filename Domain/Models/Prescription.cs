namespace Domain.Models
{
    public class Prescription
    {
        public int PrescriptionId { get; set; }
       // public virtual ICollection<PrescriptionItem> PrescriptionItems { get; set; } = new HashSet<PrescriptionItem>();

        public DateTime Prescription_Date { get; set; }
        public DateTime re_appointement_date { get; set; }

        // patient type dto
       // public virtual Doctor Doctor { get; set; } ///Navigational Property

        // [ForeignKey("Doctor_PrescriptionID_FK")]
       // public int DoctorId { get; set; } ///FK
    }
}
