using Domain.Models.Users;
using Service.DTO.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Helpers
{
    public class UserMapper
    {
        public static Doctor ToDoctor(DoctorDto userDto)
        {
            Doctor newUser = new Doctor();
            newUser.Id = userDto.Id;
            newUser.PhoneNumber = userDto.PhoneNumber;
            newUser.UserName = userDto.UserName;
            newUser.BloodType = userDto.BloodType;
            newUser.Age = userDto.Age;
            newUser.FirstName = userDto.FirstName;
            newUser.LastName = userDto.LastName;
            newUser.Address = userDto.Address;
            newUser.NationalId = userDto.NationalId;
            newUser.Gender = userDto.Gender;
            if (userDto.Image != null)
            {
                Byte[] bytes = Convert.FromBase64String(userDto.Image);
                string filePath = ("wwwroot/UserImages/" + Path.GetFileName(userDto.UserName));
                File.WriteAllBytes(filePath, bytes);
                newUser.Image = filePath;
            }
            newUser.DepartmentId = userDto.DepartmentId;
            newUser.Mail = userDto.Mail;
            newUser.DocDegree = userDto.DocDegree;
            newUser.DocSpecialization = userDto.DocSpecialization;
            newUser.CreatedDtm = userDto.CreatedDtm;
            newUser.IsActive = userDto.IsActive;
            return newUser;
        }

        public static DoctorDto ToDoctorDto(Doctor user)
        {
            DoctorDto newUserDto = new DoctorDto();
            newUserDto.Id = user.Id;
            newUserDto.PhoneNumber = user.PhoneNumber;
            newUserDto.UserName = user.UserName;
            newUserDto.BloodType = user.BloodType;
            newUserDto.Age = user.Age;
            newUserDto.FirstName = user.FirstName;
            newUserDto.LastName = user.LastName;
            newUserDto.Address = user.Address;
            newUserDto.NationalId = user.NationalId;
            newUserDto.Gender = user.Gender;
            newUserDto.ImageName = user.Image;
            newUserDto.Mail = user.Mail;
            newUserDto.DepartmentId = user.DepartmentId;
            if (user.Department != null)
            {
                newUserDto.DepartmentName = user.Department.Department_Name;
            };
            newUserDto.DocSpecialization = user.DocSpecialization;
            newUserDto.DocDegree = user.DocDegree;
            newUserDto.IsActive = user.IsActive;
            newUserDto.CreatedDtm = user.CreatedDtm;
            return newUserDto;
        }

        public static Doctor UpdateDoctor(DoctorDto userDto, Doctor newUser)
        {
            newUser.Id = userDto.Id;
            newUser.PhoneNumber = userDto.PhoneNumber;
            newUser.UserName = userDto.UserName;
            newUser.BloodType = userDto.BloodType;
            newUser.Age = userDto.Age;
            newUser.FirstName = userDto.FirstName;
            newUser.LastName = userDto.LastName;
            newUser.Address = userDto.Address;
            newUser.NationalId = userDto.NationalId;
            newUser.Gender = userDto.Gender;
            if (userDto.Image != null)
            {
                Byte[] bytes = Convert.FromBase64String(userDto.Image);
                string filePath = ("wwwroot/UserImages/" + Path.GetFileName(userDto.UserName));
                File.WriteAllBytes(filePath, bytes);
                newUser.Image = filePath;
            }
            newUser.DepartmentId = userDto.DepartmentId;
            newUser.Mail = userDto.Mail;
            newUser.DocDegree = userDto.DocDegree;
            newUser.DocSpecialization = userDto.DocSpecialization;
            newUser.CreatedDtm = userDto.CreatedDtm;
            newUser.IsActive = userDto.IsActive;
            return newUser;
        }

        public static Admin ToAdmin(AdminDto userDto)
        {
            Admin newUser = new Admin();
            newUser.Id = userDto.Id;
            newUser.PhoneNumber = userDto.PhoneNumber;
            newUser.UserName = userDto.UserName;
            newUser.BloodType = userDto.BloodType;
            newUser.Age = userDto.Age;
            newUser.FirstName = userDto.FirstName;
            newUser.LastName = userDto.LastName;
            newUser.Address = userDto.Address;
            newUser.NationalId = userDto.NationalId;
            newUser.Gender = userDto.Gender;
            if (userDto.Image != null)
            {
                Byte[] bytes = Convert.FromBase64String(userDto.Image);
                string filePath = ("wwwroot/UserImages/" + Path.GetFileName(userDto.UserName));
                File.WriteAllBytes(filePath, bytes);
                newUser.Image = filePath;
            }
            newUser.DepartmentId = userDto.DepartmentId;
            newUser.Mail = userDto.Mail;
            newUser.CreatedDtm = userDto.CreatedDtm;
            newUser.IsActive = userDto.IsActive;
            return newUser;
        }

        public static AdminDto ToAdminDto(Admin user)
        {
            AdminDto newUserDto = new AdminDto();
            newUserDto.Id = user.Id;
            newUserDto.PhoneNumber = user.PhoneNumber;
            newUserDto.UserName = user.UserName;
            newUserDto.BloodType = user.BloodType;
            newUserDto.Age = user.Age;
            newUserDto.FirstName = user.FirstName;
            newUserDto.LastName = user.LastName;
            newUserDto.Address = user.Address;
            newUserDto.NationalId = user.NationalId;
            newUserDto.Gender = user.Gender;
            newUserDto.ImageName = user.Image;
            newUserDto.Mail = user.Mail;
            newUserDto.DepartmentId = user.DepartmentId;
            if (user.Department != null)
            {
                newUserDto.DepartmentName = user.Department.Department_Name;
            };
            newUserDto.IsActive = user.IsActive;
            newUserDto.CreatedDtm = user.CreatedDtm;
            return newUserDto;
        }

        public static Admin UpdateAdmin(AdminDto userDto, Admin newUser)
        {
            newUser.Id = userDto.Id;
            newUser.PhoneNumber = userDto.PhoneNumber;
            newUser.UserName = userDto.UserName;
            newUser.BloodType = userDto.BloodType;
            newUser.Age = userDto.Age;
            newUser.FirstName = userDto.FirstName;
            newUser.LastName = userDto.LastName;
            newUser.Address = userDto.Address;
            newUser.NationalId = userDto.NationalId;
            newUser.Gender = userDto.Gender;
            if (userDto.Image != null)
            {
                Byte[] bytes = Convert.FromBase64String(userDto.Image);
                string filePath = ("wwwroot/UserImages/" + Path.GetFileName(userDto.UserName));
                File.WriteAllBytes(filePath, bytes);
                newUser.Image = filePath;
            }
            newUser.DepartmentId = userDto.DepartmentId;
            newUser.Mail = userDto.Mail;
            newUser.CreatedDtm = userDto.CreatedDtm;
            newUser.IsActive = userDto.IsActive;
            return newUser;
        }
        public static Nurse ToNurse(NurseDto userDto)
        {
            Nurse newUser = new Nurse();
            newUser.Id = userDto.Id;
            newUser.PhoneNumber = userDto.PhoneNumber;
            newUser.UserName = userDto.UserName;
            newUser.BloodType = userDto.BloodType;
            newUser.Age = userDto.Age;
            newUser.FirstName = userDto.FirstName;
            newUser.LastName = userDto.LastName;
            newUser.Address = userDto.Address;
            newUser.NationalId = userDto.NationalId;
            newUser.Gender = userDto.Gender;
            if (userDto.Image != null)
            {
                Byte[] bytes = Convert.FromBase64String(userDto.Image);
                string filePath = ("wwwroot/UserImages/" + Path.GetFileName(userDto.UserName));
                File.WriteAllBytes(filePath, bytes);
                newUser.Image = filePath;
            }
            newUser.DepartmentId = userDto.DepartmentId;
            newUser.Mail = userDto.Mail;
            newUser.NurseSpecialization = userDto.NurseSpecialization;
            newUser.NurseDegree = userDto.NurseDegree;
            newUser.CreatedDtm = userDto.CreatedDtm;
            newUser.IsActive = userDto.IsActive;
            return newUser;
        }

        public static NurseDto ToNurseDto(Nurse user)
        {
            NurseDto newUserDto = new NurseDto();
            newUserDto.Id = user.Id;
            newUserDto.PhoneNumber = user.PhoneNumber;
            newUserDto.UserName = user.UserName;
            newUserDto.BloodType = user.BloodType;
            newUserDto.Age = user.Age;
            newUserDto.FirstName = user.FirstName;
            newUserDto.LastName = user.LastName;
            newUserDto.Address = user.Address;
            newUserDto.NationalId = user.NationalId;
            newUserDto.Gender = user.Gender;
            newUserDto.ImageName = user.Image;
            newUserDto.Mail = user.Mail;
            newUserDto.DepartmentId = user.DepartmentId;
            if(user.Department != null)
            {
                newUserDto.DepartmentName = user.Department.Department_Name;
            };
            newUserDto.NurseDegree = user.NurseDegree;
            newUserDto.NurseSpecialization = user.NurseSpecialization;
            newUserDto.IsActive = user.IsActive;
            newUserDto.CreatedDtm = user.CreatedDtm;
            return newUserDto;
        }

        public static Nurse UpdateNurse(NurseDto userDto, Nurse newUser)
        {
            newUser.Id = userDto.Id;
            newUser.PhoneNumber = userDto.PhoneNumber;
            newUser.UserName = userDto.UserName;
            newUser.BloodType = userDto.BloodType;
            newUser.Age = userDto.Age;
            newUser.FirstName = userDto.FirstName;
            newUser.LastName = userDto.LastName;
            newUser.Address = userDto.Address;
            newUser.NationalId = userDto.NationalId;
            newUser.Gender = userDto.Gender;
            if (userDto.Image != null)
            {
                Byte[] bytes = Convert.FromBase64String(userDto.Image);
                string filePath = ("wwwroot/UserImages/" + Path.GetFileName(userDto.UserName));
                File.WriteAllBytes(filePath, bytes);
                newUser.Image = filePath;
            }
            newUser.DepartmentId = userDto.DepartmentId;
            newUser.Mail = userDto.Mail;
            newUser.NurseDegree = userDto.NurseDegree;
            newUser.NurseSpecialization = userDto.NurseSpecialization;
            newUser.CreatedDtm = userDto.CreatedDtm;
            newUser.IsActive = userDto.IsActive;
            return newUser;
        }



        public static Patient ToPatient(PatientDto userDto)
        {
            Patient newUser = new Patient();
            newUser.Id = userDto.Id;
            newUser.PhoneNumber = userDto.PhoneNumber;
            newUser.UserName = userDto.UserName;
            newUser.BloodType = userDto.BloodType;
            newUser.Age = userDto.Age;
            newUser.FirstName = userDto.FirstName;
            newUser.LastName = userDto.LastName;
            newUser.Address = userDto.Address;
            newUser.NationalId = userDto.NationalId;
            newUser.Gender = userDto.Gender;
            if (userDto.Image != null)
            {
                Byte[] bytes = Convert.FromBase64String(userDto.Image);
                string filePath = ("wwwroot/UserImages/" + Path.GetFileName(userDto.UserName));
                File.WriteAllBytes(filePath, bytes);
                newUser.Image = filePath;
            }
            newUser.DepartmentId = userDto.DepartmentId;
            newUser.Mail = userDto.Mail;
            newUser.CreatedDtm = userDto.CreatedDtm;
            newUser.IsActive = userDto.IsActive;
            return newUser;
        }

        public static PatientDto ToPatientDto(Patient user)
        {
            PatientDto newUserDto = new PatientDto();
            newUserDto.Id = user.Id;
            newUserDto.PhoneNumber = user.PhoneNumber;
            newUserDto.UserName = user.UserName;
            newUserDto.BloodType = user.BloodType;
            newUserDto.Age = user.Age;
            newUserDto.FirstName = user.FirstName;
            newUserDto.LastName = user.LastName;
            newUserDto.Address = user.Address;
            newUserDto.NationalId = user.NationalId;
            newUserDto.Gender = user.Gender;
            newUserDto.ImageName = user.Image;
            newUserDto.Mail = user.Mail;
            newUserDto.DepartmentId = user.DepartmentId;
            if (user.Department != null)
            {
                newUserDto.DepartmentName = user.Department.Department_Name;
            };
            newUserDto.BloodType = user.BloodType;
            newUserDto.IsActive = user.IsActive;
            newUserDto.CreatedDtm = user.CreatedDtm;
            return newUserDto;
        }

        public static Patient UpdatePatient(PatientDto userDto, Patient newUser)
        {
            newUser.Id = userDto.Id;
            newUser.PhoneNumber = userDto.PhoneNumber;
            newUser.UserName = userDto.UserName;
            newUser.BloodType = userDto.BloodType;
            newUser.Age = userDto.Age;
            newUser.FirstName = userDto.FirstName;
            newUser.LastName = userDto.LastName;
            newUser.Address = userDto.Address;
            newUser.NationalId = userDto.NationalId;
            newUser.Gender = userDto.Gender;
            if (userDto.Image != null)
            {
                Byte[] bytes = Convert.FromBase64String(userDto.Image);
                string filePath = ("wwwroot/UserImages/" + Path.GetFileName(userDto.UserName));
                File.WriteAllBytes(filePath, bytes);
                newUser.Image = filePath;
            }
            newUser.DepartmentId = userDto.DepartmentId;
            newUser.Mail = userDto.Mail;
            newUser.CreatedDtm = userDto.CreatedDtm;
            newUser.IsActive = userDto.IsActive;
            return newUser;
        }


        public static Receptionist ToReceptionist(ReceptionistDto userDto)
        {
            Receptionist newUser = new Receptionist();
            newUser.Id = userDto.Id;
            newUser.PhoneNumber = userDto.PhoneNumber;
            newUser.UserName = userDto.UserName;
            newUser.BloodType = userDto.BloodType;
            newUser.Age = userDto.Age;
            newUser.FirstName = userDto.FirstName;
            newUser.LastName = userDto.LastName;
            newUser.Address = userDto.Address;
            newUser.NationalId = userDto.NationalId;
            newUser.Gender = userDto.Gender;
            if (userDto.Image != null)
            {
                Byte[] bytes = Convert.FromBase64String(userDto.Image);
                string filePath = ("wwwroot/UserImages/" + Path.GetFileName(userDto.UserName));
                File.WriteAllBytes(filePath, bytes);
                newUser.Image = filePath;
            }
            newUser.DepartmentId = userDto.DepartmentId;
            newUser.Mail = userDto.Mail;
            newUser.CreatedDtm = userDto.CreatedDtm;
            newUser.IsActive = userDto.IsActive;
            return newUser;
        }

        public static ReceptionistDto ToReceptionistDto(Receptionist user)
        {
            ReceptionistDto newUserDto = new ReceptionistDto();
            newUserDto.Id = user.Id;
            newUserDto.PhoneNumber = user.PhoneNumber;
            newUserDto.UserName = user.UserName;
            newUserDto.BloodType = user.BloodType;
            newUserDto.Age = user.Age;
            newUserDto.FirstName = user.FirstName;
            newUserDto.LastName = user.LastName;
            newUserDto.Address = user.Address;
            newUserDto.NationalId = user.NationalId;
            newUserDto.Gender = user.Gender;
            newUserDto.ImageName = user.Image;
            newUserDto.Mail = user.Mail;
            newUserDto.DepartmentId = user.DepartmentId;
            if (user.Department != null)
            {
                newUserDto.DepartmentName = user.Department.Department_Name;
            };
            newUserDto.IsActive = user.IsActive;
            newUserDto.CreatedDtm = user.CreatedDtm;
            return newUserDto;
        }

        public static Receptionist UpdateReceptionist(ReceptionistDto userDto, Receptionist newUser)
        {
            newUser.Id = userDto.Id;
            newUser.PhoneNumber = userDto.PhoneNumber;
            newUser.UserName = userDto.UserName;
            newUser.BloodType = userDto.BloodType;
            newUser.Age = userDto.Age;
            newUser.FirstName = userDto.FirstName;
            newUser.LastName = userDto.LastName;
            newUser.Address = userDto.Address;
            newUser.NationalId = userDto.NationalId;
            newUser.Gender = userDto.Gender;
            if (userDto.Image != null)
            {
                Byte[] bytes = Convert.FromBase64String(userDto.Image);
                string filePath = ("wwwroot/UserImages/" + Path.GetFileName(userDto.UserName));
                File.WriteAllBytes(filePath, bytes);
                newUser.Image = filePath;
            }
            newUser.DepartmentId = userDto.DepartmentId;
            newUser.Mail = userDto.Mail;
            newUser.CreatedDtm = userDto.CreatedDtm;
            newUser.IsActive = userDto.IsActive;
            return newUser;
        }

    }
}
