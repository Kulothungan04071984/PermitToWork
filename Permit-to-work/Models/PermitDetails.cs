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
<<<<<<< HEAD
=======

        public string FirstApproval { get; set; }

        public string SecondApproval { get; set; }

        public string ThirdApproval { get; set; }

        public string FourthApproval { get; set; }

        public string FirstApprovalStatus { get; set; }

        public string SecondApprovalStatus { get; set; }

        public string ThirdApproverStatus { get; set; }

        public string FourthApprovaStatus { get; set; }
>>>>>>> faccccd7e844f04b57a176035fe543f761ff19d4
    }
}
