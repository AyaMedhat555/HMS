
using Domain.Models;
using Service.DTO;

namespace Service.Helpers
{
    public static class UserFactory
    {
        public static User CreateUser(UserDto user)
        {
            if (user.Role == "patient")
            {
                return new Patient();
            }
            if (user.Role == "doctor")
            {
                return new Doctor()
                {
                    
                };
            }
            if (user.Role == "receptionist")
            {
                return new Receptionist();
            }
            if (user.Role == "admin")
            {
                return new Admin();
            }
            if (user.Role == "nurse")
            {
                return new Nurse()
                {
                    DepartmentId = user.DepartmentId,
                    
                };
            }
            else
            {
                return null;
            }
        }
    }
}
