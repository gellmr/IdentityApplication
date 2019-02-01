using gellmvc.Domain.Entities;
using System.Collections.Generic;
using System.Data.Entity;

namespace gellmvc.Domain.Concrete
{
  public class EFDbContext : DbContext
  {
    // see http://www.entityframeworktutorial.net/code-first/database-initialization-in-code-first.aspx

    public EFDbContext(): base()
    {
      Database.SetInitializer(new MigrateDatabaseToLatestVersion<EFDbContext, Migrations.Configuration>());
    }

    public DbSet<Product> Products { get; set; }
    public DbSet<UserAddress> UserAddresses { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderedProduct> OrderedProducts { get; set; }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);
    }
  }
}
