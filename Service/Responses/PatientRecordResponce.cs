using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Responses
{
    public class PatientRecordResponce
    {
        public int PatientRecordId { get; set; }
        public DateTime? DiscahrgeDate { get; set; }
        public DateTime? EnterDate { get; set; }
        public List<int> ScanIds { get; set; }
        public List<int> LabIds { get; set; }
        public List<int> PrescriptionIds { get; set; }
        public int  RoomNumber { get; set; }
        public string RoomType { get; set; }
        public int FloorNumber { get; set; }
        public int BedNumber { get; set; }

    }
}
