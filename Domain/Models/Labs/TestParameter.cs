namespace SmartHospital.Models.Labs
{
    public abstract class TestParameter
    {
        public int TestParameterId { get; set; }
        public string TestParameterName { get; set; }
   
        public string Unit { get; set; }
        public Test Test { get; set; }
        public int TestId { get; set; }

    }
}
