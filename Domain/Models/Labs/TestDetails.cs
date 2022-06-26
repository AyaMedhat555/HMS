using System.Text.Json.Serialization;

namespace Domain.Models.Labs
{
    public abstract class TestDetails
    {
        [JsonIgnore]
        public int Id { get; set; }
        [JsonIgnore]
        public PatientTest PatientTest { get; set; }
        public int PatientTestId { get; set; }
        public int TestParameterId { get; set; }
        [JsonIgnore]
        public TestParameter TestParameter { get; set; }

    }
}
