using System.ComponentModel.DataAnnotations;

namespace Permit_to_work.Models
{
    public class WorkAtHeightPermit
    {
        [Key]
        public int PermitId { get; set; }

        // Basic Details
        public string Unit { get; set; }
        public string ContractorTeam { get; set; }
        public string Location { get; set; }
        public int NoOfWorkmen { get; set; }

        // Date & Time
        public DateTime StartDate { get; set; }
        public string StartTime { get; set; }
        public DateTime EndDate { get; set; }
        public string EndTime { get; set; }

        // Work Type
        public bool Scaffolding { get; set; }
        public bool Ladder { get; set; }
        public bool AerialLift { get; set; }
        public bool RoofWork { get; set; }
        public string OtherWork { get; set; }

        // Description
        public string WorkDescription { get; set; }
        public string ToolsEquipment { get; set; }

        // Risks
        public bool RiskFallHeight { get; set; }
        public bool RiskWeather { get; set; }
        public bool RiskFlyingParticles { get; set; }
        public bool RiskMovingVehicle { get; set; }
        public bool RiskFallingObjects { get; set; }
        public bool RiskProtrudingParts { get; set; }
        public bool RiskTripping { get; set; }
        public bool RiskFaultyEquipment { get; set; }
        public bool RiskFragileSurface { get; set; }
        public bool RiskWorkingBelow { get; set; }
        public bool RiskNearOverheadLines { get; set; }
        public bool RiskNonEnergizedEquipment { get; set; }

        // PPE
        public bool PPEHelmet { get; set; }
        public bool PPEHelmetChinStrap { get; set; }
        public bool PPEShoes { get; set; }
        public bool PPEGloves { get; set; }
        public bool PPEEarPlug { get; set; }
        public bool PPEReflectiveVest { get; set; }
        public bool PPEDustMask { get; set; }
        public bool PPESafetyClothes { get; set; }

        // Safety Systems
        public bool FallProtection { get; set; }
        public bool GuardRail { get; set; }
        public bool SafetyNet { get; set; }
        public bool ToeBoard { get; set; }
        public bool LifeLine { get; set; }
        public bool RetractableHarness { get; set; }
        public bool HarnessDoubleHook { get; set; }

        // Authorization
        public string ReceiverName { get; set; }
        public string IssuerName { get; set; }

        public DateTime CreatedOn { get; set; } = DateTime.Now;
    }
}
