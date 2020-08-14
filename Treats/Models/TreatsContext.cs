using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Treats.Models
{
  public class TreatsContext : IdentityDbContext<ApplicationUser>
  {
    public virtual DbSet<Flavor> Flavors { get; set; }
    public DbSet<Treat> Treats { get; set; }
    public DbSet<FlavorTreat> FlavorTreat {get; set; }
    public DbSet<CopyApplicationUser> CopyApplicationUser { get; set; }

    public TreatsContext(DbContextOptions options) : base(options) { }
  }
}