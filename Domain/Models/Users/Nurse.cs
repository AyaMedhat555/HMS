namespace Domain.Models.Users
{
    public class Nurse : User
    {
        public string NurseDegree { get; set; }
        public string NurseSpecialization { get; set; }
    }
}
