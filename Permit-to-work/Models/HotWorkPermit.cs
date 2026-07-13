using System;

using System.ComponentModel.DataAnnotations;
namespace Permit_to_work.Models
{
    public class HotWorkPermit
    {
        [Key]
        public int PermitId { get; set; }

        // ===== BASIC DETAILS =====

        [Required(ErrorMessage = "Unit is required")]
        public string Unit { get; set; }

        [Required(ErrorMessage = "Contractor Name is required")]
        public string ContractorName { get; set; }
        
        [Required(ErrorMessage = "Location is required")]
        public string Location { get; set; }
        
        [Required(ErrorMessage = "No. Of Workmen is required")]
        public int NoOfWorkmen { get; set; }

        // ===== DATE & TIME =====

        [Required(ErrorMessage = "Starting Date is required")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "Starting Time is required")]
        public string StartTime { get; set; }

        [Required(ErrorMessage = "Ending Date is required")]
        public DateTime EndDate { get; set; }

        [Required(ErrorMessage = "Ending Time is required")]
        public string EndTime { get; set; }

        // ===== WORK TYPE =====

        [Required(ErrorMessage = "Work Type is required")]
        public bool Welding { get; set; }
        public bool ChippingCuttingGrinding { get; set; }

        // ===== WORK DETAILS =====
        public string WorkDescription { get; set; }

        //====== Tools & Equipment ======
        public string ToolsEquipment { get; set; }

        // ===== DOCUMENTS =====
        public bool AttachJSA { get; set; }
        public bool AttachRiskAssessment { get; set; }

        //====== IDENTIFICATION RISK =====
        public string AttachOther { get; set; }

        // ===== SAFETY =====
        public string CombustibleRemoved { get; set; }

        // ===== REGULATORS & GAUGES =====

        [Required(ErrorMessage = "Regulators and Gauges are required")]
        public string FlashbackArrestors { get; set; }
        public string CylindersProvided { get; set; }

        // ===== EMERGENCY =====

        [Required(ErrorMessage = "Emergency Team is required")]
        public string EmergencyTeamAvailable { get; set; }
        public string EmergencyContact1 { get; set; }
        public string EmergencyContact2 { get; set; }
        public string EmergencyContact3 { get; set; }
        public string ToolsTested { get; set; }

        // ==== INSURANCE COPY ====

        [Required(ErrorMessage = "Insurance Copy is required")]
        public bool WC { get; set; }
        public bool ESI { get; set; }
        public string WCFilePath { get; set; }
        public string ESIFilePath { get; set; }

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
        public bool SafetyShoes { get; set; }
        public bool WeldingGloves { get; set; }
        public bool FaceShield { get; set; }
        public bool WeldingGoggles { get; set; }
        public bool Apron { get; set; }
        public bool GasMask { get; set; }
        public bool EarPlugs { get; set; }
        public bool WeldingShield { get; set; }
        public bool WeldingClothes { get; set; }
        public string OtherPPE { get; set; }

        // ===== ISSUE & ACCEPTANCE =====

        [Required(ErrorMessage = "Receiver Name is required")]
        public string ReceiverName { get; set; }

        [Required(ErrorMessage = "Receiver Date is required")]
        public string ReceiverDate { get; set; }

        [Required(ErrorMessage = "Issuer Name is required")]
        public string IssuerName { get; set; }

        [Required(ErrorMessage = "Issuer Date is required")]
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
