using Domain.Models.Pharmacy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DTO.Pharmacy
{
    public class MedicineDto
    {
        public int MedicineId { get; set; }
        public string CommercialName { get; set; }
        public string Group { get; set; }
        public string EffectiveSubstance { get; set; }
        public string Description { get; set; }
        public StockMedicineDto? StockMedicines { get; set; }
    }
}
