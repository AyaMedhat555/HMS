namespace Domain.Models
{
    public abstract class PatientRecord
    {
        public string OralMedicalHistory { get; set; }
        public Department Department { get; set; }
        public int DepartmentId { get; set; }
        public string? Diagnosis { get; set; }
    }
}
