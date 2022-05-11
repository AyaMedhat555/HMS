using System.Text.Json.Serialization;

namespace SmartHospital.Models.Labs
{
    public abstract class TestDetails
    {
        [JsonIgnore]
        public int Id { get; set; }
        [JsonIgnore]
        public PatientTest? PatientTest { get; set; }
        public int TestParameterId { get; set; }
        [JsonIgnore]
        public TestParameter? TestParameter { get; set; }
        
    }
}
