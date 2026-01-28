using Microsoft.EntityFrameworkCore;
using Permit_to_work.Models;

namespace Permit_to_work.Data
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
       : base(options)
        {
        }

        public DbSet<ColdWorkPermitVM> ColdWorkPermits { get; set; }
    }
}
