using System;

using System.ComponentModel.DataAnnotations;
namespace Permit_to_work.Models
{
    public class HotWorkPermit
    {
        [Key]
        public int PermitId { get; set; }

        // ===== BASIC DETAILS =====
        public string Unit { get; set; }
        public string ContractorName { get; set; }
        public string Location { get; set; }
        public int NoOfWorkmen { get; set; }

        [Required(ErrorMessage = "Please fill the Unit field")]
        public string? Unit { get; set; }

        [Required(ErrorMessage = "Please fill the Contractor Name field")]
        public string? ContractorName { get; set; }

        [Required(ErrorMessage = "Please fill the Location field")]
        public string? Location { get; set; }

        [Required(ErrorMessage = "Please fill the No. of Workmen field")]
        public string? NoOfWorkmen { get; set; }

        // ===== DATE & TIME =====
        public DateTime StartDate { get; set; }
        public string StartTime { get; set; }
        public DateTime EndDate { get; set; }
        public string EndTime { get; set; }

        [Required(ErrorMessage = "Please fill the Starting Date field")]
        public DateTime? StartDate { get; set; }

        [Required(ErrorMessage = "Please fill the Starting Time field")]
        public string? StartTime { get; set; }

        [Required(ErrorMessage = "Please fill the Ending Date field")]
        public DateTime? EndDate { get; set; }

        [Required(ErrorMessage = "Please fill the Ending Time field")]
        public string? EndTime { get; set; }

        // ===== WORK TYPE =====

        [Required(ErrorMessage = "Work Type is required")]
        public bool Welding { get; set; }
        public bool ChippingCuttingGrinding { get; set; }

        // ===== WORK DETAILS =====
        public string? WorkDescription { get; set; }
        public string? ToolsEquipment { get; set; }

        // ===== RISK =====
        public bool Electrocution { get; set; }
        public bool ArcFlash { get; set; }
        public bool FlyingParticles { get; set; }
        public bool Noise { get; set; }
        public bool FallingObjects { get; set; }
        public bool ProtrudingObjects { get; set; }
        public bool TrippingSlipping { get; set; }
        public bool ElectricShock { get; set; }
        public bool FireSpark { get; set; }
        public bool ManualHandling { get; set; }
        public bool HotBurn { get; set; }
        public bool Explosion { get; set; }
        public bool HealthHazard { get; set; }
        public bool FumeSmoke { get; set; }


        // ===== DOCUMENTS =====
        public bool AttachJSA { get; set; }
        
        public string? AttachOther { get; set; }
 
        // ===== CERTIFICATION SAFETY =====
       
        public string? CombustibleRemoved { get; set; }


        //public List<string> Regulator { get; set; } = [];
        //public string? RegulatorNA { get; set; }
        public string? FlashbackArrestors { get; set; }
        public string? CylindersProvided { get; set; }
        public bool HosesFreeGrease { get; set; }
        public bool HosesCutCrack { get; set; }
        public string? EmergencyTeamAvailable { get; set; }
        public string? EmergencyContact1 { get; set; }
        public string? EmergencyContact2 { get; set; }
        public string? EmergencyContact3 { get; set; }
        public string? ToolsTested { get; set; }


        [Required(ErrorMessage = "Emergency Team is required")]
        public string EmergencyTeamAvailable { get; set; }
        public string EmergencyContact1 { get; set; }
        public string EmergencyContact2 { get; set; }
        public string EmergencyContact3 { get; set; }
        public string? FireExtinguisherDetails { get; set; }

        [Required(ErrorMessage = "Insurance Copy is required")]
        public bool WC { get; set; }
        public bool ESI { get; set; }
        public string? WCFilePath { get; set; }
        public string? ESIFilePath { get; set; }

        // ===== INSPECTION =====

        [Required(ErrorMessage = "Inspection is required")]
        public string FireExtinguisherDetails { get; set; }
        public bool FireExtinguisherChecked { get; set; }
        public bool FireBlanketChecked { get; set; }
        public bool WarningSignChecked { get; set; }
        public bool LightingChecked { get; set; }
        public bool SafetyBarriersChecked { get; set; }
        public bool SandBucketChecked { get; set; }

        // ===== PPE =====

        [Required(ErrorMessage = "PPE is required")]
        public bool Helmet { get; set; }
        // ===== AUTHORIZATION =====

        [Required(ErrorMessage = "Please fill the Receiver Name field")]
        public string? ReceiverName { get; set; }

        [Required(ErrorMessage = "Please fill the Receiver Date field")]
        public string? ReceiverDate { get; set; }

        [Required(ErrorMessage = "Please fill the Issuer Name field")]
        public string? IssuerName { get; set; }

        [Required(ErrorMessage = "Please fill the Issuer Date field")]
        public string? IssuerDate { get; set; }
        public bool GasMask { get; set; }
        public bool EarPlugs { get; set; }

        [Required(ErrorMessage = "Suspension Name is required")]
        public string SuspensionName { get; set; }

        [Required(ErrorMessage = "Suspension Date is required")]
        public string SuspensionSignatureDate { get; set; }

        [Required(ErrorMessage = "Please fill the Suspension Name field")]
        public string? SuspensionName { get; set; }

        [Required(ErrorMessage = "Please fill the Suspension Date field")]
        public string? SuspensionSignatureDate { get; set; }

        // ===== APPROVER DETAILS =====

        [Required(ErrorMessage = "Please fill the Approver One field")]
        public string? ApproverOne { get; set; }
        public string? ApproverTwo { get; set; }
        public string? ApproverThree { get; set; }
        public string? ApproverFour { get; set; }
        public string ReceiverDate { get; set; }
        public string IssuerName { get; set; }
        public string IssuerDate { get; set; }

        // ===== SUSPENSION =====

        [Required(ErrorMessage = "Suspension Name is required")]
        public string SuspensionName { get; set; }

        [Required(ErrorMessage = "Suspension Date is required")]
        public string SuspensionSignatureDate { get; set; }


        // Approver Details

        [Required(ErrorMessage = "Approver One Email is required")]
        public string ApproverOne { get; set; }
        public string ApproverTwo { get; set; }
        public string ApproverThree { get; set; }
        public string ApproverFour { get; set; }


        public string Status { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;
    }
}
