using System;

namespace Permit_to_work.Models
{
    public class ConfinedSpacePermit
    {
        public int Id { get; set; }
        public string Unit { get; set; }
        public string Contractor { get; set; }
        public string Location { get; set; }
        public int NoOfWorkmen { get; set; }

        public DateTime StartDate { get; set; }
        public TimeSpan StartTime { get; set; }
        public DateTime EndDate { get; set; }
        public TimeSpan EndTime { get; set; }

        // WORK DETAILS
        public string WorkDescription { get; set; }
        public string ToolsEquipment { get; set; }

        // RISKS
        public bool RiskOxygen { get; set; }
        public bool RiskExplosion { get; set; }
        public bool RiskFume { get; set; }
        public bool RiskNoise { get; set; }
        public bool RiskHot { get; set; }
        public bool RiskFire { get; set; }
        public bool RiskDust { get; set; }
        public bool RiskVibration { get; set; }
        public string RiskOther { get; set; }

        // DOCUMENTS
        public bool JSA { get; set; }
        public bool RiskAssessment { get; set; }
        public string DocumentOther { get; set; }

        // PRECAUTION
        public string Precaution { get; set; }

        // ATMOSPHERE
        public string OxygenLevel { get; set; }
        public string ExplosiveLevel { get; set; }
        public string COLevel { get; set; }
        public string H2SLevel { get; set; }

        // YES/NO
        public string AtmosphereDone { get; set; }
        public string Ventilation { get; set; }
        public string Communication { get; set; }
        public string EmergencyProcedure { get; set; }
        public string HotWorkRequired { get; set; }
        public string Lockout { get; set; }
        public string EmergencyTeam { get; set; }

        // CONTACT
        public string Contact1 { get; set; }
        public string Contact2 { get; set; }
        public string Contact3 { get; set; }

        public string Other { get; set; }

        // INSPECTION
        public string FireExtinguisherType { get; set; }
        public string FireExtinguisherQty { get; set; }
        public string FireExtinguisherSize { get; set; }

        public bool Access { get; set; }
        public bool WarningSign { get; set; }
        public bool Lighting { get; set; }
        public bool LogBook { get; set; }
        public bool GasDetector { get; set; }
        public string InspectionOther { get; set; }

        // PPE
        public bool Helmet { get; set; }
        public bool SafetyShoes { get; set; }
        public bool Gloves { get; set; }
        public bool EarPlug { get; set; }
        public bool Goggles { get; set; }
        public bool Vest { get; set; }
        public bool GasMask { get; set; }
        public bool Harness { get; set; }
        public bool Gumboot { get; set; }
        public bool DustMask { get; set; }
        public string PPEOther { get; set; }
        // BASIC
        public int? Workmen { get; set; }

 
        public string Tools { get; set; }

    
        public string DocOther { get; set; }

     
        public string VentilationDetails { get; set; }

     
        public string CommunicationDetails { get; set; }

        public string EmergencyAware { get; set; }
      
        public string LOTOFollowed { get; set; }

        // PPE
        public bool Shoes { get; set; }

        // SUSPENSION
        public string SuspendName { get; set; }
        public DateTime? SuspendDate { get; set; }



        // INSURANCE
        public bool WC { get; set; }
        public bool ESI { get; set; }

        // SIGNATURE
        public string ReceiverName { get; set; }
        public DateTime? ReceiverDate { get; set; }

        public string IssuerName { get; set; }
        public DateTime? IssuerDate { get; set; }

        public string SuspensionName { get; set; }
        public DateTime? SuspensionDate { get; set; }
    }
}