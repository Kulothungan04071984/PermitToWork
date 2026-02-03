using System.ComponentModel.DataAnnotations;

namespace Permit_to_work.Models
{
    public class LiftingOperationPermit
    {
        [Key]
        public int PermitId { get; set; }

        // Basic Info
        public string Unit { get; set; }
        public string ContractorName { get; set; }
        public string Location { get; set; }
        public int NoOfWorkmen { get; set; }

        // Date & Time
        public DateTime StartDate { get; set; }
        public string StartTime { get; set; }
        public DateTime EndDate { get; set; }
        public string EndTime { get; set; }

        // Lifting Equipment
        public bool TruckMounted { get; set; }
        public bool HydraCrane { get; set; }
        public bool OverheadCrane { get; set; }
        public bool TowerCrane { get; set; }

        // Load Details
        public decimal WeightApprox { get; set; }
        public string DimensionMax { get; set; }
        public int Quantity { get; set; }

        // Rigger Level
        public string RiggerLevel { get; set; }

        // Equipment Details
        public string SerialNo { get; set; }
        public DateTime InspectionDate { get; set; }
        public string CapacitySWL { get; set; }

        // Work
        public string WorkDescription { get; set; }
        public string ToolsEquipment { get; set; }

        // Risks
        public bool RiskToppling { get; set; }
        public bool RiskSuspendedLoad { get; set; }
        public bool RiskHighWind { get; set; }
        public bool RiskMovingVehicle { get; set; }
        public bool RiskFallingObjects { get; set; }
        public bool RiskOverLoad { get; set; }
        public bool RiskTripping { get; set; }
        public bool RiskNoise { get; set; }
        public bool RiskCrushing { get; set; }
        public bool RiskCollapse { get; set; }
        public bool RiskNearOverheadLines { get; set; }
        public bool RiskTraffic { get; set; }

        // PPE
        public bool PPEHelmet { get; set; }
        public bool PPEShoes { get; set; }
        public bool PPEGloves { get; set; }
        public bool PPEEarPlug { get; set; }
        public bool PPEReflectiveVest { get; set; }
        public bool PPEDustMask { get; set; }

        // Authorization
        public string ReceiverName { get; set; }
        public string IssuerName { get; set; }

        // Status
        public string Status { get; set; } = "Pending";
        public DateTime CreatedOn { get; set; } = DateTime.Now;
    }
}
