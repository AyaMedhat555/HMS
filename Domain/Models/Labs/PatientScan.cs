using Domain.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Labs
{
    public class PatientScan
    {
        public int PatientScanId { get; set; }
        public virtual ICollection<ScanImage> ScanImages { get; set; } = new HashSet<ScanImage>();
        public string WrittenReport { get; set; } 
        public Patient Patient { get; set; }
        public int PatientId { get; set; }
        public Scan Scan { get; set; }
        public int ScanId { get; set; }
        public Doctor? Doctor { get; set; }
        public int? DoctorId { get; set; }
        public DateTime ScanDate { get; set; }
        public IndoorPatientRecord? IndoorPatientRecord { get; set; }
        public int? IndoorPatientRecordId { get; set; }
    }
}
