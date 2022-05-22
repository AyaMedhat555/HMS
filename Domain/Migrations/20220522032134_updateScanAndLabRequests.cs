using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Domain.Migrations
{
    public partial class updateScanAndLabRequests : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LabRequests_Users_DoctorId",
                table: "LabRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_PatientScans_Users_DoctorId",
                table: "PatientScans");

            migrationBuilder.DropForeignKey(
                name: "FK_PatientTest_Users_DoctorId",
                table: "PatientTest");

            migrationBuilder.DropForeignKey(
                name: "FK_ScanRequests_Users_DoctorId",
                table: "ScanRequests");

            migrationBuilder.AlterColumn<int>(
                name: "DoctorId",
                table: "ScanRequests",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "DoctorId",
                table: "PatientTest",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "DoctorId",
                table: "PatientScans",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "DoctorId",
                table: "LabRequests",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_LabRequests_Users_DoctorId",
                table: "LabRequests",
                column: "DoctorId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PatientScans_Users_DoctorId",
                table: "PatientScans",
                column: "DoctorId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PatientTest_Users_DoctorId",
                table: "PatientTest",
                column: "DoctorId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ScanRequests_Users_DoctorId",
                table: "ScanRequests",
                column: "DoctorId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LabRequests_Users_DoctorId",
                table: "LabRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_PatientScans_Users_DoctorId",
                table: "PatientScans");

            migrationBuilder.DropForeignKey(
                name: "FK_PatientTest_Users_DoctorId",
                table: "PatientTest");

            migrationBuilder.DropForeignKey(
                name: "FK_ScanRequests_Users_DoctorId",
                table: "ScanRequests");

            migrationBuilder.AlterColumn<int>(
                name: "DoctorId",
                table: "ScanRequests",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DoctorId",
                table: "PatientTest",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DoctorId",
                table: "PatientScans",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DoctorId",
                table: "LabRequests",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_LabRequests_Users_DoctorId",
                table: "LabRequests",
                column: "DoctorId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PatientScans_Users_DoctorId",
                table: "PatientScans",
                column: "DoctorId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PatientTest_Users_DoctorId",
                table: "PatientTest",
                column: "DoctorId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ScanRequests_Users_DoctorId",
                table: "ScanRequests",
                column: "DoctorId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
