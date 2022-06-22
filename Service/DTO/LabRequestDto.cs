using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DTO
{
    public class LabRequestDto
    {
        public int Id { get; set; }
        public string LabName { get; set; }
        public DateTime CreatedDtm { get; set; }
        public int PatientId { get; set; }
        public int? DoctorId { get; set; }
       public int? IndoorPatientRecordId { get; set; }
    }
}
