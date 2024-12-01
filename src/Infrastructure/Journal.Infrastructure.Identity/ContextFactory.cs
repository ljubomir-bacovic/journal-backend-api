using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;

namespace Journal.Infrastructure.Identity;

public class ContextFactory : IDesignTimeDbContextFactory<JournalContext>
{
    public JournalContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<JournalContext>();

        // change if needed
        optionsBuilder.UseSqlServer("Server=MSI;Database=Journal;Trusted_Connection=True;");

        return new JournalContext(optionsBuilder.Options);

    }
}
