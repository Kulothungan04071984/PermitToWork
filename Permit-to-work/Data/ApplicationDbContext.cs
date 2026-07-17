using Registration.Models;
using Microsoft.EntityFrameworkCore;
using Permit_to_work.Models;
using Permit_to_work.ViewModel;

namespace Permit_to_work.Data
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
       : base(options)
        {
        }

        public DbSet<ColdWorkPermit> ColdWorkPermits { get; set; }
        public DbSet<HotWorkPermit> HotWorkPermits { get; set; }
        public DbSet<LiftingOperationPermit> LiftingOperationPermits { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<employee> Employees { get; set; }

        public DbSet<WorkAtHeightPermit> WorkAtHeightPermits { get; set; }
        public DbSet<ElectricalIsolationPermit> ElectricalIsolationPermits { get; set; }

        public DbSet<PermitMaster> PermitMasters { get; set; }
        public DbSet<ConfinedSpacePermit> ConfinedSpacePermits { get; set; }

        public DbSet<DepartmentMaster> DepartmentMasters { get; set; }

        public DbSet<UnitMaster> UnitMasters { get; set; }

        public DbSet<ApproverMaster> ApproverMasters { get; set; }

        public DbSet<ApprovalStructure> ApprovalStructures { get; set; }

        public DbSet<PermitTypeMaster> PermitTypeMasters { get; set; }

        public DbSet<Login> Logins { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<PermitDashboardVM>();
        }

    }
}
