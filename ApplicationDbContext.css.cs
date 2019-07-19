using Microsoft.EntityFrameworkCore;

namespace api
{
  public class ApplicationDbContext : DbContext
  {
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    { }

    public DbSet<JournalLog> JournalLogs { get; set; }
  }
}