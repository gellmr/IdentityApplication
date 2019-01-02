using gellmvc.Domain.Entities;
using System.Data.Entity;

namespace gellmvc.Domain.Concrete
{
  public class EFDbContext : DbContext
  {
    public DbSet<Product> Products { get; set; }
  }
}
