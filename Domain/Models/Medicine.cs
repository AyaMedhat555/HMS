using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class Medicine
    {

        public int MedicineId { get; set; }
        public string Name { get; set; } 
        public string Description { get; set; }

        [Required]
       public int Quantity { get; set; }

        [Required]
        public double Price { get; set; }
        [Required]
        public int Barcode { get; set; }



    }
}
