using System.ComponentModel.DataAnnotations;

namespace Permit_to_work.Models
{
    public class PermitTypeMaster
    {
        [Key]
        public int PermitTypeId { get; set; }
        public string? PermitTypeName { get; set; }
        public bool isActive { get; set; }
    }
}
