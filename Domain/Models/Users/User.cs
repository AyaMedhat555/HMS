using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Domain.Models.Users
{
    public abstract class User
    {
        public int Id { get; set; }
        public DateTime CreatedDtm { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string NationalId { get; set; }
        public string? Image { get; set; }
        public string? BloodType { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }
        public string UserName { get; set; }
        public string? Mail { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        [NotMapped]
        public string Role { get; set; }

        [JsonIgnore]
        public Department Department { get; set; }
        public bool IsActive { get; set; } = true;
        public int? DepartmentId { get; set; }

    }
}
