using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Responses
{
    public class InDoorPatientsInfo
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Id { get; set; }
        public int IndoorPatientId { get; set; }
        public int Age { get; set; }

        public string PhoneNumber { get; set; }
        public string? Image { get; set; }

        public string Gender { get; set; }

        public string CauseOfAdmission { get; set; }

        public string OralMedicalHistory { get; set; }

        public DateTime? EnterDate  { get; set; }
        public int Room_Number { get; set; }
        public int BedNumber { get; set; }
        public int Floor_Number { get; set; }




    }
}







