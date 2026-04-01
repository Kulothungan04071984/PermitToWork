using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Permit_to_work.Migrations
{
    /// <inheritdoc />
    public partial class CreateHotWorkPermit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Equipment",
                table: "ColdWorkPermits",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Falling",
                table: "ColdWorkPermits",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Faulty",
                table: "ColdWorkPermits",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Heat",
                table: "ColdWorkPermits",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Illumination",
                table: "ColdWorkPermits",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Noise",
                table: "ColdWorkPermits",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Protruding",
                table: "ColdWorkPermits",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Tripping",
                table: "ColdWorkPermits",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Vibration",
                table: "ColdWorkPermits",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Equipment",
                table: "ColdWorkPermits");

            migrationBuilder.DropColumn(
                name: "Falling",
                table: "ColdWorkPermits");

            migrationBuilder.DropColumn(
                name: "Faulty",
                table: "ColdWorkPermits");

            migrationBuilder.DropColumn(
                name: "Heat",
                table: "ColdWorkPermits");

            migrationBuilder.DropColumn(
                name: "Illumination",
                table: "ColdWorkPermits");

            migrationBuilder.DropColumn(
                name: "Noise",
                table: "ColdWorkPermits");

            migrationBuilder.DropColumn(
                name: "Protruding",
                table: "ColdWorkPermits");

            migrationBuilder.DropColumn(
                name: "Tripping",
                table: "ColdWorkPermits");

            migrationBuilder.DropColumn(
                name: "Vibration",
                table: "ColdWorkPermits");
        }
    }
}
