using System.ComponentModel.DataAnnotations;

namespace Permit_to_work.Models
{
    public class ElectricalIsolationPermit
    {
        [Key]
        public int PermitId { get; set; }

        // Basic Details

        [Required(ErrorMessage = "Please fill the Unit.")]
        public string? Unit { get; set; }

        [Required(ErrorMessage = "Please fill the Date.")]
        public DateTime? PermitDate { get; set; }

        [Required(ErrorMessage = "Please fill the Location.")]
        public string? Location { get; set; }

        [Required(ErrorMessage = "Please fill the No. Of Workmen.")]
        public int? NumberOfWorkmen { get; set; }

        // Date & Time

        [Required(ErrorMessage = "Please fill the Starting Date.")]
        public DateTime? StartDate { get; set; }

        [Required(ErrorMessage = "Please fill the Starting Time.")]
        public string? StartTime { get; set; }

        [Required(ErrorMessage = "Please fill the Ending Date.")]
        public DateTime? EndDate { get; set; }

        [Required(ErrorMessage = "Please fill the Ending Time.")]
        public string? EndTime { get; set; }

        // Energy Status

        [Required(ErrorMessage = "Energy Status is required.")]
        public bool EnergizedEquipment { get; set; }
        public bool DeEnergizedEquipment { get; set; }

        // Work

        [Required(ErrorMessage = "Please fill the Work Description.")]
        public string? WorkDescription { get; set; }

        [Required(ErrorMessage = "Please fill the Tools/Equipment.")]
        public string? ToolsEquipment { get; set; }

        // Risks

        [Required(ErrorMessage = "Identify Risk is required.")]
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
        public string? OtherRisk { get; set; }

        // Documents
        public bool AttachJSA { get; set; }

        public string? OtherDocument { get; set; }

        // Precaution
        public string? Precaution { get; set; } // Yes, No, N/A
        public string? SafeDistance { get; set; } // Yes / No
        public string? Voltage { get; set; }
        public string? Distance { get; set; }
        public string? ConfinedSpace { get; set; } // Yes / No
        public string? ElectricalIsolation { get; set; }

        // LOTO / Isolation
        public bool SwitchOut { get; set; }
        public bool LockoutTagout { get; set; }
        public int? NumberOfLocks { get; set; }
        public bool TestConfirmed { get; set; }
        public bool ToolsTested { get; set; }
        public string? OtherLOTO { get; set; }

        // Insurance

        [Required(ErrorMessage = "Insurance is required.")]
        public bool WC { get; set; }
        public bool ESI { get; set; }
        public string? OtherInsurance { get; set; }

        // Inspection

        [Required(ErrorMessage = "Inspection is required.")]
        public bool FireExtinguisher { get; set; }

        public string? FireExtinguisherType { get; set; }
        public string? FireExtinguisherQuantity { get; set; }
        public string? FireExtinguisherSize { get; set; }

        public bool AccessRoute { get; set; }
        public bool DangerSign { get; set; }
        public bool Lighting { get; set; }
        public bool SafetyBarriers { get; set; }

        // PPE

        [Required(ErrorMessage = "PPE is required.")]
        public bool PPEHelmet { get; set; }
        public bool PPEShoes { get; set; }
        public bool PPEElectricalGloves { get; set; }
        public bool PPEHalfMask { get; set; }
        public bool PPEFaceShield { get; set; }
        public bool PPEArcFlash { get; set; }
        public bool PPEDustMask { get; set; }
        public bool PPESafetyGoggles { get; set; }
        public bool PPEReflectiveVest { get; set; }
        public bool PPESafetyEar { get; set; }
        public string? OtherPPE { get; set; }

        // Issue & Acceptance


        public string? RaisedBy { get; set; }

        public string? DeptIncharge { get; set; }

        public string? Facility { get; set; }

        public string? Safety { get; set; }

        // Suspension

        [Required(ErrorMessage = "Please fill the Suspension Name.")]
        public string? SuspensionName { get; set; }

        [Required(ErrorMessage = "Please fill the Suspension Date.")]
        public DateTime SuspensionSignatureDate { get; set; }


        // Approver Details

        [Required(ErrorMessage = "Please fill the Approver One field.")]
        public string? ApproverOne { get; set; }
        public string? ApproverTwo { get; set; }
        public string? ApproverThree { get; set; }
        public string? ApproverFour { get; set; }

        // Created timestamp
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public bool IsActive { get; set; }
        public string? Status { get; set; }
    }
}
