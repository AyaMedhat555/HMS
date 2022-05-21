using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Responses
{
    public class ReportEntry
    {
        public int PatientId { get; set; }
        public DateTime DateOfDischarge { get; set; }
        public string Recommendation { get; set; }

        public int? IndoorPatientRecordId { get; set; }
    }
}



