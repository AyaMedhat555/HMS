using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Domain.Migrations
{
    public partial class UpdateIndoorBed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BedId",
                table: "IndoorPatients",
                type: "int",
                nullable: true,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_IndoorPatients_BedId",
                table: "IndoorPatients",
                column: "BedId");

            migrationBuilder.AddForeignKey(
                name: "FK_IndoorPatients_Beds_BedId",
                table: "IndoorPatients",
                column: "BedId",
                principalTable: "Beds",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IndoorPatients_Beds_BedId",
                table: "IndoorPatients");

            migrationBuilder.DropIndex(
                name: "IX_IndoorPatients_BedId",
                table: "IndoorPatients");

            migrationBuilder.DropColumn(
                name: "BedId",
                table: "IndoorPatients");
        }
    }
}
