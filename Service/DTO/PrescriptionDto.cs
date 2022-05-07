using Domain.Models;
using Service.DTO;
using Repository;


namespace Service.IServices
{
    public class PrescriptionDto
    {
        public string Medicine_Name { get; set; }
        public string Medicine_concentration { get; set; } // medicine Strength
        public string Instructions { get; set; }
        public string MedicineType { get; set; }
        public string Dose { get; set; }

        public string Durarion { get; set; }
        public DateTime Prescription_Date { get; set; }
        public DateTime re_appointement_date { get; set; }
        public int  Doctor_Id { get; set; }
        
    }

   
}
