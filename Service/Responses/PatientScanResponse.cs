using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Responses
{
    public class PatientScanResponse
    {
        public int PatientScanId { get; set; }
        public int PatientId { get; set; }
        public string ScanName { get; set; }
        public int? DoctorId { get; set; }
        public byte[]? Image { get; set; }
        public string WrittenReport { get; set; }
        public DateTime ScanDate { get; set; }
    }
}
