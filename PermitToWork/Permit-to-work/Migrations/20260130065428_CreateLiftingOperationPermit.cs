using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Permit_to_work.Migrations
{
    /// <inheritdoc />
    public partial class CreateLiftingOperationPermit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HotWorkPermits",
                columns: table => new
                {
                    PermitId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Unit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContractorName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NoOfWorkmen = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WorkDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ToolsEquipment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RiskElectrocution = table.Column<bool>(type: "bit", nullable: false),
                    RiskArcFlash = table.Column<bool>(type: "bit", nullable: false),
                    RiskFlyingParticles = table.Column<bool>(type: "bit", nullable: false),
                    RiskNoise = table.Column<bool>(type: "bit", nullable: false),
                    RiskFireSpark = table.Column<bool>(type: "bit", nullable: false),
                    RiskManualHandling = table.Column<bool>(type: "bit", nullable: false),
                    RiskTripping = table.Column<bool>(type: "bit", nullable: false),
                    RiskElectricShock = table.Column<bool>(type: "bit", nullable: false),
                    RiskExplosion = table.Column<bool>(type: "bit", nullable: false),
                    InsuranceAvailable = table.Column<bool>(type: "bit", nullable: false),
                    FireExtinguisher = table.Column<bool>(type: "bit", nullable: false),
                    FireBlanket = table.Column<bool>(type: "bit", nullable: false),
                    WarningSigns = table.Column<bool>(type: "bit", nullable: false),
                    SafetyBarriers = table.Column<bool>(type: "bit", nullable: false),
                    PPEHelmet = table.Column<bool>(type: "bit", nullable: false),
                    PPESafetyShoes = table.Column<bool>(type: "bit", nullable: false),
                    PPEWeldingGloves = table.Column<bool>(type: "bit", nullable: false),
                    PPEFaceShield = table.Column<bool>(type: "bit", nullable: false),
                    ReceiverName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IssuerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotWorkPermits", x => x.PermitId);
                });

            migrationBuilder.CreateTable(
                name: "LiftingOperationPermits",
                columns: table => new
                {
                    PermitId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Unit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContractorName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NoOfWorkmen = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TruckMounted = table.Column<bool>(type: "bit", nullable: false),
                    HydraCrane = table.Column<bool>(type: "bit", nullable: false),
                    OverheadCrane = table.Column<bool>(type: "bit", nullable: false),
                    TowerCrane = table.Column<bool>(type: "bit", nullable: false),
                    WeightApprox = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DimensionMax = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    RiggerLevel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SerialNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InspectionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CapacitySWL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WorkDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ToolsEquipment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RiskToppling = table.Column<bool>(type: "bit", nullable: false),
                    RiskSuspendedLoad = table.Column<bool>(type: "bit", nullable: false),
                    RiskHighWind = table.Column<bool>(type: "bit", nullable: false),
                    RiskMovingVehicle = table.Column<bool>(type: "bit", nullable: false),
                    RiskFallingObjects = table.Column<bool>(type: "bit", nullable: false),
                    RiskOverLoad = table.Column<bool>(type: "bit", nullable: false),
                    RiskTripping = table.Column<bool>(type: "bit", nullable: false),
                    RiskNoise = table.Column<bool>(type: "bit", nullable: false),
                    RiskCrushing = table.Column<bool>(type: "bit", nullable: false),
                    RiskCollapse = table.Column<bool>(type: "bit", nullable: false),
                    RiskNearOverheadLines = table.Column<bool>(type: "bit", nullable: false),
                    RiskTraffic = table.Column<bool>(type: "bit", nullable: false),
                    PPEHelmet = table.Column<bool>(type: "bit", nullable: false),
                    PPEShoes = table.Column<bool>(type: "bit", nullable: false),
                    PPEGloves = table.Column<bool>(type: "bit", nullable: false),
                    PPEEarPlug = table.Column<bool>(type: "bit", nullable: false),
                    PPEReflectiveVest = table.Column<bool>(type: "bit", nullable: false),
                    PPEDustMask = table.Column<bool>(type: "bit", nullable: false),
                    ReceiverName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IssuerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LiftingOperationPermits", x => x.PermitId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HotWorkPermits");

            migrationBuilder.DropTable(
                name: "LiftingOperationPermits");
        }
    }
}
