using Journal.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Journal.Domain.Data;

public class JournalContext : IdentityDbContext<IdentityUser>
{
    public required DbSet<ToDoItem> ToDoItems { get; set; }


    public JournalContext(DbContextOptions<JournalContext> options) : base(options)
    {

    }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<ToDoItem>().HasKey(e => e.Id);
        builder.Entity<ToDoItem>().ToTable(nameof(ToDoItem));

        base.OnModelCreating(builder);
    }

}
