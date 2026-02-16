using System.ComponentModel.DataAnnotations;

namespace Permit_to_work.Models
{
    public class ColdWorkPermitVM
    {
        [Key]
        public int Id { get; set; }

        public string Unit { get; set; }
        public string ContractorTeam { get; set; }
        public string Location { get; set; }
        public string NoOfWorkmen { get; set; }

        public DateTime StartDate { get; set; }
        public string StartTime { get; set; }
        public DateTime EndDate { get; set; }
        public string EndTime { get; set; }

        public string WorkDescription { get; set; }
        public string ToolsEquipment { get; set; }

        // Risks
        public bool RiskFallHeight { get; set; }
        public bool RiskWeather { get; set; }
        public bool RiskFlying { get; set; }
        public bool Equipment { get; set; }

        public bool Falling { get; set; }
        public bool Protruding { get; set; }
        public bool Tripping { get; set; }
        public bool Faulty { get; set; }

        public bool Noise { get; set; }
        public bool Heat { get; set; }
        public bool Vibration { get; set; }
        public bool Illumination { get; set; }
        // PPE
        public bool PPEHelmet { get; set; }
        public bool PPEShoes { get; set; }
        public bool PPEGloves { get; set; }

        // Insurance
        public bool InsuranceAvailable { get; set; }

        // Authorization
        public string ReceiverName { get; set; }
        public string IssuerName { get; set; }

        public DateTime CreatedOn { get; set; } = DateTime.Now;

        public bool IsActive { get; set; }
    }
}
