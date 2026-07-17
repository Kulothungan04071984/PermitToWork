using Microsoft.AspNetCore.Mvc.Rendering;
using Permit_to_work.ViewModel;

namespace Permit_to_work.Models
{
    public class PermitDetails
    {
        public List<PermitDashboardVM> PermitDetailsList { get; set; }

        public PermitDashboardVM objPermitDetails { get; set; }

        public int SelectedPermitTypeId { get; set; }
        public List<SelectListItem> PermitTypes { get; set; }

        public int SelectedDepartmentId { get; set; }
        public List<SelectListItem> Departments { get; set; }
        public int SelectedApproverId { get; set; }
        public List<SelectListItem> Approvers { get; set; }
        public int SelectedUnitId { get; set; }
        public List<SelectListItem> Units { get; set; }
    }
}
