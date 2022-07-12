using Domain.Models.Users;

namespace Domain.Models
{
    public class Bill
    {
        public int Id { get; set; }
        public double? RoomCharges { get; set; } = 0;
        public double? PrescriptionCharges { get; set; } = 0;
        //public Patient Patient { get; set; }
        //public int PatientID { get; set; }
        public IndoorPatientRecord IndoorPatientRecord { get; set; } 
        public int IndoorPatientRecordID { get; set; }
        public double? AppointmentsCharges { get; set; } = 0;
        public double? TestCharges { get; set; } = 0;
        public double? ScansCharges { get; set; } = 0;
    }
}
