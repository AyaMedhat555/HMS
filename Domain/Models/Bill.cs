using Domain.Models.Users;

namespace Domain.Models
{
    public class Bill
    {
        public int Id { get; set; }
        public float? RoomCharges { get; set; }
        public float? PrescriptionCharges { get; set; }
        public Patient patient { get; set; }
        public int PatientID { get; set; }
        public float? AppointmentsCharges { get; set; }
        public float? TestCharges { get; set; }
        public float? ScansCharges { get; set; }
    }
}
