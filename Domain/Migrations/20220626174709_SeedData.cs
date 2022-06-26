using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Domain.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TestParameters_Tests_TestParameterNumerical_TestId",
                table: "TestParameters");

            migrationBuilder.DropIndex(
                name: "IX_TestParameters_TestParameterNumerical_TestId",
                table: "TestParameters");

            migrationBuilder.DropColumn(
                name: "TestParameterNumerical_TestId",
                table: "TestParameters");

            migrationBuilder.AlterColumn<string>(
                name: "Unit",
                table: "TestParameters",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "TestId",
                table: "TestParameters",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Department",
                columns: new[] { "Id", "Department_Name", "IsActive", "Location" },
                values: new object[,]
                {
                    { 1, "paediatrics", true, "first floor" },
                    { 2, "gynaecology", true, "first floor" },
                    { 3, "eye", false, "second floor" },
                    { 4, "orthopaedics", true, "third floor" },
                    { 5, "neurology", true, "second floor" },
                    { 6, "cardiology", true, "fourth floor" },
                    { 7, "dental", false, "fourth floor" },
                    { 8, "ENT", true, "third floor" },
                    { 9, "Labs", true, "third floor" },
                    { 10, "Scan", true, "third floor" }
                });

            migrationBuilder.InsertData(
                table: "Scan",
                columns: new[] { "Id", "ScanCharge", "ScanName" },
                values: new object[,]
                {
                    { 1, 100f, "Angiography" },
                    { 2, 100f, "CT" },
                    { 3, 100f, "Echocardiogram" },
                    { 4, 100f, "Electrocardiogram (ECG)" },
                    { 5, 100f, "MRI scan" },
                    { 6, 100f, "PET scan" },
                    { 7, 100f, "Ultrasound scan" },
                    { 8, 100f, "X-ray" }
                });

            migrationBuilder.InsertData(
                table: "Tests",
                columns: new[] { "Id", "Name", "TestCharge" },
                values: new object[,]
                {
                    { 1, "CBC", 100f },
                    { 2, "ESR", 100f },
                    { 3, "LIVER FUNCTION TEST", 100f },
                    { 4, "Kidney function test", 100f },
                    { 5, "Cholesterol test", 100f },
                    { 6, "pituitary gland test", 100f },
                    { 7, "H.pylori test", 100f },
                    { 8, "thyroid gland report", 100f },
                    { 9, "STOOL TEST", 100f },
                    { 10, "urine report", 100f },
                    { 11, "Pcr", 100f },
                    { 12, "Diabetes test", 100f },
                    { 13, "esr", 100f },
                    { 14, "esr", 100f }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "Age", "BloodType", "CreatedDtm", "DepartmentId", "FirstName", "Gender", "Image", "IsActive", "LastName", "Mail", "NationalId", "PasswordHash", "PasswordSalt", "PhoneNumber", "Role", "UserName" },
                values: new object[] { 6, "fayoum", 50, "O-", new DateTime(2022, 6, 26, 19, 47, 7, 884, DateTimeKind.Local).AddTicks(3605), null, "Amr", "Male", null, true, "Refaat", "amr.refaat@gmail.com", "27030351876321", new byte[] { 59, 143, 79, 202, 153, 67, 57, 74, 1, 57, 192, 204, 222, 64, 198, 87, 144, 86, 211, 45, 121, 247, 227, 182, 19, 131, 252, 45, 92, 9, 161, 42, 102, 214, 44, 39, 104, 179, 109, 223, 163, 26, 116, 110, 12, 105, 90, 75, 186, 187, 119, 190, 73, 141, 215, 194, 14, 186, 205, 168, 84, 106, 7, 162 }, new byte[] { 66, 122, 122, 70, 236, 73, 193, 66, 158, 73, 206, 24, 146, 69, 8, 201, 112, 213, 196, 161, 240, 17, 118, 192, 67, 177, 224, 150, 1, 100, 199, 246, 246, 95, 20, 236, 106, 40, 165, 85, 195, 27, 236, 93, 141, 66, 48, 107, 91, 233, 121, 136, 67, 202, 62, 195, 174, 188, 6, 97, 202, 62, 168, 95, 50, 7, 80, 184, 220, 45, 215, 29, 65, 141, 21, 103, 38, 240, 236, 131, 29, 82, 227, 40, 38, 242, 251, 169, 182, 152, 41, 231, 166, 34, 75, 153, 61, 200, 137, 3, 182, 213, 112, 223, 221, 10, 178, 197, 200, 3, 77, 176, 58, 32, 51, 204, 179, 181, 192, 228, 9, 32, 184, 23, 203, 151, 22, 159 }, "01113436425", "Patient", "patient3" });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "DepartmentId", "FloorNumber", "NumberOfBeds", "Reserved", "RoomCharges", "RoomNumber", "RoomType" },
                values: new object[,]
                {
                    { 1, 1, 1, 4, false, 120, 1, "common" },
                    { 2, 1, 1, 2, false, 140, 2, "common" },
                    { 3, 1, 1, 1, false, 200, 3, "suite" },
                    { 4, 1, 2, 4, false, 120, 4, "common" },
                    { 5, 2, 2, 4, false, 120, 5, "common" },
                    { 6, 2, 2, 4, false, 120, 6, "common" },
                    { 7, 2, 3, 1, false, 200, 7, "suite" },
                    { 8, 1, 3, 2, false, 140, 8, "common" }
                });

            migrationBuilder.InsertData(
                table: "TestParameters",
                columns: new[] { "Id", "FieldType", "InputPattern", "Max_Range", "Min_Range", "TestId", "TestParameterName", "Type", "Unit" },
                values: new object[,]
                {
                    { 1, "text", "^[+-]?([0-9]+([.][0-9]*)?|[.][0-9]+)$", 15.5f, 11.5f, 1, "Heamoglobin(edta blood)", "Numerical", "g/dl" },
                    { 2, "text", "^[+-]?([0-9]+([.][0-9]*)?|[.][0-9]+)$", 45f, 36f, 1, "Haematocrit(pcv)", "Numerical", "%" },
                    { 3, "text", "^[+-]?([0-9]+([.][0-9]*)?|[.][0-9]+)$", 5.2f, 4f, 1, "RBCs count(EDTA Blood)", "Numerical", "Millions/cmm" },
                    { 4, "text", "^[+-]?([0-9]+([.][0-9]*)?|[.][0-9]+)$", 100f, 80f, 1, "mcv", "Numerical", "Fl" },
                    { 5, "text", "^[+-]?([0-9]+([.][0-9]*)?|[.][0-9]+)$", 33f, 27f, 1, "mch", "Numerical", "Pg" },
                    { 6, "text", "^[+-]?([0-9]+([.][0-9]*)?|[.][0-9]+)$", 37f, 31f, 1, "mchc", "Numerical", "g/dl" },
                    { 7, "text", "^[+-]?([0-9]+([.][0-9]*)?|[.][0-9]+)$", 15f, 11.5f, 1, "Rdw-cv", "Numerical", "%" },
                    { 8, "text", "^[+-]?([0-9]+([.][0-9]*)?|[.][0-9]+)$", 450f, 150f, 1, "Platelet count (edta blood)", "Numerical", "Thousands/cmm" },
                    { 9, "text", "^[+-]?([0-9]+([.][0-9]*)?|[.][0-9]+)$", 11f, 4f, 1, "Total leucocytic count (edta blood)", "Numerical", "Thousands/cmm" },
                    { 10, "text", "^[+-]?([0-9]+([.][0-9]*)?|[.][0-9]+)$", 7f, 2f, 1, "neutrophis", "Numerical", "×10^9/l" },
                    { 11, "text", "^[+-]?([0-9]+([.][0-9]*)?|[.][0-9]+)$", 4.8f, 1f, 1, "lymphocytes", "Numerical", "×10^9/l" },
                    { 12, "text", "^[+-]?([0-9]+([.][0-9]*)?|[.][0-9]+)$", 1f, 0.2f, 1, "monocytes", "Numerical", "×10^9/l" },
                    { 13, "text", "^[+-]?([0-9]+([.][0-9]*)?|[.][0-9]+)$", 0.45f, 0.1f, 1, "eosinophils", "Numerical", "×10^9/l" },
                    { 14, "text", "^[+-]?([0-9]+([.][0-9]*)?|[.][0-9]+)$", 0.1f, 0f, 1, "basophils", "Numerical", "×10^9/l" },
                    { 15, "text", "^[+-]?([0-9]+([.][0-9]*)?|[.][0-9]+)$", 7f, 3f, 2, "First hour male", "Numerical", "mm" },
                    { 16, "text", "^[+-]?([0-9]+([.][0-9]*)?|[.][0-9]+)$", 12f, 7f, 2, "First hour female", "Numerical", "mm" },
                    { 17, "text", "^[+-]?([0-9]+([.][0-9]*)?|[.][0-9]+)$", 15f, 7f, 2, "Second hour male", "Numerical", "mm" },
                    { 18, "text", "^[+-]?([0-9]+([.][0-9]*)?|[.][0-9]+)$", 17f, 12f, 2, "Second hour female", "Numerical", "mm" },
                    { 19, "text", "^[+-]?([0-9]+([.][0-9]*)?|[.][0-9]+)$", 1f, 0f, 3, "Bilirubin total", "Numerical", "mg/dl" },
                    { 20, "text", "^[+-]?([0-9]+([.][0-9]*)?|[.][0-9]+)$", 0.3f, 0f, 3, "Bilirubin direct", "Numerical", "mg/dl" },
                    { 21, "text", "^[+-]?([0-9]+([.][0-9]*)?|[.][0-9]+)$", 11.7f, 0f, 3, "Bilirubin indirect", "Numerical", "mg/dl" },
                    { 22, "text", "^[+-]?([0-9]+([.][0-9]*)?|[.][0-9]+)$", 0.35f, 0f, 3, "Sgot(ast)", "Numerical", "u/i" },
                    { 23, "text", "^[+-]?([0-9]+([.][0-9]*)?|[.][0-9]+)$", 0.45f, 0f, 3, "Sgpt(alt)", "Numerical", "u/i" },
                    { 24, "text", "^[+-]?([0-9]+([.][0-9]*)?|[.][0-9]+)$", 341f, 124f, 3, "Alkaline phosphatase", "Numerical", "u/i" },
                    { 25, "text", "^[+-]?([0-9]+([.][0-9]*)?|[.][0-9]+)$", 8.3f, 6.6f, 3, "Total proten", "Numerical", "mg/dl" },
                    { 26, "text", "^[+-]?([0-9]+([.][0-9]*)?|[.][0-9]+)$", 4.9f, 3.5f, 3, "Albumin", "Numerical", "g/dl" },
                    { 27, "text", "^[+-]?([0-9]+([.][0-9]*)?|[.][0-9]+)$", 3.5f, 2.3f, 3, "Globulin", "Numerical", "g/dl" },
                    { 28, "text", "^[+-]?([0-9]+([.][0-9]*)?|[.][0-9]+)$", 1.56f, 1.25f, 3, "a/g ration", "Numerical", "g/dl" },
                    { 29, "text", "^[+-]?([0-9]+([.][0-9]*)?|[.][0-9]+)$", 25f, 5f, 4, "Blood urea nitrogen(BUN)", "Numerical", "mg/dl" },
                    { 30, "text", "^[+-]?([0-9]+([.][0-9]*)?|[.][0-9]+)$", 1.4f, 0.3f, 4, "Creatinine(CRE)", "Numerical", "mg/dl" },
                    { 31, "text", "^[+-]?([0-9]+([.][0-9]*)?|[.][0-9]+)$", 7f, 2.5f, 4, "Uric acid(UA)", "Numerical", "mg/dl" },
                    { 32, "text", "^[+-]?([0-9]+([.][0-9]*)?|[.][0-9]+)$", 1.8f, 1f, 4, "Albumin-globilin in ratio(A/G ratio)", "Numerical", "mg/dl" },
                    { 33, "text", "^[+-]?([0-9]+([.][0-9]*)?|[.][0-9]+)$", 135f, 71f, 4, "creatinine Clearance/24 hrs urine (CC) Male", "Numerical", "ml/min" },
                    { 34, "text", "^[+-]?([0-9]+([.][0-9]*)?|[.][0-9]+)$", 116f, 78f, 4, "creatinine Clearance/24 hrs urine (CC) Female", "Numerical", "ml/min" }
                });

            migrationBuilder.InsertData(
                table: "TestParameters",
                columns: new[] { "Id", "FieldType", "InputPattern", "Max_Range", "Min_Range", "TestId", "TestParameterName", "Type", "Unit" },
                values: new object[,]
                {
                    { 35, "text", "^[+-]?([0-9]+([.][0-9]*)?|[.][0-9]+)$", 3.95f, 0.15f, 4, "Renin", "Numerical", "pg/ml/hr" },
                    { 36, "text", "^[+-]?([0-9]+([.][0-9]*)?|[.][0-9]+)$", 250f, 60f, 4, "Creatinine urine", "Numerical", "mg/dl" },
                    { 37, "text", "^[+-]?([0-9]+([.][0-9]*)?|[.][0-9]+)$", 145f, 135f, 4, "Natrium(Na)", "Numerical", "meq/l" },
                    { 38, "text", "^[+-]?([0-9]+([.][0-9]*)?|[.][0-9]+)$", 4.5f, 3.4f, 4, "Potassium (K)", "Numerical", "meq/l" },
                    { 39, "text", "^[+-]?([0-9]+([.][0-9]*)?|[.][0-9]+)$", 10.6f, 8.4f, 4, "Calcium (Ca)", "Numerical", "mg/dl" },
                    { 40, "text", "^[+-]?([0-9]+([.][0-9]*)?|[.][0-9]+)$", 4.7f, 2.1f, 4, "Phosphorus (IP)", "Numerical", "mg/dl" },
                    { 41, "text", "^[+-]?([0-9]+([.][0-9]*)?|[.][0-9]+)$", 110f, 27f, 4, "Alkaline phosphatase (ALP)", "Numerical", "U/L" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "Age", "BloodType", "CreatedDtm", "DepartmentId", "DocDegree", "DocSpecialization", "FirstName", "Gender", "Image", "Doctor_IndoorPatientRecordId", "IsActive", "LastName", "Mail", "NationalId", "PasswordHash", "PasswordSalt", "PhoneNumber", "Role", "UserName" },
                values: new object[,]
                {
                    { 1, "fayoum", 40, "B+", new DateTime(2022, 6, 26, 19, 47, 7, 884, DateTimeKind.Local).AddTicks(3117), 1, "PHD", "AI", "Sayed", "Male", null, null, true, "Taha", "sayed.taha@gmail.com", "27030351876321", new byte[] { 85, 140, 4, 100, 69, 239, 254, 61, 242, 71, 88, 69, 115, 86, 29, 241, 133, 58, 158, 46, 121, 131, 2, 72, 255, 230, 228, 196, 211, 12, 108, 169, 12, 90, 171, 159, 98, 74, 222, 197, 86, 172, 2, 62, 242, 215, 201, 77, 27, 161, 168, 19, 232, 55, 255, 233, 126, 166, 165, 67, 242, 111, 195, 9 }, new byte[] { 212, 75, 230, 22, 197, 180, 30, 167, 217, 183, 68, 83, 17, 253, 90, 202, 106, 187, 31, 234, 41, 103, 87, 23, 231, 200, 84, 4, 145, 120, 205, 91, 109, 37, 185, 98, 237, 182, 62, 133, 182, 23, 189, 73, 36, 31, 187, 165, 214, 66, 119, 108, 245, 50, 52, 79, 94, 247, 235, 82, 161, 190, 6, 83, 185, 121, 104, 127, 248, 230, 0, 110, 37, 254, 11, 131, 203, 113, 11, 117, 65, 244, 26, 122, 9, 28, 203, 59, 49, 69, 239, 156, 31, 105, 83, 86, 18, 195, 133, 101, 173, 73, 231, 184, 165, 58, 90, 173, 243, 128, 70, 60, 196, 157, 149, 119, 152, 180, 254, 173, 97, 47, 124, 126, 221, 56, 34, 220 }, "01113436425", "Doctor", "sayed_taha" },
                    { 2, "fayoum", 37, "A+", new DateTime(2022, 6, 26, 19, 47, 7, 884, DateTimeKind.Local).AddTicks(3142), 1, "PHD", "AI", "Mohamed", "Male", null, null, true, "Hamdy", "mohamed.hamdy@gmail.com", "27030351876321", new byte[] { 213, 140, 167, 207, 165, 213, 55, 183, 86, 196, 97, 218, 171, 218, 88, 255, 166, 197, 172, 154, 113, 217, 218, 31, 238, 191, 219, 100, 130, 66, 194, 79, 65, 98, 87, 97, 88, 220, 28, 10, 69, 163, 80, 241, 214, 79, 99, 80, 42, 35, 195, 82, 47, 128, 51, 171, 11, 58, 150, 105, 76, 19, 149, 123 }, new byte[] { 10, 92, 189, 146, 195, 173, 207, 35, 109, 255, 194, 175, 245, 177, 125, 246, 206, 84, 224, 146, 246, 43, 186, 241, 144, 150, 84, 36, 230, 236, 43, 98, 153, 97, 249, 235, 99, 219, 120, 196, 108, 17, 94, 112, 23, 29, 244, 16, 180, 86, 228, 53, 67, 144, 78, 81, 96, 125, 9, 68, 12, 190, 147, 137, 130, 241, 188, 17, 205, 50, 114, 228, 14, 97, 252, 239, 144, 53, 45, 237, 182, 19, 179, 219, 160, 153, 207, 64, 164, 197, 115, 61, 184, 167, 143, 136, 87, 245, 202, 192, 201, 136, 255, 180, 13, 103, 79, 104, 251, 241, 188, 238, 151, 143, 7, 0, 225, 138, 240, 232, 18, 132, 148, 199, 169, 166, 237, 162 }, "01113436425", "Doctor", "mohamed_hamdy" },
                    { 3, "fayoum", 50, "AB+", new DateTime(2022, 6, 26, 19, 47, 7, 884, DateTimeKind.Local).AddTicks(3148), 2, "PHD", "AI", "Amr", "Male", null, null, true, "Refaat", "amr.refaat@gmail.com", "27030351876321", new byte[] { 27, 112, 227, 67, 72, 79, 54, 97, 112, 9, 66, 189, 202, 210, 223, 184, 33, 77, 64, 107, 113, 233, 249, 70, 88, 55, 167, 141, 197, 9, 76, 200, 174, 16, 167, 167, 166, 16, 221, 145, 219, 237, 17, 85, 254, 2, 245, 62, 95, 156, 253, 88, 83, 201, 132, 173, 255, 49, 113, 249, 195, 136, 213, 16 }, new byte[] { 20, 248, 176, 231, 131, 73, 115, 27, 91, 0, 81, 93, 123, 169, 228, 214, 232, 123, 65, 51, 12, 136, 70, 75, 176, 187, 122, 17, 248, 50, 19, 235, 163, 153, 39, 223, 63, 142, 97, 101, 159, 164, 244, 118, 62, 139, 80, 146, 1, 202, 183, 246, 9, 184, 247, 252, 34, 83, 106, 26, 9, 161, 189, 204, 145, 136, 88, 30, 133, 61, 84, 138, 75, 233, 248, 106, 130, 73, 55, 107, 160, 83, 85, 116, 162, 114, 102, 88, 113, 16, 221, 63, 102, 9, 207, 12, 238, 29, 205, 134, 17, 26, 213, 188, 223, 166, 250, 51, 98, 205, 81, 181, 214, 184, 110, 95, 235, 220, 198, 237, 46, 126, 34, 223, 205, 194, 219, 152 }, "01113436425", "Doctor", "amr_refaat" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "Age", "BloodType", "CreatedDtm", "DepartmentId", "FirstName", "Gender", "Image", "IsActive", "LastName", "Mail", "NationalId", "PasswordHash", "PasswordSalt", "PhoneNumber", "Role", "UserName" },
                values: new object[,]
                {
                    { 4, "fayoum", 40, "B+", new DateTime(2022, 6, 26, 19, 47, 7, 884, DateTimeKind.Local).AddTicks(3592), 1, "Sayed", "Male", null, true, "Taha", "sayed.taha@gmail.com", "27030351876321", new byte[] { 170, 132, 253, 150, 179, 67, 85, 232, 24, 11, 147, 113, 204, 138, 50, 176, 103, 29, 217, 35, 122, 147, 254, 84, 184, 66, 241, 25, 47, 233, 176, 182, 0, 141, 150, 212, 27, 227, 167, 14, 129, 186, 129, 201, 197, 109, 142, 136, 141, 243, 30, 58, 143, 137, 39, 16, 7, 52, 43, 219, 65, 19, 116, 99 }, new byte[] { 133, 5, 21, 180, 195, 118, 133, 199, 158, 110, 143, 133, 87, 234, 116, 191, 19, 205, 57, 177, 126, 230, 45, 87, 18, 150, 161, 43, 159, 14, 67, 7, 88, 23, 133, 12, 211, 205, 42, 181, 244, 87, 56, 211, 241, 129, 203, 13, 161, 125, 40, 17, 30, 18, 239, 98, 79, 83, 41, 117, 156, 91, 19, 234, 115, 18, 145, 197, 18, 197, 188, 164, 25, 69, 49, 159, 59, 95, 12, 112, 170, 82, 119, 10, 157, 203, 187, 136, 116, 168, 216, 93, 31, 180, 225, 246, 253, 3, 232, 27, 9, 4, 105, 157, 253, 97, 107, 95, 92, 112, 22, 100, 1, 144, 89, 13, 195, 86, 173, 219, 37, 152, 24, 0, 79, 175, 12, 50 }, "01113436425", "Patient", "patient1" },
                    { 5, "fayoum", 37, "O+", new DateTime(2022, 6, 26, 19, 47, 7, 884, DateTimeKind.Local).AddTicks(3600), 1, "Mohamed", "Male", null, true, "Hamdy", "mohamed.hamdy@gmail.com", "27030351876321", new byte[] { 86, 9, 206, 247, 52, 88, 84, 64, 145, 64, 130, 11, 161, 71, 23, 20, 216, 210, 152, 79, 255, 102, 105, 198, 157, 93, 72, 0, 133, 29, 188, 214, 77, 115, 65, 66, 192, 59, 250, 39, 201, 202, 168, 191, 73, 255, 204, 87, 120, 225, 53, 194, 245, 19, 137, 159, 105, 146, 43, 8, 207, 128, 42, 103 }, new byte[] { 196, 121, 92, 113, 40, 177, 190, 172, 84, 192, 231, 139, 171, 94, 112, 82, 222, 6, 150, 232, 30, 11, 224, 41, 152, 112, 76, 108, 126, 205, 210, 95, 15, 77, 89, 168, 152, 224, 145, 149, 11, 25, 248, 248, 141, 218, 146, 132, 227, 41, 4, 234, 150, 243, 122, 231, 70, 17, 140, 157, 248, 45, 9, 208, 237, 122, 120, 23, 123, 4, 181, 40, 89, 129, 226, 196, 30, 24, 82, 158, 204, 123, 198, 187, 158, 215, 88, 62, 48, 158, 131, 93, 87, 140, 13, 184, 147, 46, 123, 195, 109, 68, 53, 179, 139, 195, 164, 199, 94, 133, 3, 189, 240, 254, 232, 132, 250, 241, 27, 55, 250, 0, 133, 20, 20, 242, 210, 6 }, "01113436425", "Patient", "patient2" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Scan",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Scan",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Scan",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Scan",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Scan",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Scan",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Scan",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Scan",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "TestParameters",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TestParameters",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TestParameters",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TestParameters",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "TestParameters",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "TestParameters",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "TestParameters",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "TestParameters",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "TestParameters",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "TestParameters",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "TestParameters",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "TestParameters",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "TestParameters",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "TestParameters",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "TestParameters",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "TestParameters",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "TestParameters",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "TestParameters",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "TestParameters",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "TestParameters",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "TestParameters",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "TestParameters",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "TestParameters",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "TestParameters",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "TestParameters",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "TestParameters",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "TestParameters",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "TestParameters",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "TestParameters",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "TestParameters",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "TestParameters",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "TestParameters",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "TestParameters",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "TestParameters",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "TestParameters",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "TestParameters",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "TestParameters",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "TestParameters",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "TestParameters",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "TestParameters",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "TestParameters",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Tests",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Tests",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Tests",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Tests",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Tests",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Tests",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Tests",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Tests",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Tests",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Tests",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Tests",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tests",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Tests",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Tests",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.AlterColumn<string>(
                name: "Unit",
                table: "TestParameters",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TestId",
                table: "TestParameters",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "TestParameterNumerical_TestId",
                table: "TestParameters",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TestParameters_TestParameterNumerical_TestId",
                table: "TestParameters",
                column: "TestParameterNumerical_TestId");

            migrationBuilder.AddForeignKey(
                name: "FK_TestParameters_Tests_TestParameterNumerical_TestId",
                table: "TestParameters",
                column: "TestParameterNumerical_TestId",
                principalTable: "Tests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
