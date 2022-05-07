using Service.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Responses
{
    public class DepartmentsEmps
    {
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public List<DoctorDto>? DoctorDtos { get; set; }
        public List<NurseDto>? NurseDtos { get; set; }
    }
}
