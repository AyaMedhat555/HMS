using System.Text.Json.Serialization;

namespace SmartHospital.Models.Labs
{
    public abstract class TestParameter
    {
        public int Id { get; set; }
        public string TestParameterName { get; set; }
        public string FieldType { get; set; }
        public string InputPattern { get; set; }
        public string? Unit { get; set; }
        [JsonIgnore]
        public Test Test { get; set; }
        public int TestId { get; set; }

    }
}
