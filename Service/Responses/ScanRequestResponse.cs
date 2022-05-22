using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Responses
{
    public class ScanRequestResponse
    {
        public int Id { get; set; }
        public string ScanName { get; set; }
        public int ScanId { get; set; }
        public DateTime CreatedDtm { get; set; }
        public int PatientId { get; set; }
        public int? DoctorId { get; set; }
        public string PatientName { get; set; }
        public string DoctorName { get; set; }
    }
}
