using Domain.Models.Users;

namespace Domain.Models
{
    public class Prescription
    {
        public int PrescriptionId { get; set; }
        public virtual ICollection<PrescriptionItem> PrescriptionItems { get; set; } = new HashSet<PrescriptionItem>();

        public DateTime Prescription_Date { get; set; }
        public DateTime? re_appointement_date { get; set; }

        public virtual Patient patient { get; set; } //Navigational Property
        public int PatientId { get; set; }
        public virtual Doctor Doctor { get; set; } //Navigational Property

        public int DoctorId { get; set; }
        public string? Diagnosis {get;set; }
        public int? IndoorPatientRecordId { get; set; }
    }
}
