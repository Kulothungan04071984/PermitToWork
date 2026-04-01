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

        // ===== DATE & TIME =====
        public DateTime StartDate { get; set; }
        public string StartTime { get; set; }
        public DateTime EndDate { get; set; }
        public string EndTime { get; set; }

        // ===== WORK TYPE =====
        public bool Welding { get; set; }
        public bool ChippingCuttingGrinding { get; set; }

        // ===== WORK DETAILS =====
        public string WorkDescription { get; set; }
        public string ToolsEquipment { get; set; }

        // ===== DOCUMENTS =====
        public bool AttachJSA { get; set; }
        public bool AttachRiskAssessment { get; set; }
        public string AttachOther { get; set; }

        // ===== PRECAUTION =====
        public string Precaution { get; set; }

        //=====HOSE INSPECTION===



        // ===== SAFETY =====
        public string IsWelderCertified { get; set; }
        public string CombustibleRemoved { get; set; }
        public bool HosesFreeGrease { get; set; }
        public bool HosesCutCrack { get; set; }
        public bool HosesSpecialClips { get; set; }
        public string HosesNA { get; set; }

        public List<string> Regulator { get; set; }
        public string RegulatorNA { get; set; }


        public string FlashbackArrestors { get; set; }
        public string CylindersProvided { get; set; }

        // ===== EMERGENCY =====
        public string EmergencyTeamAvailable { get; set; }
        public string EmergencyContact1 { get; set; }
        public string EmergencyContact2 { get; set; }
        public string EmergencyContact3 { get; set; }
        public string ToolsTested { get; set; }


        public bool WC { get; set; }
        public bool ESI { get; set; }
        public string WCFilePath { get; set; }
        public string ESIFilePath { get; set; }

        // ===== INSPECTION =====
        public string FireExtinguisherDetails { get; set; }
        public bool FireExtinguisherChecked { get; set; }
        public bool FireBlanketChecked { get; set; }
        public bool WarningSignChecked { get; set; }
        public bool LightingChecked { get; set; }
        public bool SafetyBarriersChecked { get; set; }
        public bool SandBucketChecked { get; set; }

        // ===== PPE =====
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

        // ===== AUTHORIZATION =====
        public string ReceiverName { get; set; }
        public string ReceiverDate { get; set; }
        public string IssuerName { get; set; }
        public string IssuerDate { get; set; }

        // ===== SUSPENSION =====
        public string SuspensionName { get; set; }
        public string SuspensionSignatureDate { get; set; }

        // ===== SYSTEM =====
        public string Status { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;
    }
}
