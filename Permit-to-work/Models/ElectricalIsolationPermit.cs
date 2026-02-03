using System.ComponentModel.DataAnnotations;

namespace Permit_to_work.Models
{
    public class ElectricalIsolationPermit
    {
        [Key]
        public int PermitId { get; set; }

        // Basic Info
        public string Unit { get; set; }
        public string Location { get; set; }
        public int NumberOfWorkmen { get; set; }

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
        public bool RiskNearOverheadLines { get; set; }

        // Precautions
        public bool SafeDistanceMaintained { get; set; }
        public string Voltage { get; set; }
        public string Distance { get; set; }
        public bool ConfinedSpaceRequired { get; set; }
        public bool PowerIsolatedLOTO { get; set; }
        public bool SwitchOut { get; set; }
        public bool LockoutTagout { get; set; }
        public int NoOfLocks { get; set; }
        public bool TestedDeEnergized { get; set; }

        // PPE
        public bool PPEHelmet { get; set; }
        public bool PPEShoes { get; set; }
        public bool PPEElectricalGloves { get; set; }
        public bool PPEHalfMask { get; set; }
        public bool PPEFaceShield { get; set; }
        public bool PPEArcFlash { get; set; }
        public bool PPEDustMask { get; set; }
        public bool PPEEarPlug { get; set; }

        // Authorization
        public string ReceiverName { get; set; }
        public string IssuerName { get; set; }

        public DateTime CreatedOn { get; set; } = DateTime.Now;
    }
}
