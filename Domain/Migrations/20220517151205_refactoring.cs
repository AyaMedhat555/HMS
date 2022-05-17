using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Domain.Migrations
{
    public partial class refactoring : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ScanName",
                table: "ScanRequests");

            migrationBuilder.DropColumn(
                name: "LabName",
                table: "LabRequests");

            migrationBuilder.RenameColumn(
                name: "nurseDegree",
                table: "Users",
                newName: "NurseDegree");

            migrationBuilder.RenameColumn(
                name: "Docspecialization",
                table: "Users",
                newName: "DocSpecialization");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "ScanId",
                table: "ScanRequests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TestId",
                table: "LabRequests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Department",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_ScanRequests_ScanId",
                table: "ScanRequests",
                column: "ScanId");

            migrationBuilder.CreateIndex(
                name: "IX_LabRequests_TestId",
                table: "LabRequests",
                column: "TestId");

            migrationBuilder.AddForeignKey(
                name: "FK_LabRequests_Tests_TestId",
                table: "LabRequests",
                column: "TestId",
                principalTable: "Tests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ScanRequests_Scan_ScanId",
                table: "ScanRequests",
                column: "ScanId",
                principalTable: "Scan",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LabRequests_Tests_TestId",
                table: "LabRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_ScanRequests_Scan_ScanId",
                table: "ScanRequests");

            migrationBuilder.DropIndex(
                name: "IX_ScanRequests_ScanId",
                table: "ScanRequests");

            migrationBuilder.DropIndex(
                name: "IX_LabRequests_TestId",
                table: "LabRequests");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ScanId",
                table: "ScanRequests");

            migrationBuilder.DropColumn(
                name: "TestId",
                table: "LabRequests");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Department");

            migrationBuilder.RenameColumn(
                name: "NurseDegree",
                table: "Users",
                newName: "nurseDegree");

            migrationBuilder.RenameColumn(
                name: "DocSpecialization",
                table: "Users",
                newName: "Docspecialization");

            migrationBuilder.AddColumn<string>(
                name: "ScanName",
                table: "ScanRequests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LabName",
                table: "LabRequests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
