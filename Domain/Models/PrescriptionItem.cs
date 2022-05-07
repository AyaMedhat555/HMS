namespace Domain.Models
{
    public class PrescriptionItem
    {
        public int PrescriptionItemId { get; set; }
        public string Medicine_Name { get; set; }
        public string Medicine_concentration { get; set; } // medicine Strength
        public string Instructions { get; set; }

        public string MedicineType { get; set; }

        public string Dose { get; set; }

        public string Durarion { get; set; }
        

    }
}


//- patient: Patient
//- doctor_id: int

