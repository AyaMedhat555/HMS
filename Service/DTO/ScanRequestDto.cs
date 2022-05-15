using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DTO
{
    public class ScanRequestDto
    {
        public int Id { get; set; }
        public string ScanName { get; set; }
        public DateTime CreatedDtm { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
    }
}
