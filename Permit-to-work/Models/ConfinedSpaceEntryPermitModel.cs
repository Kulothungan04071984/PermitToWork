using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Permit_to_work.Models
{
    public class ConfinedSpaceEntryPermitModel
    {
        public int Id { get; set; }

        // ---------- Header ----------
        [Required, Display(Name = "Unit")]
        public string? Unit { get; set; }

        [Required, Display(Name = "Contractor / Internal Team")]
        public string? ContractorOrInternalTeam { get; set; }

        [Required, Display(Name = "Location")]
        public string? Location { get; set; }

        [Display(Name = "No. of Workmen Involved")]
        [Range(0, 500)]
        public int NumberOfWorkmenInvolved { get; set; }

        [Required, Display(Name = "Starting From (Date)")]
        [DataType(DataType.Date)]
        public DateTime? StartingDate { get; set; }

        [Required, Display(Name = "Starting Time")]
        [DataType(DataType.Time)]
        public TimeSpan? StartingTime { get; set; }

        [Required, Display(Name = "Expected Completion (Date)")]
        [DataType(DataType.Date)]
        public DateTime? ExpectedCompletionDate { get; set; }

        [Required, Display(Name = "Expected Completion (Time)")]
        [DataType(DataType.Time)]
        public TimeSpan? ExpectedCompletionTime { get; set; }

        [Display(Name = "Work Description")]
        [DataType(DataType.MultilineText)]
        public string? WorkDescription { get; set; }

        [Display(Name = "Tools / Equipments to be Used")]
        [DataType(DataType.MultilineText)]
        public string? ToolsAndEquipmentsToBeUsed { get; set; }

        // ---------- Identified risks associated with this confined space entry ----------
        public bool RiskLackOfOxygen { get; set; }
        public bool RiskExplosion { get; set; }
        public bool RiskFumeVapor { get; set; }
        public bool RiskNoise { get; set; }
        public bool RiskHot { get; set; }
        public bool RiskFire { get; set; }
        public bool RiskDust { get; set; }
        public bool RiskVibration { get; set; }

        [Display(Name = "Other Risk (specify)")]
        public string? OtherRiskSpecify { get; set; }

        // ---------- Documents attached with this permit ----------
        public bool DocumentJsaAttached { get; set; }
        public bool DocumentRiskAssessmentAttached { get; set; }

        [Display(Name = "Other Document (specify)")]
        public string? OtherDocumentSpecify { get; set; }

        // ---------- Precautions required to complete the work safely ----------
        public PermitAnswer AtmosphericInspectionMade { get; set; }

        [Display(Name = "Oxygen % (19.5 - 23.5 %)")]
        public bool OxygenCheckPerformed { get; set; }
        public decimal? OxygenPercentage { get; set; }

        [Display(Name = "Explosive % LEL (Less than 10%)")]
        public bool ExplosiveCheckPerformed { get; set; }
        public decimal? ExplosivePercentageLel { get; set; }

        [Display(Name = "CO PPM (less than 35 PPM - 8hr)")]
        public bool CoCheckPerformed { get; set; }
        public decimal? CoPpm { get; set; }

        [Display(Name = "H2S PPM (less than 10 PPM - 8hr)")]
        public bool H2sCheckPerformed { get; set; }
        public decimal? H2sPpm { get; set; }

        [Display(Name = "Appropriate ventilation provided after atmospheric inspection?")]
        public PermitAnswer VentilationProvided { get; set; }
        public bool VentilationNatural { get; set; }
        public bool VentilationMechanical { get; set; }

        [Display(Name = "Mechanical Ventilation Details")]
        public string? MechanicalVentilationDetails { get; set; }

        [Display(Name = "Is appropriate communication system in place?")]
        public PermitAnswer CommunicationSystemInPlace { get; set; }

        [Display(Name = "If yes, state")]
        public string? CommunicationSystemDetails { get; set; }

        [Display(Name = "Are entrant and attendant well known about emergency procedure?")]
        public PermitAnswer EntrantAttendantKnowEmergencyProcedure { get; set; }

        [Display(Name = "Does the work require access to hot work?")]
        public PermitAnswer RequiresHotWorkAccess { get; set; }

        [Display(Name = "If yes, obtain a hot work permit")]
        public bool HotWorkPermitObtained { get; set; }

        [Display(Name = "If required, is lockout/tagout system followed?")]
        public PermitAnswer LockoutTagoutFollowed { get; set; }

        [Display(Name = "Are emergency team available in place or contact number displayed?")]
        public PermitAnswer EmergencyTeamAvailableOrContactDisplayed { get; set; }

        public string? EmergencyContact1 { get; set; }
        public string? EmergencyContact2 { get; set; }
        public string? EmergencyContact3 { get; set; }

        [Display(Name = "Other Precaution (specify)")]
        public string? OtherPrecautionSpecify { get; set; }

        [Display(Name = "Insurance / WC / ESI copy available for workmen?")]
        public PermitAnswer InsuranceCopyAvailable { get; set; }

        // ---------- Areas / items inspected by issuer and receiver ----------
        public List<InspectedItem> InspectedItems { get; set; } = new List<InspectedItem>
        {
            new InspectedItem { ItemName = "Fire Extinguisher" },
            new InspectedItem { ItemName = "Access/Egress" },
            new InspectedItem { ItemName = "Gas Detector" },
        };

        [Display(Name = "Other Inspected Item (specify)")]
        public string? OtherInspectedItemSpecify { get; set; }

        // ---------- PPE ----------
        public bool PpeHelmet { get; set; }
        public bool PpeSafetyShoes { get; set; }
        public bool PpeMechanicalGloves { get; set; }
        public bool PpeSafetyEarPlugsOrMuff { get; set; }
        public bool PpeSafetyGoggles { get; set; }
        public bool PpeReflectiveVest { get; set; }
        public bool PpeGasMask { get; set; }
        public bool PpeSafetyHarness { get; set; }
        public bool PpeGumboot { get; set; }
        public bool PpeDustMask { get; set; }

        [Display(Name = "Other PPE (specify)")]
        public string? OtherPpeSpecify { get; set; }

        // ---------- Issue and Acceptance ----------
        [Display(Name = "Permit Receiver Name")]
        public string? PermitReceiverName { get; set; }
        public string? PermitReceiverSignature { get; set; }
        public DateTime? PermitReceiverSignedDate { get; set; }

        [Display(Name = "Permit Issuer Name")]
        public string? PermitIssuerName { get; set; }
        public string? PermitIssuerSignature { get; set; }
        public DateTime? PermitIssuerSignedDate { get; set; }

        // ---------- Suspension ----------
        [Display(Name = "Permit Suspended?")]
        public bool IsSuspended { get; set; }

        [Display(Name = "Suspended By (Name)")]
        public string? SuspendedByName { get; set; }
        public string? SuspensionSignature { get; set; }
        public DateTime? SuspensionDate { get; set; }

        // --------- Approver Details ---------
        public string? ApproverOne { get; set; }
        public string? ApproverTwo { get; set; }
        public string? ApproverThree { get; set; }
        public string? ApproverFour { get; set; }

        public bool IsActive { get; set; }

        public bool RaisedBy {  get; set; }
        public bool Incharge {  get; set; }
        public bool Facility {  get; set; }
        public bool Safety { get; set; }
    }



    /// <summary>
    /// Represents a Yes / No / Not-Applicable style answer used throughout the permit.
    /// </summary>
    public enum PermitAnswer
    {
        [Display(Name = "")]
        NotAnswered = 0,

        [Display(Name = "Yes")]
        Yes = 1,

        [Display(Name = "No")]
        No = 2,

        [Display(Name = "N/A")]
        NotApplicable = 3
    }

    /// <summary>
    /// One row of the "areas / items inspected" table (Fire Extinguisher, Access/Egress, etc.)
    /// </summary>
    public class InspectedItem
    {
        public string? ItemName { get; set; }
        public string? Type { get; set; }
        public string? Quantity { get; set; }
        public string? Size { get; set; }
    }
}
