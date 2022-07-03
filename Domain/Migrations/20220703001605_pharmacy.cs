using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Domain.Migrations
{
    public partial class pharmacy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bills",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomCharges = table.Column<double>(type: "float", nullable: true),
                    PrescriptionCharges = table.Column<double>(type: "float", nullable: true),
                    IndoorPatientRecordID = table.Column<int>(type: "int", nullable: false),
                    AppointmentsCharges = table.Column<double>(type: "float", nullable: true),
                    TestCharges = table.Column<double>(type: "float", nullable: true),
                    ScansCharges = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bills_IndoorPatients_IndoorPatientRecordID",
                        column: x => x.IndoorPatientRecordID,
                        principalTable: "IndoorPatients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Medicines",
                columns: table => new
                {
                    MedicineId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CommercialName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Group = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EffectiveSubstance = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicines", x => x.MedicineId);
                });

            migrationBuilder.CreateTable(
                name: "Stocks",
                columns: table => new
                {
                    StockId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StockLocation = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stocks", x => x.StockId);
                });

            migrationBuilder.CreateTable(
                name: "StockMedicines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Barcode = table.Column<int>(type: "int", nullable: false),
                    ConcentrationInMg = table.Column<int>(type: "int", nullable: false),
                    AddedDtm = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpireDtm = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StockId = table.Column<int>(type: "int", nullable: false),
                    MedicineId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockMedicines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StockMedicines_Medicines_MedicineId",
                        column: x => x.MedicineId,
                        principalTable: "Medicines",
                        principalColumn: "MedicineId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StockMedicines_Stocks_StockId",
                        column: x => x.StockId,
                        principalTable: "Stocks",
                        principalColumn: "StockId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDtm", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2022, 7, 3, 2, 16, 2, 296, DateTimeKind.Local).AddTicks(9285), new byte[] { 39, 134, 20, 134, 216, 102, 19, 140, 161, 113, 211, 20, 26, 138, 106, 151, 116, 221, 117, 74, 27, 101, 82, 131, 51, 249, 123, 190, 17, 141, 150, 158, 104, 67, 60, 156, 156, 60, 182, 234, 153, 14, 138, 97, 250, 234, 177, 181, 72, 220, 167, 49, 252, 187, 248, 251, 58, 250, 148, 166, 61, 169, 23, 209 }, new byte[] { 244, 21, 248, 93, 3, 163, 71, 174, 216, 189, 83, 208, 120, 163, 198, 230, 94, 15, 9, 133, 178, 108, 40, 243, 221, 22, 201, 135, 165, 112, 231, 249, 213, 129, 90, 121, 198, 197, 248, 212, 223, 170, 138, 112, 202, 101, 152, 131, 127, 122, 208, 37, 134, 36, 253, 175, 30, 113, 171, 231, 72, 185, 230, 100, 183, 31, 3, 120, 170, 219, 47, 46, 227, 191, 83, 211, 13, 51, 113, 209, 168, 49, 10, 205, 41, 42, 118, 22, 47, 225, 50, 127, 224, 207, 8, 155, 166, 51, 12, 173, 34, 56, 185, 234, 84, 214, 166, 222, 124, 132, 8, 86, 127, 124, 107, 37, 182, 253, 65, 138, 229, 142, 170, 105, 144, 14, 151, 102 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDtm", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2022, 7, 3, 2, 16, 2, 296, DateTimeKind.Local).AddTicks(9320), new byte[] { 44, 153, 101, 242, 164, 47, 199, 61, 12, 101, 246, 142, 11, 97, 214, 144, 211, 126, 19, 204, 156, 215, 239, 253, 145, 110, 236, 10, 212, 194, 248, 244, 131, 155, 2, 61, 122, 222, 105, 183, 30, 72, 163, 5, 82, 105, 174, 185, 236, 33, 28, 69, 225, 219, 54, 71, 240, 120, 200, 102, 218, 91, 224, 102 }, new byte[] { 95, 209, 64, 185, 193, 244, 110, 105, 215, 254, 103, 3, 24, 26, 161, 63, 125, 66, 225, 132, 116, 212, 109, 116, 138, 176, 116, 200, 15, 42, 210, 131, 116, 111, 31, 20, 20, 43, 177, 51, 29, 186, 136, 217, 95, 221, 77, 196, 115, 249, 193, 204, 35, 195, 67, 84, 36, 215, 84, 99, 59, 65, 4, 238, 193, 132, 246, 147, 226, 128, 98, 188, 187, 180, 135, 207, 24, 91, 6, 10, 86, 235, 173, 8, 162, 254, 88, 229, 208, 115, 60, 9, 185, 234, 89, 231, 67, 56, 122, 88, 92, 63, 164, 84, 31, 2, 142, 72, 107, 64, 78, 134, 239, 20, 138, 235, 69, 242, 31, 24, 230, 154, 175, 59, 93, 70, 98, 5 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDtm", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2022, 7, 3, 2, 16, 2, 296, DateTimeKind.Local).AddTicks(9333), new byte[] { 167, 229, 168, 206, 19, 100, 140, 76, 60, 138, 7, 26, 20, 78, 212, 81, 36, 224, 86, 52, 120, 232, 158, 224, 151, 111, 108, 96, 137, 96, 191, 187, 134, 209, 178, 111, 97, 73, 222, 26, 240, 37, 9, 26, 30, 89, 201, 215, 61, 235, 132, 250, 228, 43, 159, 242, 173, 145, 26, 134, 55, 254, 92, 186 }, new byte[] { 178, 53, 203, 94, 209, 85, 63, 159, 178, 56, 161, 200, 90, 192, 77, 56, 112, 16, 23, 122, 2, 248, 77, 70, 115, 126, 210, 49, 238, 252, 29, 17, 183, 177, 246, 196, 192, 140, 67, 8, 18, 137, 59, 3, 43, 5, 82, 54, 21, 104, 214, 191, 10, 127, 114, 224, 145, 49, 85, 45, 191, 131, 74, 74, 50, 247, 74, 84, 62, 64, 148, 9, 52, 189, 173, 188, 193, 123, 114, 101, 51, 51, 218, 104, 79, 174, 99, 82, 115, 191, 18, 9, 182, 196, 151, 145, 95, 115, 244, 36, 151, 206, 52, 102, 208, 86, 202, 246, 120, 11, 44, 175, 225, 1, 43, 119, 51, 103, 208, 83, 98, 241, 18, 9, 89, 245, 30, 65 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDtm", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2022, 7, 3, 2, 16, 2, 296, DateTimeKind.Local).AddTicks(9934), new byte[] { 14, 77, 122, 205, 244, 47, 232, 40, 138, 106, 252, 135, 209, 238, 92, 231, 197, 217, 126, 184, 121, 53, 207, 64, 111, 180, 251, 6, 37, 5, 91, 155, 0, 201, 31, 145, 217, 144, 233, 212, 177, 168, 161, 132, 229, 243, 23, 180, 138, 207, 3, 63, 53, 252, 11, 11, 200, 216, 16, 62, 58, 73, 180, 129 }, new byte[] { 222, 171, 222, 98, 218, 252, 55, 152, 205, 84, 83, 248, 152, 127, 31, 99, 213, 60, 149, 151, 90, 74, 188, 102, 155, 90, 72, 34, 13, 130, 254, 71, 238, 65, 86, 183, 140, 197, 221, 128, 52, 232, 0, 145, 147, 226, 244, 169, 61, 90, 51, 37, 15, 184, 1, 67, 20, 123, 136, 105, 105, 125, 67, 2, 127, 96, 44, 44, 70, 89, 25, 158, 92, 58, 53, 13, 231, 103, 233, 92, 46, 252, 120, 245, 252, 127, 78, 173, 152, 99, 126, 116, 240, 141, 231, 21, 103, 107, 209, 190, 93, 3, 159, 165, 176, 186, 181, 148, 49, 29, 7, 104, 83, 52, 205, 171, 191, 130, 210, 144, 213, 24, 45, 99, 72, 191, 137, 255 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDtm", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2022, 7, 3, 2, 16, 2, 296, DateTimeKind.Local).AddTicks(9945), new byte[] { 111, 191, 247, 16, 128, 108, 71, 200, 213, 215, 134, 242, 206, 147, 217, 13, 239, 78, 145, 3, 151, 110, 62, 168, 12, 73, 119, 167, 180, 167, 126, 82, 242, 123, 176, 185, 40, 59, 9, 138, 118, 174, 201, 118, 244, 189, 201, 199, 20, 106, 47, 68, 4, 24, 178, 158, 131, 34, 157, 158, 44, 102, 8, 121 }, new byte[] { 71, 158, 147, 167, 39, 42, 94, 115, 215, 98, 209, 111, 97, 30, 149, 24, 74, 253, 255, 33, 34, 19, 225, 195, 155, 209, 153, 31, 226, 205, 161, 143, 50, 119, 172, 241, 15, 112, 200, 60, 125, 84, 145, 129, 50, 87, 252, 136, 194, 242, 142, 47, 25, 250, 65, 69, 21, 103, 134, 171, 71, 210, 14, 108, 208, 152, 76, 242, 65, 222, 155, 177, 82, 197, 228, 67, 208, 139, 0, 9, 77, 19, 180, 163, 137, 49, 187, 26, 87, 195, 235, 159, 136, 63, 69, 66, 244, 150, 248, 157, 233, 39, 84, 124, 233, 127, 182, 144, 37, 222, 177, 227, 149, 31, 23, 202, 9, 154, 104, 108, 120, 98, 66, 234, 114, 161, 102, 54 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedDtm", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2022, 7, 3, 2, 16, 2, 296, DateTimeKind.Local).AddTicks(9955), new byte[] { 219, 251, 86, 155, 195, 94, 88, 175, 207, 245, 81, 53, 46, 176, 24, 4, 201, 237, 110, 66, 130, 142, 56, 132, 9, 239, 0, 52, 254, 84, 13, 39, 74, 158, 140, 170, 93, 28, 176, 103, 197, 170, 23, 23, 183, 78, 53, 196, 233, 233, 225, 15, 21, 5, 178, 107, 14, 139, 228, 39, 79, 142, 64, 34 }, new byte[] { 101, 213, 105, 238, 179, 2, 213, 216, 81, 86, 107, 151, 208, 107, 34, 13, 194, 254, 15, 190, 141, 97, 88, 128, 44, 116, 204, 73, 173, 86, 120, 217, 242, 94, 36, 37, 80, 208, 5, 221, 99, 56, 150, 83, 231, 162, 184, 38, 127, 162, 182, 255, 204, 124, 150, 148, 46, 62, 153, 1, 102, 132, 74, 230, 21, 105, 97, 119, 82, 44, 97, 92, 100, 191, 75, 113, 216, 206, 165, 102, 21, 38, 64, 201, 166, 144, 116, 150, 248, 203, 193, 6, 184, 115, 128, 61, 187, 180, 75, 161, 152, 51, 223, 21, 251, 217, 55, 142, 252, 0, 81, 242, 212, 211, 110, 84, 61, 213, 35, 37, 63, 30, 157, 102, 153, 90, 150, 178 } });

            migrationBuilder.CreateIndex(
                name: "IX_Bills_IndoorPatientRecordID",
                table: "Bills",
                column: "IndoorPatientRecordID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StockMedicines_MedicineId",
                table: "StockMedicines",
                column: "MedicineId");

            migrationBuilder.CreateIndex(
                name: "IX_StockMedicines_StockId",
                table: "StockMedicines",
                column: "StockId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bills");

            migrationBuilder.DropTable(
                name: "StockMedicines");

            migrationBuilder.DropTable(
                name: "Medicines");

            migrationBuilder.DropTable(
                name: "Stocks");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDtm", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2022, 6, 29, 18, 45, 44, 996, DateTimeKind.Local).AddTicks(5129), new byte[] { 121, 43, 143, 146, 53, 238, 163, 118, 73, 39, 42, 224, 153, 120, 12, 130, 223, 102, 44, 217, 108, 202, 63, 248, 161, 169, 128, 152, 59, 254, 48, 227, 102, 241, 56, 12, 154, 79, 189, 173, 104, 3, 241, 213, 123, 5, 219, 207, 235, 200, 88, 139, 39, 95, 1, 161, 156, 33, 124, 171, 224, 155, 220, 64 }, new byte[] { 239, 183, 73, 179, 71, 211, 163, 17, 74, 207, 182, 45, 208, 249, 138, 196, 76, 22, 122, 147, 244, 86, 177, 225, 26, 2, 126, 189, 168, 1, 159, 231, 95, 255, 224, 209, 80, 163, 150, 30, 60, 252, 246, 95, 115, 124, 233, 218, 218, 203, 242, 183, 151, 52, 121, 95, 200, 146, 147, 236, 57, 124, 143, 232, 211, 26, 132, 236, 167, 185, 23, 165, 109, 191, 113, 182, 9, 64, 199, 122, 50, 169, 136, 45, 201, 247, 16, 216, 211, 129, 97, 39, 61, 234, 29, 185, 141, 153, 55, 31, 73, 176, 161, 190, 98, 187, 51, 19, 132, 78, 35, 49, 52, 92, 0, 231, 108, 211, 237, 49, 177, 48, 136, 185, 151, 234, 162, 142 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDtm", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2022, 6, 29, 18, 45, 44, 996, DateTimeKind.Local).AddTicks(5161), new byte[] { 218, 219, 211, 215, 39, 105, 192, 14, 182, 183, 155, 254, 39, 76, 53, 75, 183, 222, 119, 186, 162, 64, 246, 228, 233, 104, 239, 135, 63, 167, 56, 74, 205, 69, 238, 163, 201, 199, 70, 72, 202, 219, 169, 254, 154, 50, 233, 141, 41, 35, 109, 130, 145, 173, 49, 151, 17, 103, 10, 188, 155, 182, 24, 19 }, new byte[] { 147, 83, 22, 242, 69, 211, 230, 97, 246, 105, 63, 235, 66, 210, 121, 163, 159, 117, 24, 11, 74, 34, 195, 25, 32, 197, 157, 24, 125, 138, 188, 122, 182, 2, 172, 95, 208, 129, 17, 26, 155, 95, 102, 65, 194, 149, 179, 116, 35, 83, 140, 130, 119, 56, 21, 18, 3, 196, 253, 1, 67, 112, 174, 253, 30, 184, 205, 74, 69, 102, 34, 207, 83, 187, 147, 67, 53, 178, 53, 139, 147, 130, 88, 35, 251, 201, 130, 32, 200, 69, 144, 208, 102, 206, 39, 214, 150, 49, 63, 170, 104, 178, 184, 171, 48, 133, 139, 112, 246, 95, 51, 165, 210, 149, 93, 49, 88, 150, 16, 132, 162, 119, 193, 140, 133, 210, 82, 106 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDtm", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2022, 6, 29, 18, 45, 44, 996, DateTimeKind.Local).AddTicks(5170), new byte[] { 104, 48, 79, 108, 70, 87, 234, 217, 164, 1, 66, 63, 241, 111, 112, 57, 250, 71, 145, 192, 243, 25, 137, 167, 203, 197, 245, 237, 131, 130, 75, 208, 223, 242, 89, 103, 97, 247, 226, 7, 148, 115, 188, 248, 87, 229, 212, 162, 255, 232, 123, 221, 113, 206, 161, 102, 34, 56, 43, 23, 214, 150, 77, 254 }, new byte[] { 90, 108, 167, 48, 80, 162, 93, 141, 75, 234, 214, 0, 45, 20, 25, 131, 214, 37, 109, 116, 125, 97, 35, 98, 236, 121, 108, 117, 63, 168, 109, 218, 137, 164, 126, 21, 31, 159, 168, 73, 218, 189, 116, 155, 126, 53, 53, 252, 37, 152, 179, 35, 183, 154, 96, 40, 119, 255, 186, 244, 157, 170, 21, 88, 177, 178, 139, 189, 222, 85, 88, 246, 147, 130, 219, 98, 104, 14, 210, 223, 98, 85, 113, 133, 135, 206, 112, 163, 67, 23, 7, 130, 143, 82, 132, 115, 24, 236, 81, 178, 69, 76, 36, 110, 98, 195, 112, 190, 170, 219, 91, 138, 205, 120, 88, 20, 159, 244, 104, 140, 254, 14, 199, 49, 65, 152, 101, 1 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDtm", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2022, 6, 29, 18, 45, 44, 996, DateTimeKind.Local).AddTicks(5893), new byte[] { 212, 99, 151, 36, 22, 70, 44, 96, 207, 191, 208, 109, 210, 54, 11, 85, 159, 200, 233, 162, 46, 123, 11, 89, 241, 233, 129, 98, 34, 8, 60, 47, 175, 230, 165, 111, 117, 90, 200, 82, 28, 24, 253, 214, 164, 111, 180, 124, 168, 169, 54, 118, 55, 148, 102, 233, 46, 205, 175, 120, 215, 17, 54, 181 }, new byte[] { 28, 186, 9, 223, 124, 118, 8, 44, 34, 189, 116, 100, 102, 95, 181, 148, 53, 88, 24, 221, 235, 154, 254, 223, 146, 51, 180, 253, 134, 12, 143, 237, 43, 84, 239, 121, 51, 171, 199, 3, 237, 159, 228, 59, 213, 132, 202, 247, 17, 152, 122, 234, 28, 127, 227, 61, 56, 105, 215, 110, 83, 14, 198, 154, 87, 66, 170, 85, 99, 214, 23, 72, 247, 171, 211, 65, 6, 124, 202, 145, 196, 32, 144, 183, 101, 36, 161, 68, 192, 90, 156, 201, 253, 143, 103, 115, 51, 246, 138, 245, 121, 46, 251, 208, 82, 1, 46, 7, 61, 120, 51, 211, 66, 58, 26, 116, 190, 225, 61, 42, 62, 56, 161, 252, 83, 17, 92, 11 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDtm", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2022, 6, 29, 18, 45, 44, 996, DateTimeKind.Local).AddTicks(5908), new byte[] { 10, 128, 67, 85, 25, 253, 108, 206, 12, 52, 253, 171, 47, 223, 5, 215, 54, 159, 42, 56, 24, 248, 181, 194, 63, 86, 216, 211, 43, 71, 222, 219, 117, 232, 186, 198, 24, 185, 162, 65, 44, 225, 61, 198, 173, 165, 227, 135, 209, 172, 155, 0, 153, 50, 216, 242, 43, 225, 72, 101, 213, 142, 146, 159 }, new byte[] { 163, 235, 89, 47, 11, 146, 15, 235, 182, 115, 221, 128, 19, 101, 32, 202, 53, 2, 154, 234, 215, 7, 255, 133, 121, 91, 90, 82, 140, 116, 49, 118, 79, 124, 44, 209, 240, 128, 231, 236, 56, 203, 210, 255, 116, 239, 12, 82, 98, 139, 45, 250, 126, 15, 30, 66, 191, 139, 125, 101, 224, 215, 196, 207, 9, 41, 253, 247, 32, 12, 85, 84, 82, 243, 105, 48, 240, 32, 7, 203, 47, 114, 212, 7, 35, 202, 81, 217, 126, 43, 216, 145, 45, 172, 5, 37, 66, 96, 16, 23, 66, 59, 150, 160, 135, 253, 100, 239, 104, 222, 79, 207, 203, 222, 127, 84, 21, 166, 39, 111, 140, 49, 24, 48, 33, 241, 54, 139 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedDtm", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2022, 6, 29, 18, 45, 44, 996, DateTimeKind.Local).AddTicks(5915), new byte[] { 33, 52, 10, 190, 176, 39, 129, 155, 49, 100, 192, 126, 193, 139, 106, 121, 163, 255, 219, 23, 220, 93, 215, 93, 188, 154, 187, 117, 192, 105, 191, 64, 0, 15, 33, 244, 66, 199, 161, 155, 237, 124, 228, 92, 203, 181, 50, 49, 237, 129, 121, 241, 183, 137, 156, 93, 53, 252, 225, 213, 249, 3, 220, 9 }, new byte[] { 24, 80, 195, 252, 190, 36, 31, 121, 34, 106, 0, 194, 129, 66, 188, 4, 33, 230, 54, 142, 85, 128, 143, 147, 202, 165, 244, 236, 23, 124, 9, 68, 147, 23, 252, 244, 166, 45, 145, 149, 232, 44, 168, 4, 133, 153, 81, 255, 72, 145, 13, 130, 248, 20, 33, 55, 81, 167, 128, 20, 229, 12, 169, 67, 30, 223, 28, 223, 19, 248, 43, 229, 121, 232, 107, 33, 248, 164, 75, 204, 125, 136, 176, 235, 205, 5, 185, 34, 15, 88, 208, 231, 207, 91, 68, 111, 4, 136, 21, 135, 250, 190, 250, 220, 121, 168, 231, 106, 162, 250, 15, 16, 48, 50, 213, 247, 208, 50, 152, 81, 61, 82, 38, 28, 252, 211, 173, 156 } });
        }
    }
}
