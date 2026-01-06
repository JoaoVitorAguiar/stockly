using Microsoft.EntityFrameworkCore;
using Stockly.Core.Entities;
using Stockly.Core.Enums;

namespace Stockly.Infra.Context;

public class StocklyDbContext(DbContextOptions<StocklyDbContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }
    public DbSet<Category> Categories { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasPostgresEnum<Role>();
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }
}