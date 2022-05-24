using Domain.Models;
using Service.DTO;

namespace Service.Responses
{
    public class VitalResponce
    {
        public string NurseName { get; set; }
        public string PatientName { get; set; }
        public int VitalsignId { get; set; }
        public string Pressure { get; set; }
        public int PulseRate { get; set; }
        public float Temperature { get; set; }
        public byte[]? ECG { get; set; }
        public float RespirationRate { get; set; }
        public DateTime vitals_date { get; set; }
        public NoteDto NoteDto { get; set; }
    }
}