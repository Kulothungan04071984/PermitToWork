using System.ComponentModel.DataAnnotations;

namespace Permit_to_work.Models
{
    public class ApprovalStructure
    {
        [Key]
        public int ApprovalId { get; set; }
        public string? Unit { get; set; }
        public string? ContractorTeam { get; set; }
        public string? Location { get; set; }
        public int NoOfWorkmen { get; set; }
        public DateTime StartDate { get; set; }
        public TimeSpan StartTime { get; set; }
        public DateTime EndDate { get; set; }
        public TimeSpan EndTime { get; set; }
        public string? WorkDescription { get; set; }
        public string? ToolsEquipment { get; set; }
        public bool RiskFallHeight { get; set; }
        public bool RiskWeather { get; set; }
        public bool RiskFlying { get; set; }
        public bool PPEHelmet { get; set; }
        public bool PPEShoes { get; set; }
        public bool PPEGloves { get; set; }
        public string? ReceiverName { get; set; }
        public string? IssuerName { get; set; }
    }
}
