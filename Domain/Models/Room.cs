namespace Domain.Models
{
    public class Room
    {
        public int Id { get; set; }
        
        public int RoomCharges { get; set; }
        public string RoomType { get; set; }
        public int NumberOfBeds { get; set; }
        public int FloorNumber { get; set; }
        public int RoomNumber { get; set; }
        public bool Reserved { get; set; }
        public Department Department { get; set; }
        public int DepartmentId { get; set; }
        public virtual ICollection<Bed> Beds { get; set; } = new HashSet<Bed>();

    }
}


