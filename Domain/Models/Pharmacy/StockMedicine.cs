using System.ComponentModel.DataAnnotations;

namespace Domain.Models.Pharmacy
{
    public class StockMedicine
    {
        public int Id { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public int Barcode { get; set; }
        public int ConcentrationInMg { get; set; }
        public DateTime AddedDtm { get; set; }
        public DateTime ExpireDtm { get; set; }
        public virtual Stock Stock { get; set; }
        public virtual Medicine Medicine { get; set; }
        public int StockId { get; set; }
        public int MedicineId { get; set; }

    }
}
