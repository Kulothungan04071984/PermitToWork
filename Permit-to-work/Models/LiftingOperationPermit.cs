using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Permit_to_work.Models
{
    public class LiftingOperationPermit
    {
        [Key]
        public int PermitId { get; set; }

        // Basic Info
        
        [Required(ErrorMessage = "Please fill the Unit field")]
        public string? Unit { get; set; }

        [Required(ErrorMessage = "Please fill the Contractor Name field")]
        public string? ContractorName { get; set; }

        [Required(ErrorMessage = "Please fill the Location field")]
        public string? Location { get; set; }

        [Required(ErrorMessage = "Please fill the No. of Workmen field")]
        public int NoOfWorkmen { get; set; }

        // Date & time

        [Required(ErrorMessage = "Please fill the Starting Date field")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "Please fill the Starting Time field")]
        public string? StartTime { get; set; }

        [Required(ErrorMessage = "Please fill the Ending Date field")]
        public DateTime EndDate { get; set; }

        [Required(ErrorMessage = "Please fill the Ending Time field")]
        public string? EndTime { get; set; }

        //LIFTING EQUIPMENT

        [Required(ErrorMessage = "Lifting Equipment is required")]
        public bool TruckMounted { get; set; }
        public bool HydraCrane { get; set; }
        public bool OverheadCrane { get; set; }
        public bool TowerCrane { get; set; }

        //Details of Load

        [Required(ErrorMessage = "Details of Load is required")]
        public bool WeightApprox { get; set; }
        public bool DimensionMax { get; set; }
        public bool Quantity { get; set; }

        //RiggerLevel
        public string? RiggerLevel { get; set; }

        //Work Details
        public string? SerialNo { get; set; }
        public DateTime InspectionDate { get; set; }
        public string? CapacitySWL { get; set; }
        public string? WorkDescription { get; set; }
        public string? ToolsEquipment { get; set; }


        //Risks
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
        public bool RiskAdverseWeather { get; set; }
        public string? OtherRisk { get; set; }

        //Document
        public bool AttachJSA { get; set; }
        public string? CombustibleMaterialsRemoved { get; set; }
        public string? EquipmentCertified { get; set; }

        //Rigging Accessories
        public bool WireRope { get; set; }
        public bool WebSling { get; set; }
        public bool ChainSling { get; set; }
        public bool Shackles { get; set; }
        public bool EyeBolt { get; set; }
        public string? OtherRigging { get; set; }

        //Load & Wind Check
        public bool LoadChartChecked { get; set; }
        public bool WindAcceptable { get; set; }

        //Inspected Area
        public bool GroundCondition { get; set; }
        public bool DangerWarningSign { get; set; }
        public bool SignalMan { get; set; }
        public bool SafetyBarriers { get; set; }
        public bool TagLine { get; set; }
        public bool Rigger { get; set; }
        public bool OutriggerExtended { get; set; }
        public bool Lighting { get; set; }
        public bool OutriggerPad { get; set; }
        public bool SpreaderBeam { get; set; }
        public bool ManMaterialBasketCertified { get; set; }



        //PPE
        public bool PPEHelmet { get; set; }
        public bool PPEShoes { get; set; }
        public bool PPEGloves { get; set; }
        public bool PPEEarPlug { get; set; }
        public bool PPESafetygoggles { get; set; }
        public bool PPEReflectiveVest { get; set; }
        public bool PPEDustMask { get; set; }
        public string? OtherPPE { get; set; }


        //Insurance copy

        [Required(ErrorMessage = "Insurance copy is required")]
        public bool WC { get; set; }
        public bool ESI { get; set; }
        public string? WCFilePath { get; set; }
        public string? ESIFilePath { get; set; }

        //Authorization
        public string? RaisedBy { get; set; }
        public string? DepartmentIncharge { get; set; }
        public string? Facility { get; set; }
        public string? Safety { get; set; }

        //Suspension
        public string? SuspensionName { get; set; }
        public DateTime SuspensionSignatureDate { get; set; }

        //Approver Details
        public string? ApproverOne { get; set; }
        public string? ApproverTwo { get; set; }
        public string? ApproverThree { get; set; }
        public string? ApproverFour { get; set; }

        public string? Status { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public bool IsActive { get; set; }
    }
}


