using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Permit_to_work.Models
{
    public class ColdWorkPermitVM
    {
        [Key]
        public int Id { get; set; }

        // Basic Details — required fields
        public string? Unit { get; set; }
        public string? ContractorTeam { get; set; }
        public string? Location { get; set; }
        public string? NoOfWorkmen { get; set; }

        // Dates — nullable to avoid binding failure
        public DateTime? StartDate { get; set; }
        public string? StartTime { get; set; }
        public DateTime? EndDate { get; set; }
        public string? EndTime { get; set; }

        // Work
        public string? WorkDescription { get; set; }
        public string? ToolsEquipment { get; set; }

        // Risk Identification
        public bool RiskFallHeight { get; set; }
        public bool RiskWeather { get; set; }
        public bool RiskFlying { get; set; }
        public bool RiskEquipment { get; set; }
        public bool RiskFalling { get; set; }
        public bool RiskProtruding { get; set; }
        public bool RiskTripping { get; set; }
        public bool RiskFaulty { get; set; }
        public bool RiskNoise { get; set; }
        public bool RiskHeat { get; set; }
        public bool RiskVibration { get; set; }
        public bool RiskIllumination { get; set; }
        public string? RiskOther { get; set; }       // ← nullable

        // Documents
        public bool DocJSA { get; set; }
        public bool DocRiskAssessment { get; set; }
        public string? DocOther { get; set; }        // ← nullable

        // Precaution & Tools

        //public string? Precaution { get; set; }      // ← nullable (radio)
        public string? ToolsTested { get; set; }     // ← nullable (radio)

        // Hazards

        //public bool HazardWorkAtHeight { get; set; }
        //public bool HazardScaffolding { get; set; }
        //public bool HazardToolEquipment { get; set; }
        //public bool HazardChemical { get; set; }
        //public bool HazardElectrical { get; set; }
        //public bool HazardLifting { get; set; }
        //public bool HazardHotSurface { get; set; }
        //public bool HazardDust { get; set; }
        //public string? HazardNA { get; set; }        // ← nullable (radio)

        // Associated Permits
        public bool PermitHotWork { get; set; }
        public bool PermitWorkAtHeight { get; set; }
        public bool PermitExcavation { get; set; }
        public bool PermitElectrical { get; set; }
        public bool PermitConfinedSpace { get; set; }
        public string? PermitOther { get; set; }     // ← nullable
        public string? PermitAssociated { get; set; }// ← nullable (radio)

        // Insurance
        public bool WC { get; set; }
        public bool ESI { get; set; }

        // Inspected Areas
        public bool InspectAccess { get; set; }
        public bool InspectDangerSign { get; set; }
        public bool InspectLighting { get; set; }
        public bool InspectSafetyBarriers { get; set; }
        public bool InspectHandTools { get; set; }
        public string? InspectOther { get; set; }    // ← nullable
        public string? InspectedNA { get; set; }     // ← nullable (radio)

        // PPE
        public bool PPEHelmet { get; set; }
        public bool PPEShoes { get; set; }
        public bool PPEGloves { get; set; }
        public bool PPEGoggles { get; set; }
        public bool PPEDustMask { get; set; }
        public bool PPEEarPlugs { get; set; }
        public bool PPEReflectiveVest { get; set; }
        public bool PPEHarness { get; set; }
        public string? PPEOther { get; set; }        // ← nullable
        public string? PPENA { get; set; }           // ← nullable (radio)

        // Authorization
        public string? ReceiverName { get; set; }
        public string? ReceiverDate { get; set; }
        public string? IssuerName { get; set; }
        public string? IssuerDate { get; set; }

        // Suspension
        public string? Name { get; set; }
        public DateTime? SuspensionDate { get; set; }// ← nullable
            
        public string? ApproverOne { get; set; }     // ← nullable
        public string? ApproverTwo { get; set; }     // ← nullable
        public string? ApproverThree { get; set; }   // ← nullable
        public string? ApproverFour { get; set; }    // ← nullable

        // Meta — set by server, not form
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public bool IsActive { get; set; }
    }
}