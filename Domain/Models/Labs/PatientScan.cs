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
        public byte[]? Image { get; set; }
        public string WrittenReport { get; set; } 
        public Patient Patient { get; set; }
        public int PatientId { get; set; }
        public Scan Scan { get; set; }
        public int ScanId { get; set; }
        public Doctor? Doctor { get; set; }
        public int? DoctorId { get; set; }
        public DateTime ScanDate { get; set; }
    }
}
