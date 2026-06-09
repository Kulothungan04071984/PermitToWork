using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Permit_to_work.Migrations
{
    /// <inheritdoc />
    public partial class Updatedb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "ESI",
                table: "ColdWorkPermits",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "IssuerDate",
                table: "ColdWorkPermits",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "ColdWorkPermits",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ReceiverDate",
                table: "ColdWorkPermits",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "SuspensionDate",
                table: "ColdWorkPermits",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "WC",
                table: "ColdWorkPermits",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ESI",
                table: "ColdWorkPermits");

            migrationBuilder.DropColumn(
                name: "IssuerDate",
                table: "ColdWorkPermits");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "ColdWorkPermits");

            migrationBuilder.DropColumn(
                name: "ReceiverDate",
                table: "ColdWorkPermits");

            migrationBuilder.DropColumn(
                name: "SuspensionDate",
                table: "ColdWorkPermits");

            migrationBuilder.DropColumn(
                name: "WC",
                table: "ColdWorkPermits");
        }
    }
}
