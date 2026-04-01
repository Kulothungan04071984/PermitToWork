namespace Permit_to_work.Models
{
    public class DashboardVM
    {
        public int TotalPermits { get; set; }
        public int ActivePermits { get; set; }
        public int ClosedPermits { get; set; }

        public List<PermitMaster> PermitList { get; set; }
    }
}
