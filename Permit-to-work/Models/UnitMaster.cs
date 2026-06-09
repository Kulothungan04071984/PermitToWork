using System.ComponentModel.DataAnnotations;

namespace Permit_to_work.Models
{
    public class UnitMaster
    {
        [Key]
        public int UnitId { get; set; }
        public string? UnitName { get; set; }
        public bool isActive { get; set; }
    }
}
