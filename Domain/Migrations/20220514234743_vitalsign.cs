using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Domain.Migrations
{
    public partial class vitalsign : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TestDetails_PatientTest_PatientTestId",
                table: "TestDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_TestDetails_PatientTest_TestDetailsNumerical_PatientTestId",
                table: "TestDetails");

            migrationBuilder.CreateTable(
                name: "Note",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Subject = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Body = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Note", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VitalSigns",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Pressure = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PulseRate = table.Column<int>(type: "int", nullable: false),
                    Temperature = table.Column<float>(type: "real", nullable: false),
                    ECG = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    RespirationRate = table.Column<float>(type: "real", nullable: false),
                    vitals_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NurseId = table.Column<int>(type: "int", nullable: false),
                    NoteId = table.Column<int>(type: "int", nullable: false),
                    Patientid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VitalSigns", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VitalSigns_Note_NoteId",
                        column: x => x.NoteId,
                        principalTable: "Note",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VitalSigns_Users_NurseId",
                        column: x => x.NurseId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VitalSigns_Users_Patientid",
                        column: x => x.Patientid,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VitalSigns_NoteId",
                table: "VitalSigns",
                column: "NoteId");

            migrationBuilder.CreateIndex(
                name: "IX_VitalSigns_NurseId",
                table: "VitalSigns",
                column: "NurseId");

            migrationBuilder.CreateIndex(
                name: "IX_VitalSigns_Patientid",
                table: "VitalSigns",
                column: "Patientid");

            migrationBuilder.AddForeignKey(
                name: "FK_TestDetails_PatientTest_PatientTestId",
                table: "TestDetails",
                column: "PatientTestId",
                principalTable: "PatientTest",
                principalColumn: "PatientTestId");

            migrationBuilder.AddForeignKey(
                name: "FK_TestDetails_PatientTest_TestDetailsNumerical_PatientTestId",
                table: "TestDetails",
                column: "TestDetailsNumerical_PatientTestId",
                principalTable: "PatientTest",
                principalColumn: "PatientTestId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TestDetails_PatientTest_PatientTestId",
                table: "TestDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_TestDetails_PatientTest_TestDetailsNumerical_PatientTestId",
                table: "TestDetails");

            migrationBuilder.DropTable(
                name: "VitalSigns");

            migrationBuilder.DropTable(
                name: "Note");

            migrationBuilder.AddForeignKey(
                name: "FK_TestDetails_PatientTest_PatientTestId",
                table: "TestDetails",
                column: "PatientTestId",
                principalTable: "PatientTest",
                principalColumn: "PatientTestId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TestDetails_PatientTest_TestDetailsNumerical_PatientTestId",
                table: "TestDetails",
                column: "TestDetailsNumerical_PatientTestId",
                principalTable: "PatientTest",
                principalColumn: "PatientTestId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
