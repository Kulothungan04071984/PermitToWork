using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Permit_to_work.Migrations
{
    /// <inheritdoc />
    public partial class CreateElectricalIsolationPermit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ElectricalIsolationPermits",
                columns: table => new
                {
                    PermitId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Unit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumberOfWorkmen = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EnergizedEquipment = table.Column<bool>(type: "bit", nullable: false),
                    DeEnergizedEquipment = table.Column<bool>(type: "bit", nullable: false),
                    WorkDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ToolsEquipment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RiskElectrocution = table.Column<bool>(type: "bit", nullable: false),
                    RiskArcFlash = table.Column<bool>(type: "bit", nullable: false),
                    RiskFlyingParticles = table.Column<bool>(type: "bit", nullable: false),
                    RiskNoise = table.Column<bool>(type: "bit", nullable: false),
                    RiskFallingObjects = table.Column<bool>(type: "bit", nullable: false),
                    RiskProtrudingParts = table.Column<bool>(type: "bit", nullable: false),
                    RiskTripping = table.Column<bool>(type: "bit", nullable: false),
                    RiskElectricShock = table.Column<bool>(type: "bit", nullable: false),
                    RiskFire = table.Column<bool>(type: "bit", nullable: false),
                    RiskManualHandling = table.Column<bool>(type: "bit", nullable: false),
                    RiskElectricBurn = table.Column<bool>(type: "bit", nullable: false),
                    RiskNearOverheadLines = table.Column<bool>(type: "bit", nullable: false),
                    SafeDistanceMaintained = table.Column<bool>(type: "bit", nullable: false),
                    Voltage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Distance = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConfinedSpaceRequired = table.Column<bool>(type: "bit", nullable: false),
                    PowerIsolatedLOTO = table.Column<bool>(type: "bit", nullable: false),
                    SwitchOut = table.Column<bool>(type: "bit", nullable: false),
                    LockoutTagout = table.Column<bool>(type: "bit", nullable: false),
                    NoOfLocks = table.Column<int>(type: "int", nullable: false),
                    TestedDeEnergized = table.Column<bool>(type: "bit", nullable: false),
                    PPEHelmet = table.Column<bool>(type: "bit", nullable: false),
                    PPEShoes = table.Column<bool>(type: "bit", nullable: false),
                    PPEElectricalGloves = table.Column<bool>(type: "bit", nullable: false),
                    PPEHalfMask = table.Column<bool>(type: "bit", nullable: false),
                    PPEFaceShield = table.Column<bool>(type: "bit", nullable: false),
                    PPEArcFlash = table.Column<bool>(type: "bit", nullable: false),
                    PPEDustMask = table.Column<bool>(type: "bit", nullable: false),
                    PPEEarPlug = table.Column<bool>(type: "bit", nullable: false),
                    ReceiverName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IssuerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ElectricalIsolationPermits", x => x.PermitId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ElectricalIsolationPermits");
        }
    }
}
