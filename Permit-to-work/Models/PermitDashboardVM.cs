namespace Permit_to_work.Models
{
    public class PermitDashboardVM
    {
        public int PermitId { get; set; }
        public string PermitType { get; set; }   
        public string Unit { get; set; }
        public string Location { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Status { get; set; }
    }
}
