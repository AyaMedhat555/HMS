using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DTO.Pharmacy
{
    public class StockDto
    {
        public int StockId { get; set; }
        public string StockLocation { get; set; }
        public List<StockMedicineDto>? StockMedicines { get; set; }
    }
}
