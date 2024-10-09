using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProjectApplication.Areas.Identity.Data;

namespace ProjectApplication.Data;

public class ProjectApplicationIdentityContext : IdentityDbContext<ProjectApplicationUser>
{
    public ProjectApplicationIdentityContext(DbContextOptions<ProjectApplicationIdentityContext> options)
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
}
