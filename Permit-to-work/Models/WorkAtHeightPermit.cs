using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace Permit_to_work.Models
{
    public class WorkAtHeightPermit
    {
        [Key]
        public int PermitId { get; set; }

        // Basic Details

        [Required(ErrorMessage = "Unit is required")]
        public string? Unit { get; set; }

        [Required(ErrorMessage = "ContractorTeam is required")]
        public string? ContractorTeam { get; set; }

        [Required(ErrorMessage = "Location is required")]
        public string? Location { get; set; }

        [Required(ErrorMessage = "NoOfWorkmen is required")]
        public int NoOfWorkmen { get; set; }

        // Date & Time

        [Required(ErrorMessage = "StartDate is required")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "StartTime is required")]
        public string? StartTime { get; set; }

        [Required(ErrorMessage = "EndDate is required")]
        public DateTime EndDate { get; set; }

        [Required(ErrorMessage = "EndTime is required")]
        public string? EndTime { get; set; }

        // Work Type

        [Required(ErrorMessage = "Work Type is required")]
        public bool Scaffolding { get; set; }
        public bool Ladder { get; set; }
        public bool AerialLift { get; set; }
        public bool RoofWork { get; set; }
        public string? OtherWork { get; set; }


        // Description

        [Required(ErrorMessage = "Description is required")]
        public string? WorkDescription { get; set; }
        public string? ToolsEquipment { get; set; }

        // Risks
        public bool FallfromHeight { get; set; }
        public bool AdverseWeather { get; set; }
        public bool FlyingParticles { get; set; }
        public bool MovingVehicleEquipment { get; set; }
        public bool FallingDebrisObjects { get; set; }
        public bool ProtrudingObjectsparts { get; set; }
        public bool TrippingSlipping { get; set; }
        public bool FaultyEquipmentMaterial { get; set; }
        public bool FragileSurfaceRoof { get; set; }
        public bool WorkUnderBelow { get; set; }
        public bool NearOverheadLines { get; set; }
        public bool NearEnergizedEquipment { get; set; }
        public string? OtherRiskControl { get; set; }

        // ===== Document =====
        public bool AttachJSA { get; set; }
        public bool RiskAssessment { get; set; }
        public string? AttachOther { get; set; }

        //// ===== WORK SAFELY =====

        //public string? Precautionmeasures { get; set; }

        ////risk control
        //public bool RiskControlImplemented { get; set; }

        //Fall 
        public bool GuardRailsSystem { get; set; }
        public bool SafetyNet { get; set; }
        public bool ToeBoard { get; set; }
        public bool LifeLine { get; set; }
        public bool RetractableHarness { get; set; }
        public bool HarnessShockAbsorber { get; set; }
        public bool DoubleHook { get; set; }
        public string? AccessProvided { get; set; }
        //public string? WindGreater32 { get; set; }
        public string? FloorOpeningsCovered { get; set; }
        //public string? ScaffoldCertified { get; set; }

        //Inspection

        [Required(ErrorMessage = "Inspection is required")]
        public bool DangerWarningSign { get; set; }
        public bool ScaffoldTagSystem { get; set; }
        public bool Lighting { get; set; }
        public bool SafetyBarriers { get; set; }
        public bool BuddySystem { get; set; }
        public bool Rescue { get; set; }
        public bool MaterialBasket { get; set; }
        public string? OtherInspection { get; set; }


        // PPE

        [Required(ErrorMessage = "PPE is required")]
        public bool PPEHelmetwithChinStrap { get; set; }
        public bool PPEHelmet { get; set; }
        public bool PPEShoes { get; set; }
        public bool PPEGloves { get; set; }
        public bool PPEEarPlug { get; set; }
        public bool PPEReflectiveVest { get; set; }
        public bool PPEDustMask { get; set; }
        public bool PPESafetyClothes { get; set; }
        public string? OtherPPE { get; set; }

      

        //INSURANCE

        [Required(ErrorMessage = "INSURANCE is required")]
        public bool WC { get; set; }
        public bool ESI { get; set; }
        public string? OtherInsurance { get; set; }


        // Authorization

        public string? RaisedBy { get; set; }
        public string? DepartmentIncharge { get; set; }
        public string? Facility { get; set; }
        public string? Safety { get; set; }


        // ===== SUSPENSION =====

        [Required(ErrorMessage = "SuspensionName is required")]
        public string? SuspensionName { get; set; }

        [Required(ErrorMessage = "SuspensionSignatureDate is required")]
        public DateTime SuspensionSignatureDate { get; set; }


        // Approver Details

        [Required(ErrorMessage = "Approver Details is required")]
        public string? ApproverOne { get; set; }
        public string? ApproverTwo { get; set; }
        public string? ApproverThree { get; set; }
        public string? ApproverFour { get; set; }

        public string? Status { get; set; }
        public DateTime? CreatedOn { get; set; } = DateTime.Now;
        public bool IsActive { get; set; }
        
       

    }
}
