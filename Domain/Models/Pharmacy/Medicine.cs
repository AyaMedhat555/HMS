using System.ComponentModel.DataAnnotations;

namespace Domain.Models.Pharmacy
{
    public class Medicine
    {
        public int MedicineId { get; set; }
        public string CommercialName { get; set; }
        public string Group { get; set; }
        public string EffectiveSubstance { get; set; }
        public virtual ICollection<StockMedicine> StockMedicines { get; set; } = new HashSet<StockMedicine>();
        public string Description { get; set; }
    }
}
