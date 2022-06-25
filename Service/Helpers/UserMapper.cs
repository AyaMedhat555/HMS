using Domain.Models;
using Service.DTO;
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
            newUser.Image = userDto.Image;
            newUser.DepartmentId = userDto.DepartmentId;
            newUser.Mail = userDto.Mail;
            newUser.DocDegree = userDto.DocDegree;
            newUser.DocSpecialization = userDto.DocSpecialization;
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
            newUserDto.Image = user.Image;
            newUserDto.Mail = user.Mail;
            newUserDto.DepartmentId = user.DepartmentId;
            newUserDto.DepartmentName = user.Department.Department_Name;
            newUserDto.DocSpecialization = user.DocSpecialization;
            newUserDto.DocDegree = user.DocDegree;
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
            newUser.Image = userDto.Image;
            newUser.DepartmentId = userDto.DepartmentId;
            newUser.Mail = userDto.Mail;
            newUser.DocDegree = userDto.DocDegree;
            newUser.DocSpecialization = userDto.DocSpecialization;
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
            newUser.Image = userDto.Image;
            newUser.DepartmentId = userDto.DepartmentId;
            newUser.Mail = userDto.Mail;
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
            newUserDto.Image = user.Image;
            newUserDto.Mail = user.Mail;
            newUserDto.DepartmentId = user.DepartmentId;
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
            newUser.Image = userDto.Image;
            newUser.DepartmentId = userDto.DepartmentId;
            newUser.Mail = userDto.Mail;
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
            newUser.Image = userDto.Image;
            newUser.DepartmentId = userDto.DepartmentId;
            newUser.Mail = userDto.Mail;
            newUser.NurseSpecialization = userDto.NurseSpecialization;
            newUser.NurseDegree = userDto.NurseDegree;
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
            newUserDto.Image = user.Image;
            newUserDto.Mail = user.Mail;
            newUserDto.DepartmentId = user.DepartmentId;
            newUserDto.DepartmentName = user.Department.Department_Name;
            newUserDto.NurseDegree = user.NurseDegree;
            newUserDto.NurseSpecialization = user.NurseSpecialization;
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
            newUser.Image = userDto.Image;
            newUser.DepartmentId = userDto.DepartmentId;
            newUser.Mail = userDto.Mail;
            newUser.NurseDegree = userDto.NurseDegree;
            newUser.NurseSpecialization = userDto.NurseSpecialization;
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
            newUser.Image = userDto.Image;
            newUser.DepartmentId = userDto.DepartmentId;
            newUser.Mail = userDto.Mail;
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
            newUserDto.Image = user.Image;
            newUserDto.Mail = user.Mail;
            newUserDto.DepartmentId = user.DepartmentId;
            newUserDto.BloodType = user.BloodType;
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
            newUser.Image = userDto.Image;
            newUser.DepartmentId = userDto.DepartmentId;
            newUser.Mail = userDto.Mail;
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
            newUser.Image = userDto.Image;
            newUser.DepartmentId = userDto.DepartmentId;
            newUser.Mail = userDto.Mail;
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
            newUserDto.Image = user.Image;
            newUserDto.Mail = user.Mail;
            newUserDto.DepartmentId = user.DepartmentId;
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
            newUser.Image = userDto.Image;
            newUser.DepartmentId = userDto.DepartmentId;
            newUser.Mail = userDto.Mail;
            return newUser;
        }

    }
}
