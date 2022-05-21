using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DTO
{
    public class PatientScanDto
    {
        public int ScanRequestId { get; set; }
        public byte[]? Image { get; set; }
        public string WrittenReport { get; set; }
        public DateTime ScanDate { get; set; }

        public int? IndoorPatientRecordId { get; set; }
    }
}
