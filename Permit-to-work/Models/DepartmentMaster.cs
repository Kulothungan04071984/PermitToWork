using System.ComponentModel.DataAnnotations;

namespace Permit_to_work.Models
{
    public class DepartmentMaster
    {
        [Key]
        public int DepartmentId { get; set; }
        public string? DepartmentName { get; set; }
        public bool isActive { get; set; }
    }
}
