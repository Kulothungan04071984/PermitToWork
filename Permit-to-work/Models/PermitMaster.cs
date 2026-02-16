namespace Permit_to_work.Models
{
    public class PermitMaster
    {
        public int Id { get; set; }

        public string PermitNumber { get; set; }

        public string PermitType { get; set; }
        // Cold Work / Hot Work / Lifting / Height / Electrical

        public string Unit { get; set; }
        public string Location { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public string Status { get; set; }
        // Draft / PendingSafety / PendingElectrical / Approved / Closed

        public bool IsActive { get; set; } = true;

        public DateTime CreatedOn { get; set; } = DateTime.Now;

        public int CreatedByUserId { get; set; }
        public AppUser CreatedBy { get; set; }
    }
}
