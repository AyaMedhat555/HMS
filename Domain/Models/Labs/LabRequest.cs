using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.Models.Labs
{
    public class LabRequest
    {
        public int Id { get; set; }
        public string LabName { get; set; }
        public DateTime CreatedDtm { get; set; }
        [JsonIgnore]
        public Patient Patient { get; set; }
        public int PatientId { get; set; }
        [JsonIgnore]
        public Doctor Doctor { get; set; }
        public int DoctorId { get; set; }
    }
}
