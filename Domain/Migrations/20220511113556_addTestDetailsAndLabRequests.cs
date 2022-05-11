using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Domain.Migrations
{
    public partial class addTestDetailsAndLabRequests : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LabRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LabName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDtm = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    DoctorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LabRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LabRequests_Users_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LabRequests_Users_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "PatientTest",
                columns: table => new
                {
                    PatientTestId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    TestId = table.Column<int>(type: "int", nullable: false),
                    DoctorId = table.Column<int>(type: "int", nullable: false),
                    TestDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientTest", x => x.PatientTestId);
                    table.ForeignKey(
                        name: "FK_PatientTest_Tests_TestId",
                        column: x => x.TestId,
                        principalTable: "Tests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PatientTest_Users_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PatientTest_Users_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "TestDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TestParameterId = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MeasuredValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PatientTestId = table.Column<int>(type: "int", nullable: true),
                    TestDetailsNumerical_MeasuredValue = table.Column<float>(type: "real", nullable: true),
                    TestDetailsNumerical_PatientTestId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TestDetails_PatientTest_PatientTestId",
                        column: x => x.PatientTestId,
                        principalTable: "PatientTest",
                        principalColumn: "PatientTestId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TestDetails_PatientTest_TestDetailsNumerical_PatientTestId",
                        column: x => x.TestDetailsNumerical_PatientTestId,
                        principalTable: "PatientTest",
                        principalColumn: "PatientTestId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_TestDetails_TestParameters_TestParameterId",
                        column: x => x.TestParameterId,
                        principalTable: "TestParameters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LabRequests_DoctorId",
                table: "LabRequests",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_LabRequests_PatientId",
                table: "LabRequests",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientTest_DoctorId",
                table: "PatientTest",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientTest_PatientId",
                table: "PatientTest",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientTest_TestId",
                table: "PatientTest",
                column: "TestId");

            migrationBuilder.CreateIndex(
                name: "IX_TestDetails_PatientTestId",
                table: "TestDetails",
                column: "PatientTestId");

            migrationBuilder.CreateIndex(
                name: "IX_TestDetails_TestDetailsNumerical_PatientTestId",
                table: "TestDetails",
                column: "TestDetailsNumerical_PatientTestId");

            migrationBuilder.CreateIndex(
                name: "IX_TestDetails_TestParameterId",
                table: "TestDetails",
                column: "TestParameterId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LabRequests");

            migrationBuilder.DropTable(
                name: "TestDetails");

            migrationBuilder.DropTable(
                name: "PatientTest");
        }
    }
}
