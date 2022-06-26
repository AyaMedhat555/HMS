using Domain.Models.Users;
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
        public DateTime CreatedDtm { get; set; }
        [JsonIgnore]
        public Test Test { get; set; }
        public int TestId { get; set; }
        [JsonIgnore]
        public Patient Patient { get; set; }
        public int PatientId { get; set; }
        [JsonIgnore]
        public Doctor? Doctor { get; set; }
        public int? DoctorId { get; set; }
        public IndoorPatientRecord? IndoorPatientRecord { get; set; }
        public int? IndoorPatientRecordId { get; set; }
    }
}
