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

        //Precaution
        public string Precaution { get; set; }

        //Riskcontrol
        public string Riskcontrol { get; set; }

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

        public bool RiskControlImplemented { get; set; }
        public bool GuardRailsSystem { get; set; }
        public bool SafetyNet { get; set; }
        public bool ToeBoard { get; set; }
        public bool LifeLine { get; set; }
        public bool RetractableHarness { get; set; }
        public bool HarnessShockAbsorber { get; set; }
        public bool AccessProvided { get; set; }
        public bool WindGreater32 { get; set; }
        public bool FloorOpeningsCovered { get; set; }
        public bool ScaffoldCertified { get; set; }
        public string OtherRiskControl { get; set; }

        public bool DangerWarningSign { get; set; }
        public bool ScaffoldTagSystem { get; set; }
        public bool Lighting { get; set; }
        public bool SafetyBarriers { get; set; }
        public bool BuddySystem { get; set; }
        public bool Rescue { get; set; }
        public bool MaterialBasket { get; set; }
        public string OtherInspection { get; set; }


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

        public bool HarnessDoubleHook { get; set; }

        //INSURANCE
        public bool WC { get; set; }
        public bool ESI { get; set; }


        // Authorization
        public string ReceiverName { get; set; }
        public string IssuerName { get; set; }
        public DateTime ReceiverDate { get; set; }
        public DateTime IssuerDate { get; set; }


        // ===== SUSPENSION =====
        public string SuspensionName { get; set; }
        public string SuspensionSignatureDate { get; set; }

        public DateTime CreatedOn { get; set; } = DateTime.Now;

        // Approver Details

        public string ApproverOne { get; set; }
        public string ApproverTwo { get; set; }
        public string ApproverThree { get; set; }
        public string ApproverFour { get; set; }
    }
}
