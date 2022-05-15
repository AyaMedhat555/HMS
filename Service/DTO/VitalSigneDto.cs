using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DTO
{
    public class VitalSigneDto
    {
        //public int Id { get; set; }
        public string Pressure { get; set; }
        public int PulseRate { get; set; }
        public float Temperature { get; set; }
        public byte[]? ECG { get; set; }
        public float RespirationRate { get; set; }
        public DateTime vitals_date { get; set; }
        public int NurseId { get; set; }
        public Note Note { get; set; }
        public int PatientId { get; set; }
    }
}
