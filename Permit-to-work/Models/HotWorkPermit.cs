using System.ComponentModel.DataAnnotations;

namespace Permit_to_work.Models
{
    public class HotWorkPermit
    {
        [Key]
        public int PermitId { get; set; }

        // ===== BASIC DETAILS =====
        [Required]
        public string Unit { get; set; }

        [Required]
        public string ContractorName { get; set; }

        [Required]
        public string Location { get; set; }

        [Required]
        public int NoOfWorkmen { get; set; }

        // ===== DATE & TIME =====
        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public string StartTime { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        public string EndTime { get; set; }

        // ===== WORK DETAILS =====
        [Required]
        public string WorkDescription { get; set; }

        public string ToolsEquipment { get; set; }

        // ===== RISK IDENTIFICATION =====
        public bool RiskElectrocution { get; set; }
        public bool RiskArcFlash { get; set; }
        public bool RiskFlyingParticles { get; set; }
        public bool RiskNoise { get; set; }
        public bool RiskFireSpark { get; set; }
        public bool RiskManualHandling { get; set; }
        public bool RiskTripping { get; set; }
        public bool RiskElectricShock { get; set; }
        public bool RiskExplosion { get; set; }

        // ===== INSURANCE =====
        public bool InsuranceAvailable { get; set; }

        // ===== INSPECTION =====
        public bool FireExtinguisher { get; set; }
        public bool FireBlanket { get; set; }
        public bool WarningSigns { get; set; }
        public bool SafetyBarriers { get; set; }

        // ===== PPE =====
        public bool PPEHelmet { get; set; }
        public bool PPESafetyShoes { get; set; }
        public bool PPEWeldingGloves { get; set; }
        public bool PPEFaceShield { get; set; }

        // ===== AUTHORIZATION =====
        public string ReceiverName { get; set; }
        public string IssuerName { get; set; }

        // ===== WORKFLOW =====
        public string Status { get; set; }   // Pending / Approved / Rejected
        public string Remarks { get; set; }

        // ===== AUDIT =====
        public DateTime CreatedOn { get; set; } = DateTime.Now;
    }
}
