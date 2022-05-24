using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Domain.Migrations
{
    public partial class patient : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VitalSigns_Note_NoteId",
                table: "VitalSigns");

            migrationBuilder.DropTable(
                name: "ClinicPatient");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Note",
                table: "Note");

            migrationBuilder.RenameTable(
                name: "Note",
                newName: "Notes");

            migrationBuilder.AddColumn<int>(
                name: "IndoorPatientRecordId",
                table: "VitalSigns",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Doctor_IndoorPatientRecordId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IndoorPatientRecordId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IndoorPatientRecordId",
                table: "Prescriptions",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DoctorId",
                table: "Notes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IndoorPatientRecordId",
                table: "Notes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NurseId",
                table: "Notes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Notes",
                table: "Notes",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "ClinicPatients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Appointmentcharges = table.Column<float>(type: "real", nullable: false),
                    PrescriptionId = table.Column<int>(type: "int", nullable: false),
                    AppointmentId = table.Column<int>(type: "int", nullable: false),
                    DoctorId = table.Column<int>(type: "int", nullable: false),
                    PatientId = table.Column<int>(type: "int", nullable: true),
                    OralMedicalHistory = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CauseOfAdmission = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    Diagnosis = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClinicPatients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClinicPatients_Appointments_AppointmentId",
                        column: x => x.AppointmentId,
                        principalTable: "Appointments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClinicPatients_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Department",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClinicPatients_Prescriptions_PrescriptionId",
                        column: x => x.PrescriptionId,
                        principalTable: "Prescriptions",
                        principalColumn: "PrescriptionId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ClinicPatients_Users_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ClinicPatients_Users_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "IndoorPatients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EnterDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DischargeDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Disharged = table.Column<bool>(type: "bit", nullable: false),
                    RoomId = table.Column<int>(type: "int", nullable: false),
                    PatientId = table.Column<int>(type: "int", nullable: true),
                    OralMedicalHistory = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CauseOfAdmission = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    Diagnosis = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IndoorPatients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IndoorPatients_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Department",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IndoorPatients_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_IndoorPatients_Users_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_VitalSigns_IndoorPatientRecordId",
                table: "VitalSigns",
                column: "IndoorPatientRecordId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Doctor_IndoorPatientRecordId",
                table: "Users",
                column: "Doctor_IndoorPatientRecordId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_IndoorPatientRecordId",
                table: "Users",
                column: "IndoorPatientRecordId");

            migrationBuilder.CreateIndex(
                name: "IX_Prescriptions_IndoorPatientRecordId",
                table: "Prescriptions",
                column: "IndoorPatientRecordId");

            migrationBuilder.CreateIndex(
                name: "IX_Notes_DoctorId",
                table: "Notes",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Notes_IndoorPatientRecordId",
                table: "Notes",
                column: "IndoorPatientRecordId");

            migrationBuilder.CreateIndex(
                name: "IX_Notes_NurseId",
                table: "Notes",
                column: "NurseId");

            migrationBuilder.CreateIndex(
                name: "IX_ClinicPatients_AppointmentId",
                table: "ClinicPatients",
                column: "AppointmentId");

            migrationBuilder.CreateIndex(
                name: "IX_ClinicPatients_DepartmentId",
                table: "ClinicPatients",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_ClinicPatients_DoctorId",
                table: "ClinicPatients",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_ClinicPatients_PatientId",
                table: "ClinicPatients",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_ClinicPatients_PrescriptionId",
                table: "ClinicPatients",
                column: "PrescriptionId");

            migrationBuilder.CreateIndex(
                name: "IX_IndoorPatients_DepartmentId",
                table: "IndoorPatients",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_IndoorPatients_PatientId",
                table: "IndoorPatients",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_IndoorPatients_RoomId",
                table: "IndoorPatients",
                column: "RoomId");

            migrationBuilder.AddForeignKey(
                name: "FK_Notes_IndoorPatients_IndoorPatientRecordId",
                table: "Notes",
                column: "IndoorPatientRecordId",
                principalTable: "IndoorPatients",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Notes_Users_DoctorId",
                table: "Notes",
                column: "DoctorId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Notes_Users_NurseId",
                table: "Notes",
                column: "NurseId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Prescriptions_IndoorPatients_IndoorPatientRecordId",
                table: "Prescriptions",
                column: "IndoorPatientRecordId",
                principalTable: "IndoorPatients",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_IndoorPatients_Doctor_IndoorPatientRecordId",
                table: "Users",
                column: "Doctor_IndoorPatientRecordId",
                principalTable: "IndoorPatients",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_IndoorPatients_IndoorPatientRecordId",
                table: "Users",
                column: "IndoorPatientRecordId",
                principalTable: "IndoorPatients",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_VitalSigns_IndoorPatients_IndoorPatientRecordId",
                table: "VitalSigns",
                column: "IndoorPatientRecordId",
                principalTable: "IndoorPatients",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_VitalSigns_Notes_NoteId",
                table: "VitalSigns",
                column: "NoteId",
                principalTable: "Notes",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notes_IndoorPatients_IndoorPatientRecordId",
                table: "Notes");

            migrationBuilder.DropForeignKey(
                name: "FK_Notes_Users_DoctorId",
                table: "Notes");

            migrationBuilder.DropForeignKey(
                name: "FK_Notes_Users_NurseId",
                table: "Notes");

            migrationBuilder.DropForeignKey(
                name: "FK_Prescriptions_IndoorPatients_IndoorPatientRecordId",
                table: "Prescriptions");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_IndoorPatients_Doctor_IndoorPatientRecordId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_IndoorPatients_IndoorPatientRecordId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_VitalSigns_IndoorPatients_IndoorPatientRecordId",
                table: "VitalSigns");

            migrationBuilder.DropForeignKey(
                name: "FK_VitalSigns_Notes_NoteId",
                table: "VitalSigns");

            migrationBuilder.DropTable(
                name: "ClinicPatients");

            migrationBuilder.DropTable(
                name: "IndoorPatients");

            migrationBuilder.DropIndex(
                name: "IX_VitalSigns_IndoorPatientRecordId",
                table: "VitalSigns");

            migrationBuilder.DropIndex(
                name: "IX_Users_Doctor_IndoorPatientRecordId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_IndoorPatientRecordId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Prescriptions_IndoorPatientRecordId",
                table: "Prescriptions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Notes",
                table: "Notes");

            migrationBuilder.DropIndex(
                name: "IX_Notes_DoctorId",
                table: "Notes");

            migrationBuilder.DropIndex(
                name: "IX_Notes_IndoorPatientRecordId",
                table: "Notes");

            migrationBuilder.DropIndex(
                name: "IX_Notes_NurseId",
                table: "Notes");

            migrationBuilder.DropColumn(
                name: "IndoorPatientRecordId",
                table: "VitalSigns");

            migrationBuilder.DropColumn(
                name: "Doctor_IndoorPatientRecordId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "IndoorPatientRecordId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "IndoorPatientRecordId",
                table: "Prescriptions");

            migrationBuilder.DropColumn(
                name: "DoctorId",
                table: "Notes");

            migrationBuilder.DropColumn(
                name: "IndoorPatientRecordId",
                table: "Notes");

            migrationBuilder.DropColumn(
                name: "NurseId",
                table: "Notes");

            migrationBuilder.RenameTable(
                name: "Notes",
                newName: "Note");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Note",
                table: "Note",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "ClinicPatient",
                columns: table => new
                {
                    ClinicPatientId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppointmentId = table.Column<int>(type: "int", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    DoctorId = table.Column<int>(type: "int", nullable: false),
                    Appointmentcharges = table.Column<float>(type: "real", nullable: false),
                    Diagnosis = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OralMedicalHistory = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PatientId = table.Column<int>(type: "int", nullable: true),
                    complain = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClinicPatient", x => x.ClinicPatientId);
                    table.ForeignKey(
                        name: "FK_ClinicPatient_Appointments_AppointmentId",
                        column: x => x.AppointmentId,
                        principalTable: "Appointments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClinicPatient_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Department",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClinicPatient_Users_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClinicPatient_Users_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClinicPatient_AppointmentId",
                table: "ClinicPatient",
                column: "AppointmentId");

            migrationBuilder.CreateIndex(
                name: "IX_ClinicPatient_DepartmentId",
                table: "ClinicPatient",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_ClinicPatient_DoctorId",
                table: "ClinicPatient",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_ClinicPatient_PatientId",
                table: "ClinicPatient",
                column: "PatientId");

            migrationBuilder.AddForeignKey(
                name: "FK_VitalSigns_Note_NoteId",
                table: "VitalSigns",
                column: "NoteId",
                principalTable: "Note",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
