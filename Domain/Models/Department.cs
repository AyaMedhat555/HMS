namespace Domain.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Department_Name { get; set; } = string.Empty;
        public string? Location { get; set; }
    }
}
