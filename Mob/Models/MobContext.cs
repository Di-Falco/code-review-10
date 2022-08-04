using Microsoft.EntityFrameworkCore;

namespace Mob.Models
{
  public class MobContext : DbContext //DbContext is DataBase
  {
    public DbSet<Criminal> Criminals { get; set; }
    public DbSet<Job> Jobs { get; set; }
    public DbSet<CriminalJob> CriminalJob { get; set; }//Each DbSet we've included will become a table in our database

    public MobContext(DbContextOptions options) : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseLazyLoadingProxies();
    }
  }
}