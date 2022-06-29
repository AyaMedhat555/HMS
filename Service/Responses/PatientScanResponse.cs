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
        public string PatientName { get; set; }
        public string? DoctorName { get; set; }
        public int? DoctorId { get; set; }
        public virtual ICollection<String> ScanImages { get; set; } = new HashSet<String>();
        public string WrittenReport { get; set; }
        public DateTime ScanDate { get; set; }
        public int? IndoorPatientRecordId { get; set; }
    }
}
