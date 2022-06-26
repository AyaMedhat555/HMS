using Service.DTO.Labs;
using Domain.Models.Labs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Responses
{
    public class PatientTestResponse
    {
        public int PatientTestId { get; set; }
        public int PatientId { get; set; }
        public string TestName { get; set; }
        public string PatientName { get; set; }
        public string? DoctorName { get; set; }
        public int? DoctorId { get; set; }
        public virtual ICollection<NeumericalDetailsDto> NumericalDetails { get; set; } = new HashSet<NeumericalDetailsDto>();
        public virtual ICollection<CategoricalDetailsDto> CategoricalDetails { get; set; } = new HashSet<CategoricalDetailsDto>();
        public DateTime TestDate { get; set; }
        public int? IndoorPatientRecordId { get; set; }
    }
}
