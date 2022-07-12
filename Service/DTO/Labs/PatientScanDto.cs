using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DTO.Labs
{
    public class PatientScanDto
    {
        public int PatientScanId { get; set; }
        public int ScanRequestId { get; set; }
        public virtual ICollection<ScanImageDto> ScanImages { get; set; } = new HashSet<ScanImageDto>();
        public string WrittenReport { get; set; }
        public DateTime ScanDate { get; set; }

        public int? IndoorPatientRecordId { get; set; }
    }
}
