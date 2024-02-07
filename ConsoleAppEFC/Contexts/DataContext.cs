using ConsoleAppEFC.Entities;
using Microsoft.EntityFrameworkCore;

namespace ConsoleAppEFC.Contexts;

internal class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    public DbSet<AddressEntity> Addresses { get; set; }
    public DbSet<CategoryEntity> Categories { get; set; }
    public DbSet<CustomerEntity> Customers { get; set; }
    public DbSet<ProductEntity> Products { get; set; }
    public DbSet<RoleEntity> Roles { get; set; }
}
