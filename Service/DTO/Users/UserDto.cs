using System.Text.Json.Serialization;

namespace Service.DTO.Users
{
    public class UserDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime CreatedDtm { get; set; }

        //[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public int Age { get; set; }
        //[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string NationalId { get; set; }
        //[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Image { get; set; }
        //[JsonIgnore(Conditikon = JsonIgnoreCondition.WhenWritingNull)]
        public string? ImageName { get; set; }
        public string? BloodType { get; set; }
        //[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string PhoneNumber { get; set; }
        //[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Address { get; set; }
        //[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Gender { get; set; }
        //[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string UserName { get; set; }
        //[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Mail { get; set; }
        //[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Password { get; set; }
        //[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Role { get; set; }
        //[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? DepartmentId { get; set; }
        //[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? DepartmentName { get; set; }
        //[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool IsActive { get; set; } = true;
    }

}
