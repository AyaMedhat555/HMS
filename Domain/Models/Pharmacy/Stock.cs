using System.ComponentModel.DataAnnotations;

namespace Domain.Models.Pharmacy
{
    public class Stock
    {
        public int StockId { get; set; }
        public string StockLocation { get; set; }
        public virtual ICollection<StockMedicine> StockMedicines { get; set; } = new HashSet<StockMedicine>();
    }
}
