using Service.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DTO
{
    public class PrescriptionItemDto
    {
        
        public string Medicine_Name { get; set; }
        public string Medicine_concentration { get; set; } // medicine Strength
        public string Instructions { get; set; }
        public string MedicineType { get; set; }

        public string Dose { get; set; }

        public string Durarion { get; set; }
    }
}
