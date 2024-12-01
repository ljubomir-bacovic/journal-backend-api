using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Journal.Domain.Identity;

public class IdentityContext : IdentityDbContext<IdentityUser>
{
    public IdentityContext(DbContextOptions<IdentityContext> options) :
        base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    }
}