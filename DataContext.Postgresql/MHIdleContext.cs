using EntityModels.Postgresql;
using Microsoft.EntityFrameworkCore;

namespace DataContext.Postgresql;

public partial class MHIdleContext : DbContext
{
    public MHIdleContext() { }

    public MHIdleContext(DbContextOptions<MHIdleContext> options)
        : base(options) { }

    //  TODO sort variables alphabetically
    public virtual DbSet<Item> Items { get; set; } = null!;
    public virtual DbSet<Region> Regions { get; set; } = null!;
    public virtual DbSet<Territory> Territories { get; set; } = null!;
    public virtual DbSet<TerritoryEvent> TerritoryEvents { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var connectionVariables = Environment.GetEnvironmentVariables();
            optionsBuilder.UseNpgsql(
                $"Host={connectionVariables["POSTGRESQL_HOST"]};" +
                $"Port={connectionVariables["POSTGRESQL_PORT"]};" +
                $"Database={connectionVariables["POSTGRESQL_DATABASE"]};" +
                $"Username={connectionVariables["POSTGRESQL_USERNAME"]};" +
                $"Password={connectionVariables["POSTGRESQL_PASSWORD"]}");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Item>().Property(i => i.Id).ValueGeneratedNever();
        modelBuilder.Entity<Region>().Property(r => r.Id).ValueGeneratedNever();
        modelBuilder.Entity<Territory>().Property(t => t.Id).ValueGeneratedNever();
        modelBuilder.Entity<TerritoryEvent>().Property(te => te.Id).ValueGeneratedNever();

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}