namespace Permit_to_work.Models
{
    public class PermitMaster
    {
        public int Id { get; set; }

        public string? PermitNumber { get; set; }

        public string? PermitType { get; set; }

        // Cold Work / Hot Work / Lifting / Height / Electrical

        public string? Unit { get; set; }
        public string? Location { get; set; }

        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public string? ApproverOne { get; set; }
        public string? ApproverTwo { get; set; }
        public string? ApproverThree { get; set; }
        public string? ApproverFour { get; set; }

        public string FirstApproverStatus { get; set; } = string.Empty;

        public string? SecondApproverStatus { get; set; } = string.Empty;

        public string? ThirdApproverStatus { get; set; } = string.Empty;

        public string? FourthApproverStatus { get; set; } = string.Empty;

        public string? Status { get; set; }

        // Draft / PendingSafety / PendingElectrical / Approved / Closed

        public bool IsActive { get; set; } = true;

        public DateTime CreatedOn { get; set; } = DateTime.Now;

        public string? CreatedByUserId { get; set; }
        public AppUser CreatedBy { get; set; }

        //public int PermitDashBoardId { get; set; }

    }
}
