using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Domain.Migrations
{
    public partial class updatepatient : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IndoorPatients_Users_PatientId",
                table: "IndoorPatients");

            migrationBuilder.DropColumn(
                name: "Appointmentcharges",
                table: "ClinicPatients");

            migrationBuilder.DropColumn(
                name: "CauseOfAdmission",
                table: "ClinicPatients");

            migrationBuilder.AddColumn<int>(
                name: "IndoorPatientRecordId",
                table: "PatientTest",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IndoorPatientRecordId",
                table: "PatientScans",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PatientId",
                table: "IndoorPatients",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OrderdByDoctorId",
                table: "IndoorPatients",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<float>(
                name: "AppointmentCharge",
                table: "Appointments",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.CreateIndex(
                name: "IX_PatientTest_IndoorPatientRecordId",
                table: "PatientTest",
                column: "IndoorPatientRecordId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientScans_IndoorPatientRecordId",
                table: "PatientScans",
                column: "IndoorPatientRecordId");

            migrationBuilder.CreateIndex(
                name: "IX_IndoorPatients_OrderdByDoctorId",
                table: "IndoorPatients",
                column: "OrderdByDoctorId");

            migrationBuilder.AddForeignKey(
                name: "FK_IndoorPatients_Users_OrderdByDoctorId",
                table: "IndoorPatients",
                column: "OrderdByDoctorId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IndoorPatients_Users_PatientId",
                table: "IndoorPatients",
                column: "PatientId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_PatientScans_IndoorPatients_IndoorPatientRecordId",
                table: "PatientScans",
                column: "IndoorPatientRecordId",
                principalTable: "IndoorPatients",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PatientTest_IndoorPatients_IndoorPatientRecordId",
                table: "PatientTest",
                column: "IndoorPatientRecordId",
                principalTable: "IndoorPatients",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IndoorPatients_Users_OrderdByDoctorId",
                table: "IndoorPatients");

            migrationBuilder.DropForeignKey(
                name: "FK_IndoorPatients_Users_PatientId",
                table: "IndoorPatients");

            migrationBuilder.DropForeignKey(
                name: "FK_PatientScans_IndoorPatients_IndoorPatientRecordId",
                table: "PatientScans");

            migrationBuilder.DropForeignKey(
                name: "FK_PatientTest_IndoorPatients_IndoorPatientRecordId",
                table: "PatientTest");

            migrationBuilder.DropIndex(
                name: "IX_PatientTest_IndoorPatientRecordId",
                table: "PatientTest");

            migrationBuilder.DropIndex(
                name: "IX_PatientScans_IndoorPatientRecordId",
                table: "PatientScans");

            migrationBuilder.DropIndex(
                name: "IX_IndoorPatients_OrderdByDoctorId",
                table: "IndoorPatients");

            migrationBuilder.DropColumn(
                name: "IndoorPatientRecordId",
                table: "PatientTest");

            migrationBuilder.DropColumn(
                name: "IndoorPatientRecordId",
                table: "PatientScans");

            migrationBuilder.DropColumn(
                name: "OrderdByDoctorId",
                table: "IndoorPatients");

            migrationBuilder.DropColumn(
                name: "AppointmentCharge",
                table: "Appointments");

            migrationBuilder.AlterColumn<int>(
                name: "PatientId",
                table: "IndoorPatients",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<float>(
                name: "Appointmentcharges",
                table: "ClinicPatients",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<string>(
                name: "CauseOfAdmission",
                table: "ClinicPatients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_IndoorPatients_Users_PatientId",
                table: "IndoorPatients",
                column: "PatientId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
