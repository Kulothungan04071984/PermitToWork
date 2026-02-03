using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Permit_to_work.Migrations
{
    /// <inheritdoc />
    public partial class CreateWorkAtHeightPermit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WorkAtHeightPermits",
                columns: table => new
                {
                    PermitId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Unit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContractorTeam = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NoOfWorkmen = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Scaffolding = table.Column<bool>(type: "bit", nullable: false),
                    Ladder = table.Column<bool>(type: "bit", nullable: false),
                    AerialLift = table.Column<bool>(type: "bit", nullable: false),
                    RoofWork = table.Column<bool>(type: "bit", nullable: false),
                    OtherWork = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WorkDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ToolsEquipment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RiskFallHeight = table.Column<bool>(type: "bit", nullable: false),
                    RiskWeather = table.Column<bool>(type: "bit", nullable: false),
                    RiskFlyingParticles = table.Column<bool>(type: "bit", nullable: false),
                    RiskMovingVehicle = table.Column<bool>(type: "bit", nullable: false),
                    RiskFallingObjects = table.Column<bool>(type: "bit", nullable: false),
                    RiskProtrudingParts = table.Column<bool>(type: "bit", nullable: false),
                    RiskTripping = table.Column<bool>(type: "bit", nullable: false),
                    RiskFaultyEquipment = table.Column<bool>(type: "bit", nullable: false),
                    RiskFragileSurface = table.Column<bool>(type: "bit", nullable: false),
                    RiskWorkingBelow = table.Column<bool>(type: "bit", nullable: false),
                    RiskNearOverheadLines = table.Column<bool>(type: "bit", nullable: false),
                    RiskNonEnergizedEquipment = table.Column<bool>(type: "bit", nullable: false),
                    PPEHelmet = table.Column<bool>(type: "bit", nullable: false),
                    PPEHelmetChinStrap = table.Column<bool>(type: "bit", nullable: false),
                    PPEShoes = table.Column<bool>(type: "bit", nullable: false),
                    PPEGloves = table.Column<bool>(type: "bit", nullable: false),
                    PPEEarPlug = table.Column<bool>(type: "bit", nullable: false),
                    PPEReflectiveVest = table.Column<bool>(type: "bit", nullable: false),
                    PPEDustMask = table.Column<bool>(type: "bit", nullable: false),
                    PPESafetyClothes = table.Column<bool>(type: "bit", nullable: false),
                    FallProtection = table.Column<bool>(type: "bit", nullable: false),
                    GuardRail = table.Column<bool>(type: "bit", nullable: false),
                    SafetyNet = table.Column<bool>(type: "bit", nullable: false),
                    ToeBoard = table.Column<bool>(type: "bit", nullable: false),
                    LifeLine = table.Column<bool>(type: "bit", nullable: false),
                    RetractableHarness = table.Column<bool>(type: "bit", nullable: false),
                    HarnessDoubleHook = table.Column<bool>(type: "bit", nullable: false),
                    ReceiverName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IssuerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkAtHeightPermits", x => x.PermitId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WorkAtHeightPermits");
        }
    }
}
