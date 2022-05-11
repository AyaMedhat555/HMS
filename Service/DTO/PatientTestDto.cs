using SmartHospital.Models.Labs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DTO
{
    public class PatientTestDto
    {
        public int LabRequestId { get; set; }
        public virtual ICollection<TestDetailsCategorical> CategoricalDetails { get; set; } = new HashSet<TestDetailsCategorical>();
        public virtual ICollection<TestDetailsNumerical> NumericalDetails { get; set; } = new HashSet<TestDetailsNumerical>();

        public DateTime TestDate { get; set; }
    }
}
