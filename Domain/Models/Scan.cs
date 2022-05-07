namespace Domain.Models
{
    public class Scan
    {
        public int Id { get; set; }
        public string ScanType {get;set;}

        public byte[] Image { get; set; }
       // public Doctor Doctor { get; set; }

       // public Patient Patient { get; set; }
        
        public float ScanCharge { get; set; }
    }
}
