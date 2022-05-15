using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Domain.Migrations
{
    public partial class addMedicalScan : Migration
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
                name: "Scan",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ScanName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ScanCharge = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Scan", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ScanRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ScanName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDtm = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    DoctorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScanRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ScanRequests_Users_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ScanRequests_Users_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "PatientScans",
                columns: table => new
                {
                    PatientScanId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    WrittenReport = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    ScanId = table.Column<int>(type: "int", nullable: false),
                    DoctorId = table.Column<int>(type: "int", nullable: false),
                    ScanDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientScans", x => x.PatientScanId);
                    table.ForeignKey(
                        name: "FK_PatientScans_Scan_ScanId",
                        column: x => x.ScanId,
                        principalTable: "Scan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PatientScans_Users_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PatientScans_Users_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PatientScans_DoctorId",
                table: "PatientScans",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientScans_PatientId",
                table: "PatientScans",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientScans_ScanId",
                table: "PatientScans",
                column: "ScanId");

            migrationBuilder.CreateIndex(
                name: "IX_ScanRequests_DoctorId",
                table: "ScanRequests",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_ScanRequests_PatientId",
                table: "ScanRequests",
                column: "PatientId");

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
                name: "PatientScans");

            migrationBuilder.DropTable(
                name: "ScanRequests");

            migrationBuilder.DropTable(
                name: "Scan");

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
