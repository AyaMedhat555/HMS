using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DTO
{
    public class ReservePatientDto
    {
        public string CauseOfAdmission { get; set; } 
        public int  RoomId { get; set; }
        public int BedId { get; set; }
        public int DepartmentId { get; set; }

        public string OralMedicalHistory { get; set; }

        public  int  OrderdByDoctorId { get; set; }

        public int PatientId { get; set; }

        public DateTime? EnterDate { get; set; }

    }
}

