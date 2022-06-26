using Domain.Models;
using Domain.Models.Labs;
using Domain.Models.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Domain.SeedData
{
    public static class ModelBuilderExtensions
    {
        public static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
        public static void Seed(this ModelBuilder modelBuilder)
        {
            #region departments seed
            modelBuilder.Entity<Department>().HasData(
                new Department { Id = 1, Department_Name = "paediatrics", Location = "first floor", IsActive = true },
                new Department { Id = 2, Department_Name = "gynaecology", Location = "first floor", IsActive = true },
                new Department { Id = 3, Department_Name = "eye", Location = "second floor", IsActive = false },
                new Department { Id = 4, Department_Name = "orthopaedics", Location = "third floor", IsActive = true },
                new Department { Id = 5, Department_Name = "neurology", Location = "second floor", IsActive = true },
                new Department { Id = 6, Department_Name = "cardiology", Location = "fourth floor", IsActive = true },
                new Department { Id = 7, Department_Name = "dental", Location = "fourth floor", IsActive = false },
                new Department { Id = 8, Department_Name = "ENT", Location = "third floor", IsActive = true },
                new Department { Id = 9, Department_Name = "Labs", Location = "third floor", IsActive = true },
                new Department { Id = 10, Department_Name = "Scan", Location = "third floor", IsActive = true }

                );
            #endregion

            #region doctors seed
            CreatePasswordHash("Sayed", out byte[] firstHash, out byte[] firstSalt);
            CreatePasswordHash("Mohamed", out byte[] secondHash, out byte[] secondSalt);
            CreatePasswordHash("Amr", out byte[] thirdHash, out byte[] thirdSalt);

            modelBuilder.Entity<Doctor>().HasData(
                new Doctor
                {
                    Id=1,
                    FirstName = "Sayed",
                    LastName= "Taha",
                    Gender = "Male"
                ,
                    Address = "fayoum",
                    Age = 40,
                    CreatedDtm = DateTime.Now,
                    DepartmentId = 1
                ,
                    Mail = "sayed.taha@gmail.com",
                    PhoneNumber = "01113436425",
                    UserName = "sayed_taha"
                ,
                    NationalId = "27030351876321",
                    BloodType = "B+",
                    DocDegree = "PHD",
                    DocSpecialization="AI"
                ,
                    Role = "Doctor",
                    PasswordHash = firstHash,
                    PasswordSalt = firstSalt,
                    IsActive = true
                },

                new Doctor
                {
                    Id=2,
                    FirstName = "Mohamed",
                    LastName= "Hamdy",
                    Gender = "Male"
                ,
                    Address = "fayoum",
                    Age = 37,
                    CreatedDtm = DateTime.Now,
                    DepartmentId = 1
                ,
                    Mail = "mohamed.hamdy@gmail.com",
                    PhoneNumber = "01113436425",
                    UserName = "mohamed_hamdy"
                ,
                    NationalId = "27030351876321",
                    BloodType = "A+",
                    DocDegree = "PHD",
                    DocSpecialization="AI"
                ,
                    Role = "Doctor",
                    PasswordHash = secondHash,
                    PasswordSalt = secondSalt,
                    IsActive = true
                },

                new Doctor
                {
                    Id=3,
                    FirstName = "Amr",
                    LastName= "Refaat",
                    Gender = "Male"
                ,
                    Address = "fayoum",
                    Age = 50,
                    CreatedDtm = DateTime.Now,
                    DepartmentId = 2
                ,
                    Mail = "amr.refaat@gmail.com",
                    PhoneNumber = "01113436425",
                    UserName = "amr_refaat"
                ,
                    NationalId = "27030351876321",
                    BloodType = "AB+",
                    DocDegree = "PHD",
                    DocSpecialization="AI"
                ,
                    Role = "Doctor",
                    PasswordHash = thirdHash,
                    PasswordSalt = thirdSalt,
                    IsActive = true
                }
                );
            #endregion

            #region patients seed
            CreatePasswordHash("patient1", out byte[] firstPatientHash, out byte[] firstPatientSalt);
            CreatePasswordHash("patient2", out byte[] secondPatientHash, out byte[] secondPatientSalt);
            CreatePasswordHash("patient3", out byte[] thirdPatientHash, out byte[] thirdPatientSalt);
            modelBuilder.Entity<Patient>().HasData(
                new Patient
                {
                    Id=4,
                    FirstName = "Sayed",
                    LastName= "Taha",
                    Gender = "Male"
                ,
                    Address = "fayoum",
                    Age = 40,
                    CreatedDtm = DateTime.Now,
                    DepartmentId = 1
                ,
                    Mail = "sayed.taha@gmail.com",
                    PhoneNumber = "01113436425",
                    UserName = "patient1"
                ,
                    NationalId = "27030351876321",
                    BloodType = "B+"
                ,
                    Role = "Patient",
                    PasswordHash = firstPatientHash,
                    PasswordSalt = firstPatientSalt,
                    IsActive = true
                },

                new Patient
                {
                    Id=5,
                    FirstName = "Mohamed",
                    LastName= "Hamdy",
                    Gender = "Male"
                ,
                    Address = "fayoum",
                    Age = 37,
                    CreatedDtm = DateTime.Now,
                    DepartmentId = 1
                ,
                    Mail = "mohamed.hamdy@gmail.com",
                    PhoneNumber = "01113436425",
                    UserName = "patient2"
                ,
                    NationalId = "27030351876321",
                    BloodType = "O+"
                ,
                    Role = "Patient",
                    PasswordHash = secondPatientHash,
                    PasswordSalt = secondPatientSalt,
                    IsActive = true
                },

                new Patient
                {
                    Id=6,
                    FirstName = "Amr",
                    LastName= "Refaat",
                    Gender = "Male"
                ,
                    Address = "fayoum",
                    Age = 50,
                    CreatedDtm = DateTime.Now
                ,
                    Mail = "amr.refaat@gmail.com",
                    PhoneNumber = "01113436425",
                    UserName = "patient3"
                ,
                    NationalId = "27030351876321",
                    BloodType = "O-"
                ,
                    Role = "Patient",
                    PasswordHash = thirdPatientHash,
                    PasswordSalt = thirdPatientSalt,
                    IsActive = true
                }
              );

            #endregion

            #region tests seed

            modelBuilder.Entity<Test>().HasData(
                new Test { Id = 1, Name = "CBC", TestCharge = 100 },
                new Test { Id = 2, Name = "ESR", TestCharge = 100 },
                new Test { Id = 3, Name = "LIVER FUNCTION TEST", TestCharge = 100 },
                new Test { Id = 4, Name = "Kidney function test", TestCharge = 100 },
                new Test { Id = 5, Name = "Cholesterol test", TestCharge = 100 },
                new Test { Id = 6, Name = "pituitary gland test", TestCharge = 100 },
                new Test { Id = 7, Name = "H.pylori test", TestCharge = 100 },
                new Test { Id = 8, Name = "thyroid gland report", TestCharge = 100 },
                new Test { Id = 9, Name = "STOOL TEST", TestCharge = 100 },
                new Test { Id = 10, Name = "urine report", TestCharge = 100 },
                new Test { Id = 11, Name = "Pcr", TestCharge = 100 },
                new Test { Id = 12, Name = "Diabetes test", TestCharge = 100 },
                new Test { Id = 13, Name = "esr", TestCharge = 100 },
                new Test { Id = 14, Name = "esr", TestCharge = 100 });

            modelBuilder.Entity<TestParameterNumerical>().HasData(
                new TestParameterNumerical { Id = 1, TestParameterName = "Heamoglobin(edta blood)", TestId = 1, Min_Range = 11.5f, Max_Range = 15.5f, Unit = "g/dl", FieldType = "text", InputPattern = "^[+-]?([0-9]+([.][0-9]*)?|[.][0-9]+)$" },
                new TestParameterNumerical { Id = 2, TestParameterName = "Haematocrit(pcv)", TestId = 1, Min_Range = 36f, Max_Range = 45f, Unit = "%", FieldType = "text", InputPattern = "^[+-]?([0-9]+([.][0-9]*)?|[.][0-9]+)$" },
                new TestParameterNumerical { Id = 3, TestParameterName = "RBCs count(EDTA Blood)", TestId = 1, Min_Range = 4f, Max_Range = 5.2f, Unit = "Millions/cmm", FieldType = "text", InputPattern = "^[+-]?([0-9]+([.][0-9]*)?|[.][0-9]+)$" },
                new TestParameterNumerical { Id = 4, TestParameterName = "mcv", TestId = 1, Min_Range = 80f, Max_Range = 100f, Unit = "Fl", FieldType = "text", InputPattern = "^[+-]?([0-9]+([.][0-9]*)?|[.][0-9]+)$" },
                new TestParameterNumerical { Id = 5, TestParameterName = "mch", TestId = 1, Min_Range = 27f, Max_Range = 33f, Unit = "Pg", FieldType = "text", InputPattern = "^[+-]?([0-9]+([.][0-9]*)?|[.][0-9]+)$" },
                new TestParameterNumerical { Id = 6, TestParameterName = "mchc", TestId = 1, Min_Range = 31f, Max_Range = 37f, Unit = "g/dl", FieldType = "text", InputPattern = "^[+-]?([0-9]+([.][0-9]*)?|[.][0-9]+)$" },
                new TestParameterNumerical { Id = 7, TestParameterName = "Rdw-cv", TestId = 1, Min_Range = 11.5f, Max_Range = 15f, Unit = "%", FieldType = "text", InputPattern = "^[+-]?([0-9]+([.][0-9]*)?|[.][0-9]+)$" },
                new TestParameterNumerical { Id = 8, TestParameterName = "Platelet count (edta blood)", TestId = 1, Min_Range = 150f, Max_Range = 450f, Unit = "Thousands/cmm", FieldType = "text", InputPattern = "^[+-]?([0-9]+([.][0-9]*)?|[.][0-9]+)$" },
                new TestParameterNumerical { Id = 9, TestParameterName = "Total leucocytic count (edta blood)", TestId = 1, Min_Range = 4f, Max_Range = 11f, Unit = "Thousands/cmm", FieldType = "text", InputPattern = "^[+-]?([0-9]+([.][0-9]*)?|[.][0-9]+)$" },
                new TestParameterNumerical { Id = 10, TestParameterName = "neutrophis", TestId = 1, Min_Range = 2f, Max_Range = 7f, Unit = "×10^9/l", FieldType = "text", InputPattern = "^[+-]?([0-9]+([.][0-9]*)?|[.][0-9]+)$" },
                new TestParameterNumerical { Id = 11, TestParameterName = "lymphocytes", TestId = 1, Min_Range = 1f, Max_Range = 4.8f, Unit = "×10^9/l", FieldType = "text", InputPattern = "^[+-]?([0-9]+([.][0-9]*)?|[.][0-9]+)$" },
                new TestParameterNumerical { Id = 12, TestParameterName = "monocytes", TestId = 1, Min_Range = 0.2f, Max_Range = 1f, Unit = "×10^9/l", FieldType = "text", InputPattern = "^[+-]?([0-9]+([.][0-9]*)?|[.][0-9]+)$" },
                new TestParameterNumerical { Id = 13, TestParameterName = "eosinophils", TestId = 1, Min_Range = 0.1f, Max_Range = 0.45f, Unit = "×10^9/l", FieldType = "text", InputPattern = "^[+-]?([0-9]+([.][0-9]*)?|[.][0-9]+)$" },
                new TestParameterNumerical { Id = 14, TestParameterName = "basophils", TestId = 1, Min_Range = 0f, Max_Range = 0.1f, Unit = "×10^9/l", FieldType = "text", InputPattern = "^[+-]?([0-9]+([.][0-9]*)?|[.][0-9]+)$" },


                new TestParameterNumerical { Id = 15, TestParameterName = "First hour male", TestId = 2, Min_Range = 3f, Max_Range = 7f, Unit = "mm", FieldType = "text", InputPattern = "^[+-]?([0-9]+([.][0-9]*)?|[.][0-9]+)$" },
                new TestParameterNumerical { Id = 16, TestParameterName = "First hour female", TestId = 2, Min_Range = 7f, Max_Range = 12f, Unit = "mm", FieldType = "text", InputPattern = "^[+-]?([0-9]+([.][0-9]*)?|[.][0-9]+)$" },
                new TestParameterNumerical { Id = 17, TestParameterName = "Second hour male", TestId = 2, Min_Range = 7f, Max_Range = 15f, Unit = "mm", FieldType = "text", InputPattern = "^[+-]?([0-9]+([.][0-9]*)?|[.][0-9]+)$" },
                new TestParameterNumerical { Id = 18, TestParameterName = "Second hour female", TestId = 2, Min_Range = 12f, Max_Range = 17f, Unit = "mm", FieldType = "text", InputPattern = "^[+-]?([0-9]+([.][0-9]*)?|[.][0-9]+)$" },



                new TestParameterNumerical { Id = 19, TestParameterName = "Bilirubin total", TestId = 3, Min_Range = 0f, Max_Range = 1f, Unit = "mg/dl", FieldType = "text", InputPattern = "^[+-]?([0-9]+([.][0-9]*)?|[.][0-9]+)$" },
                new TestParameterNumerical { Id = 20, TestParameterName = "Bilirubin direct", TestId = 3, Min_Range = 0f, Max_Range = 0.3f, Unit = "mg/dl", FieldType = "text", InputPattern = "^[+-]?([0-9]+([.][0-9]*)?|[.][0-9]+)$" },
                new TestParameterNumerical { Id = 21, TestParameterName = "Bilirubin indirect", TestId = 3, Min_Range = 0f, Max_Range = 11.7f, Unit = "mg/dl", FieldType = "text", InputPattern = "^[+-]?([0-9]+([.][0-9]*)?|[.][0-9]+)$" },
                new TestParameterNumerical { Id = 22, TestParameterName = "Sgot(ast)", TestId = 3, Min_Range = 0f, Max_Range = 0.35f, Unit = "u/i", FieldType = "text", InputPattern = "^[+-]?([0-9]+([.][0-9]*)?|[.][0-9]+)$" },
                new TestParameterNumerical { Id = 23, TestParameterName = "Sgpt(alt)", TestId = 3, Min_Range = 0f, Max_Range = 0.45f, Unit = "u/i", FieldType = "text", InputPattern = "^[+-]?([0-9]+([.][0-9]*)?|[.][0-9]+)$" },
                new TestParameterNumerical { Id = 24, TestParameterName = "Alkaline phosphatase", TestId = 3, Min_Range = 124f, Max_Range = 341f, Unit = "u/i", FieldType = "text", InputPattern = "^[+-]?([0-9]+([.][0-9]*)?|[.][0-9]+)$" },
                new TestParameterNumerical { Id = 25, TestParameterName = "Total proten", TestId = 3, Min_Range = 6.6f, Max_Range = 8.3f, Unit = "mg/dl", FieldType = "text", InputPattern = "^[+-]?([0-9]+([.][0-9]*)?|[.][0-9]+)$" },
                new TestParameterNumerical { Id = 26, TestParameterName = "Albumin", TestId = 3, Min_Range = 3.5f, Max_Range = 4.9f, Unit = "g/dl", FieldType = "text", InputPattern = "^[+-]?([0-9]+([.][0-9]*)?|[.][0-9]+)$" },
                new TestParameterNumerical { Id = 27, TestParameterName = "Globulin", TestId = 3, Min_Range = 2.3f, Max_Range = 3.5f, Unit = "g/dl", FieldType = "text", InputPattern = "^[+-]?([0-9]+([.][0-9]*)?|[.][0-9]+)$" },
                new TestParameterNumerical { Id = 28, TestParameterName = "a/g ration", TestId = 3, Min_Range = 1.25f, Max_Range = 1.56f, Unit = "g/dl", FieldType = "text", InputPattern = "^[+-]?([0-9]+([.][0-9]*)?|[.][0-9]+)$" },


                new TestParameterNumerical { Id = 29, TestParameterName = "Blood urea nitrogen(BUN)", TestId = 4, Min_Range = 5f, Max_Range = 25f, Unit = "mg/dl", FieldType = "text", InputPattern = "^[+-]?([0-9]+([.][0-9]*)?|[.][0-9]+)$" },
                new TestParameterNumerical { Id = 30, TestParameterName = "Creatinine(CRE)", TestId = 4, Min_Range = 0.3f, Max_Range = 1.4f, Unit = "mg/dl", FieldType = "text", InputPattern = "^[+-]?([0-9]+([.][0-9]*)?|[.][0-9]+)$" },
                new TestParameterNumerical { Id = 31, TestParameterName = "Uric acid(UA)", TestId = 4, Min_Range = 2.5f, Max_Range = 7f, Unit = "mg/dl", FieldType = "text", InputPattern = "^[+-]?([0-9]+([.][0-9]*)?|[.][0-9]+)$" },
                new TestParameterNumerical { Id = 32, TestParameterName = "Albumin-globilin in ratio(A/G ratio)", TestId = 4, Min_Range = 1f, Max_Range = 1.8f, Unit = "mg/dl", FieldType = "text", InputPattern = "^[+-]?([0-9]+([.][0-9]*)?|[.][0-9]+)$" },
                new TestParameterNumerical { Id = 33, TestParameterName = "creatinine Clearance/24 hrs urine (CC) Male", TestId = 4, Min_Range = 71f, Max_Range = 135f, Unit = "ml/min", FieldType = "text", InputPattern = "^[+-]?([0-9]+([.][0-9]*)?|[.][0-9]+)$" },
                new TestParameterNumerical { Id = 34, TestParameterName = "creatinine Clearance/24 hrs urine (CC) Female", TestId = 4, Min_Range = 78f, Max_Range = 116f, Unit = "ml/min", FieldType = "text", InputPattern = "^[+-]?([0-9]+([.][0-9]*)?|[.][0-9]+)$" },
                new TestParameterNumerical { Id = 35, TestParameterName = "Renin", TestId = 4, Min_Range = 0.15f, Max_Range = 3.95f, Unit = "pg/ml/hr", FieldType = "text", InputPattern = "^[+-]?([0-9]+([.][0-9]*)?|[.][0-9]+)$" },
                new TestParameterNumerical { Id = 36, TestParameterName = "Creatinine urine", TestId = 4, Min_Range = 60f, Max_Range = 250f, Unit = "mg/dl", FieldType = "text", InputPattern = "^[+-]?([0-9]+([.][0-9]*)?|[.][0-9]+)$" },
                new TestParameterNumerical { Id = 37, TestParameterName = "Natrium(Na)", TestId = 4, Min_Range = 135f, Max_Range = 145f, Unit = "meq/l", FieldType = "text", InputPattern = "^[+-]?([0-9]+([.][0-9]*)?|[.][0-9]+)$" },
                new TestParameterNumerical { Id = 38, TestParameterName = "Potassium (K)", TestId = 4, Min_Range = 3.4f, Max_Range = 4.5f, Unit = "meq/l", FieldType = "text", InputPattern = "^[+-]?([0-9]+([.][0-9]*)?|[.][0-9]+)$" },
                new TestParameterNumerical { Id = 39, TestParameterName = "Calcium (Ca)", TestId = 4, Min_Range = 8.4f, Max_Range = 10.6f, Unit = "mg/dl", FieldType = "text", InputPattern = "^[+-]?([0-9]+([.][0-9]*)?|[.][0-9]+)$" },
                new TestParameterNumerical { Id = 40, TestParameterName = "Phosphorus (IP)", TestId = 4, Min_Range = 2.1f, Max_Range = 4.7f, Unit = "mg/dl", FieldType = "text", InputPattern = "^[+-]?([0-9]+([.][0-9]*)?|[.][0-9]+)$" },
                new TestParameterNumerical { Id = 41, TestParameterName = "Alkaline phosphatase (ALP)", TestId = 4, Min_Range = 27f, Max_Range = 110f, Unit = "U/L", FieldType = "text", InputPattern = "^[+-]?([0-9]+([.][0-9]*)?|[.][0-9]+)$" });
            //new TestParameterNumerical { Id = 42, TestParameterName = "", TestId = 4, Min_Range = f, Max_Range = f, Unit = "", FieldType = "text", InputPattern = "^[+-]?([0-9]+([.][0-9]*)?|[.][0-9]+)$" },
            //new TestParameterNumerical { Id = 43, TestParameterName = "", TestId = 4, Min_Range = f, Max_Range = f, Unit = "", FieldType = "text", InputPattern = "^[+-]?([0-9]+([.][0-9]*)?|[.][0-9]+)$" },
            //new TestParameterNumerical { Id = 44, TestParameterName = "", TestId = 4, Min_Range = f, Max_Range = f, Unit = "", FieldType = "text", InputPattern = "^[+-]?([0-9]+([.][0-9]*)?|[.][0-9]+)$" },
            //new TestParameterNumerical { Id = 45, TestParameterName = "", TestId = 4, Min_Range = f, Max_Range = f, Unit = "", FieldType = "text", InputPattern = "^[+-]?([0-9]+([.][0-9]*)?|[.][0-9]+)$" },



            #endregion

            #region scans seed
            modelBuilder.Entity<Scan>().HasData(
                new Scan { Id = 1, ScanCharge = 100, ScanName = "Angiography" },
                new Scan { Id = 2, ScanCharge = 100, ScanName = "CT" },
                new Scan { Id = 3, ScanCharge = 100, ScanName = "Echocardiogram" },
                new Scan { Id = 4, ScanCharge = 100, ScanName = "Electrocardiogram (ECG)" },
                new Scan { Id = 5, ScanCharge = 100, ScanName = "MRI scan" },
                new Scan { Id = 6, ScanCharge = 100, ScanName = "PET scan" },
                new Scan { Id = 7, ScanCharge = 100, ScanName = "Ultrasound scan" },
                new Scan { Id = 8, ScanCharge = 100, ScanName = "X-ray" });
            #endregion

            #region rooms seed
            modelBuilder.Entity<Room>().HasData(
                new Room { Id = 1, RoomNumber = 1, FloorNumber = 1, NumberOfBeds = 4, RoomCharges = 120, RoomType = "common", DepartmentId = 1, Reserved = false },
                new Room { Id = 2, RoomNumber = 2, FloorNumber = 1, NumberOfBeds = 2, RoomCharges = 140, RoomType = "common", DepartmentId = 1, Reserved = false },
                new Room { Id = 3, RoomNumber = 3, FloorNumber = 1, NumberOfBeds = 1, RoomCharges = 200, RoomType = "suite", DepartmentId = 1, Reserved = false },
                new Room { Id = 4, RoomNumber = 4, FloorNumber = 2, NumberOfBeds = 4, RoomCharges = 120, RoomType = "common", DepartmentId = 1, Reserved = false },
                new Room { Id = 5, RoomNumber = 5, FloorNumber = 2, NumberOfBeds = 4, RoomCharges = 120, RoomType = "common", DepartmentId = 2, Reserved = false },
                new Room { Id = 6, RoomNumber = 6, FloorNumber = 2, NumberOfBeds = 4, RoomCharges = 120, RoomType = "common", DepartmentId = 2, Reserved = false },
                new Room { Id = 7, RoomNumber = 7, FloorNumber = 3, NumberOfBeds = 1, RoomCharges = 200, RoomType = "suite", DepartmentId = 2, Reserved = false },
                new Room { Id = 8, RoomNumber = 8, FloorNumber = 3, NumberOfBeds = 2, RoomCharges = 140, RoomType = "common", DepartmentId = 1, Reserved = false });

            modelBuilder.Entity<Bed>().HasData(
                new Bed { Id =1, Number = 1, RoomId = 1, Reserved = false },
                new Bed { Id =2, Number = 2, RoomId = 1, Reserved = false },
                new Bed { Id =3, Number = 3, RoomId = 1, Reserved = false },
                new Bed { Id =4, Number = 4, RoomId = 1, Reserved = false },

                new Bed { Id =5, Number = 1, RoomId = 2, Reserved = false },
                new Bed { Id =6, Number = 2, RoomId = 2, Reserved = false },

                new Bed { Id =7, Number = 1, RoomId = 3, Reserved = false },

                new Bed { Id =8, Number = 1, RoomId = 4, Reserved = false },
                new Bed { Id =9, Number = 2, RoomId = 4, Reserved = false },
                new Bed { Id =10, Number = 3, RoomId = 4, Reserved = false },
                new Bed { Id =11, Number = 4, RoomId = 4, Reserved = false },

                new Bed { Id =12, Number = 1, RoomId = 5, Reserved = false },
                new Bed { Id =13, Number = 2, RoomId = 5, Reserved = false },
                new Bed { Id =14, Number = 3, RoomId = 5, Reserved = false },
                new Bed { Id =15, Number = 4, RoomId = 5, Reserved = false },

                new Bed { Id =16, Number = 1, RoomId = 6, Reserved = false },
                new Bed { Id =17, Number = 2, RoomId = 6, Reserved = false },
                new Bed { Id =18, Number = 3, RoomId = 6, Reserved = false },
                new Bed { Id =19, Number = 4, RoomId = 6, Reserved = false },

                new Bed { Id =20, Number = 1, RoomId = 7, Reserved = false },

                new Bed { Id =21, Number = 1, RoomId = 8, Reserved = false },
                new Bed { Id =22, Number = 2, RoomId = 8, Reserved = false });



            #endregion

        }
    }
}