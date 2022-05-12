namespace Domain.Models.Labs
{
    public class Scan
    {
        public int Id { get; set; }
        public string ScanName { get; set; }

        //public byte[] Image { get; set; }
        //// public Doctor Doctor { get; set; }

        //// public Patient Patient { get; set; }

        public float ScanCharge { get; set; }
    }
}
