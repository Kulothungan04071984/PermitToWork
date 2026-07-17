using System.ComponentModel.DataAnnotations;

namespace Permit_to_work.Models
{
    public class ApproverMaster
    {
        [Key]
        public int ApproverId { get; set; }
        public string? ApproverName { get; set; }
        public string? ApproverEmail { get; set; }
        public int UnitId { get; set; }
        public int DepartmentId { get; set; }
        public string? LevelIIApprover { get; set; }
        public string? LevelIIIApprover { get; set; }
       public bool isActive { get; set; }
    }
}
