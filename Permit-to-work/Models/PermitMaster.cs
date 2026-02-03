namespace Permit_to_work.Models
{
    public class PermitMaster
    {
        public int PermitId { get; set; }

        public string PermitNumber { get; set; }
        public string PermitType { get; set; }
        // Work, HotWork, Height, Lifting, Electrical

        public string Unit { get; set; }
        public string Location { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public string Status { get; set; }
        // Issued, PendingSafety, PendingElectrical, Approved, Rejected, Closed, Extended

        public int CreatedByUserId { get; set; }

        public DateTime CreatedOn { get; set; } = DateTime.Now;

//        4. LOGIN → SESSION ROLE SETUP
//HttpContext.Session.SetString("UserRole", user.Role.ToString());
//        HttpContext.Session.SetInt32("UserId", user.Id);
    }
}
