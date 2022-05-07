namespace SmartHospital.Models.Labs
{
    public abstract class TestDetails
    {
        public int TestDetailsId { get; set; }
        public PatientTest PatientTest { get; set; }
        public int PatientTestId { get; set; }
        public int TestParameterId { get; set; }

        public TestParameter TestParameter { get; set; }
        
    }
}
