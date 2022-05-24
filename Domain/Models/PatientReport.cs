using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class PatientReport
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public DateTime? DateOfDischarge { get; set; }
        public string Recommendation { get; set; }
        public string CauseOfAdmission { get; set; }
        public Prescription LastPrescription { get; set; }
        public ICollection<PrescriptionItem> ListOfMedicineNames { get; set; } = new HashSet<PrescriptionItem>();
        public ICollection<string> ScanNames { get; set; } = new HashSet<string>();
        public ICollection<string> TestNames { get; set; } = new HashSet<string>();

        public int? IndoorPatientRecordId { get; set; }




    }



}





