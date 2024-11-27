using Entity.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OnlineAdmissionPortal.Models;

namespace OnlineAdmissionPortal.Data;

public class OnlineAdmissionPortalContext : IdentityDbContext<ApplicationUser>
{
    public OnlineAdmissionPortalContext(DbContextOptions<OnlineAdmissionPortalContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }

public DbSet<OnlineAdmissionPortal.Models.InstituteModel> InstituteModel { get; set; } = default!;
}
