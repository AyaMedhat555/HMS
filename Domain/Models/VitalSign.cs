namespace Domain.Models
{
    public class VitalSign
    {
        public int Id { get; set; }
        public string Pressure { get; set; }
        public int PulseRate { get; set; }
        public float Temperature { get; set; }
        public byte[]? ECG { get; set; }
        public float RespirationRate { get; set; }
        public DateTime vitals_date { get; set; }
        public Nurse Nurse { get; set; }
       
        public int NurseId { get; set; }
        public Note Note { get; set; }
        public int NoteId { get; set; }
        public Patient Patient { get; set; }
        public int Patientid { get; set; }

    }
}
