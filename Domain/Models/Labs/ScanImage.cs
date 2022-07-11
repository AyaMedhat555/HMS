using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Labs
{
    public class ScanImage
    {
        public int Id { get; set; }
        public string Path { get; set; }
        public byte[] Content { get; set; }
        public PatientScan PatientScan { get; set; }
        public int PatientScanId { get; set; }
    }
}
