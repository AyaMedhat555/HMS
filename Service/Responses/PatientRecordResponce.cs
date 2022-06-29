using Domain.Models;
using Domain.Models.Labs;
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
        public List< PatientScan> patientscans { get; set; }
        public List<PatientTest> patientTests { get; set; }
        public List<Prescription> prescriptions { get; set; }
        public int  RoomNumber { get; set; }
        public string RoomType { get; set; }
        public int FloorNumber { get; set; }
        public int BedNumber { get; set; }

    }
}
