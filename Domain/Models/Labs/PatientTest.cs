using Domain.Models;

namespace SmartHospital.Models.Labs
{
    public class PatientTest
    {
        public int PatientTestId { get; set; }
        public Patient Patient { get; set; }
        public int PatientId { get; set; }
        public Test Test { get; set; }
        public int TestId { get; set; }
        public Doctor? Doctor { get; set; }
        public int? DoctorId { get; set; }
        public virtual ICollection<TestDetailsCategorical> CategoricalDetails { get; set; } = new HashSet<TestDetailsCategorical>();
        public virtual ICollection<TestDetailsNumerical> NumericalDetails { get; set; } = new HashSet<TestDetailsNumerical>();

        public DateTime TestDate { get; set; }
    }
}
