using System.ComponentModel.DataAnnotations;

namespace Permit_to_work.Models
{
    public class ElectricalIsolationPermit
    {
        [Key]
        public int PermitId { get; set; }

        // Basic Details
        public string Unit { get; set; }
        public DateTime PermitDate { get; set; }
        public string Location { get; set; }
        public int NumberOfWorkmen { get; set; }

        // Date & Time
        public DateTime StartDate { get; set; }
        public string StartTime { get; set; }
        public DateTime EndDate { get; set; }
        public string EndTime { get; set; }

        // Energy Status
        public bool EnergizedEquipment { get; set; }
        public bool DeEnergizedEquipment { get; set; }

        // Work
        public string WorkDescription { get; set; }
        public string ToolsEquipment { get; set; }

        // Risks
        public bool RiskElectrocution { get; set; }
        public bool RiskArcFlash { get; set; }
        public bool RiskFlyingParticles { get; set; }
        public bool RiskNoise { get; set; }
        public bool RiskFallingObjects { get; set; }
        public bool RiskProtrudingParts { get; set; }
        public bool RiskTripping { get; set; }
        public bool RiskElectricShock { get; set; }
        public bool RiskFire { get; set; }
        public bool RiskManualHandling { get; set; }
        public bool RiskElectricBurn { get; set; }
        public bool RiskOverheadLines { get; set; }
        public string OtherRisk { get; set; }

        // Documents
        public bool AttachJSA { get; set; }
      
        public string OtherDocument { get; set; }

        // Precaution
        public string Precaution { get; set; } // Yes, No, N/A
        public string SafeDistance { get; set; } // Yes / No
        public string Voltage { get; set; }
        public string Distance { get; set; }
        public string ConfinedSpace { get; set; } // Yes / No


        public string ElectricalIsolation { get; set; }

        // LOTO / Isolation
        public bool SwitchOut { get; set; }
        public bool LockoutTagout { get; set; }
        public int NumberOfLocks { get; set; }
        public bool TestConfirmed { get; set; }
        public bool ToolsTested { get; set; }
        public string OtherLOTO { get; set; }

        // Insurance
        public bool WC { get; set; }
        public bool ESI { get; set; }
        public string OtherInsurance { get; set; }

        // Inspection
        public bool FireExtinguisher { get; set; }

        public string FireExtinguisherType { get; set; }
        public string FireExtinguisherQuantity { get; set; }
        public string FireExtinguisherSize { get; set; }

        public bool AccessRoute { get; set; }
        public bool DangerSign { get; set; }
        public bool Lighting { get; set; }
        public bool SafetyBarriers { get; set; }

        // PPE
        public bool PPEHelmet { get; set; }
        public bool PPEShoes { get; set; }
        public bool PPEElectricalGloves { get; set; }
        public bool PPEHalfMask { get; set; }
        public bool PPEFaceShield { get; set; }
        public bool PPEArcFlash { get; set; }
        public bool PPEDustMask { get; set; }
        public bool PPEEarPlug { get; set; }
        public bool PPESafetyGoggles { get; set; }
        public bool PPEReflectiveVest { get; set; }
        public bool PPESafetyEar { get; set; }
        public string OtherPPE { get; set; }

        // Authorization / Issue & Acceptance
        public string ReceiverName { get; set; }
        public DateTime ReceiverSignatureDate { get; set; }
        public string IssuerName { get; set; }
        public DateTime IssuerSignatureDate { get; set; }

        // Suspension
        public string SuspensionName { get; set; }
        public DateTime SuspensionSignatureDate { get; set; }

        // Approver Details
        public string ApproverOne { get; set; }
        public string ApproverTwo { get; set; }
        public string ApproverThree { get; set; }
        public string ApproverFour { get; set; }

        // Created timestamp
        public DateTime CreatedOn { get; set; } = DateTime.Now;
    }
}
