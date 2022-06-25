using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Domain.Migrations
{
    public partial class updateScanAndTest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TestDetails_PatientTest_PatientTestId",
                table: "TestDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_TestDetails_PatientTest_TestDetailsNumerical_PatientTestId",
                table: "TestDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_TestParameters_Tests_TestId",
                table: "TestParameters");

            migrationBuilder.DropForeignKey(
                name: "FK_TestParameters_Tests_TestParameterNumerical_TestId",
                table: "TestParameters");

            migrationBuilder.DropIndex(
                name: "IX_TestDetails_TestDetailsNumerical_PatientTestId",
                table: "TestDetails");

            migrationBuilder.DropColumn(
                name: "TestDetailsNumerical_PatientTestId",
                table: "TestDetails");

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
                name: "PatientTestId",
                table: "TestDetails",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IndoorPatientRecordId",
                table: "ScanRequests",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IndoorPatientRecordId",
                table: "LabRequests",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ScanRequests_IndoorPatientRecordId",
                table: "ScanRequests",
                column: "IndoorPatientRecordId");

            migrationBuilder.CreateIndex(
                name: "IX_LabRequests_IndoorPatientRecordId",
                table: "LabRequests",
                column: "IndoorPatientRecordId");

            migrationBuilder.AddForeignKey(
                name: "FK_LabRequests_IndoorPatients_IndoorPatientRecordId",
                table: "LabRequests",
                column: "IndoorPatientRecordId",
                principalTable: "IndoorPatients",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ScanRequests_IndoorPatients_IndoorPatientRecordId",
                table: "ScanRequests",
                column: "IndoorPatientRecordId",
                principalTable: "IndoorPatients",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TestDetails_PatientTest_PatientTestId",
                table: "TestDetails",
                column: "PatientTestId",
                principalTable: "PatientTest",
                principalColumn: "PatientTestId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TestParameters_Tests_TestId",
                table: "TestParameters",
                column: "TestId",
                principalTable: "Tests",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_TestParameters_Tests_TestParameterNumerical_TestId",
                table: "TestParameters",
                column: "TestParameterNumerical_TestId",
                principalTable: "Tests",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LabRequests_IndoorPatients_IndoorPatientRecordId",
                table: "LabRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_ScanRequests_IndoorPatients_IndoorPatientRecordId",
                table: "ScanRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_TestDetails_PatientTest_PatientTestId",
                table: "TestDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_TestParameters_Tests_TestId",
                table: "TestParameters");

            migrationBuilder.DropForeignKey(
                name: "FK_TestParameters_Tests_TestParameterNumerical_TestId",
                table: "TestParameters");

            migrationBuilder.DropIndex(
                name: "IX_ScanRequests_IndoorPatientRecordId",
                table: "ScanRequests");

            migrationBuilder.DropIndex(
                name: "IX_LabRequests_IndoorPatientRecordId",
                table: "LabRequests");

            migrationBuilder.DropColumn(
                name: "IndoorPatientRecordId",
                table: "ScanRequests");

            migrationBuilder.DropColumn(
                name: "IndoorPatientRecordId",
                table: "LabRequests");

            migrationBuilder.AlterColumn<string>(
                name: "Unit",
                table: "TestParameters",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "PatientTestId",
                table: "TestDetails",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "TestDetailsNumerical_PatientTestId",
                table: "TestDetails",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TestDetails_TestDetailsNumerical_PatientTestId",
                table: "TestDetails",
                column: "TestDetailsNumerical_PatientTestId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_TestParameters_Tests_TestId",
                table: "TestParameters",
                column: "TestId",
                principalTable: "Tests",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TestParameters_Tests_TestParameterNumerical_TestId",
                table: "TestParameters",
                column: "TestParameterNumerical_TestId",
                principalTable: "Tests",
                principalColumn: "Id");
        }
    }
}
