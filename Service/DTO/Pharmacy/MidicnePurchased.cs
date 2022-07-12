using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DTO.Pharmacy
{
    public class MidicnePurchased
    {
        public int StockMedicineId { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public int Barcode { get; set; }
        public int Concentration { get; set; }
        public DateTime AddedDtm { get; set; }
        public DateTime ExpireDtm { get; set; }
        public int StockId { get; set; }
        public int MedicineId { get; set; }
    }
}
