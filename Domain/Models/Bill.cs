namespace Domain.Models
{
    public class Bill
    {
        public int Id { get; set; }
        public float RoomCharges { get; set; }
        public float MedicineCharges { get; set; }
      //  public Patient patient { get; set; }
      //  public int PatientID { get; set; }
        public float AppointmentsCharges { get; set; }
        public float LabsCharges { get; set; }
        public float ScansCharges { get; set; }
    }
}
