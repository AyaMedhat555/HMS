namespace Domain.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Department_Name { get; set; } = string.Empty;
        public string? Location { get; set; }
        public virtual ICollection<Doctor> Doctors { get; set; } = new HashSet<Doctor>();
        public virtual ICollection<Nurse> Nurses { get; set; } = new HashSet<Nurse>();
        public virtual ICollection<Patient> Patients { get; set; } = new HashSet<Patient>();
        public bool IsActive { get; set; }

    }
}
