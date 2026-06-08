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
        public DateTime StartDate { get; set; }
        public string StartTime { get; set; }
        public DateTime EndDate { get; set; }
        public string ExpectedCompletionTime { get; set; }

        public bool TruckMounted { get; set; }
        public bool HydraCrane { get; set; }
        public bool OverheadCrane { get; set; }

        public string LoadWeight { get; set; }
        public string LoadDimension { get; set; }
        public string LoadQuantity { get; set; }

        public bool AttachJSA { get; set; }

        public bool Toppling { get; set; }
        public bool FallingObjects { get; set; }
        public bool Overload { get; set; }
        public bool AdverseWeather { get; set; }
        public string OtherRisk { get; set; }

        public bool Helmet { get; set; }
        public bool SafetyShoes { get; set; }
        public bool ReflectiveVest { get; set; }
        public bool WC { get; set; }
        public bool ESI { get; set; }


        public string ReceiverName { get; set; }
        public DateTime ReceiverDate { get; set; }
        public string IssuerName { get; set; }
        public DateTime IssuerDate { get; set; }

        public string SuspensionName { get; set; }
        public string SuspensionSignatureDate { get; set; }
    }
}