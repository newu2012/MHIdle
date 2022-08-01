using EntityModels.Postgresql;
using Microsoft.EntityFrameworkCore;

namespace DataContext.Postgresql;

public partial class MHIdleContext : DbContext
{
    public MHIdleContext() { }

    public MHIdleContext(DbContextOptions<MHIdleContext> options)
        : base(options) { }

    //  TODO sort variables alphabetically
    public virtual DbSet<Region> Regions { get; set; } = null!;
    public virtual DbSet<Territory> Territories { get; set; } = null!;

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
        modelBuilder.Entity<Region>(entity =>
        {
            entity.HasKey(e => e.RegionId);

            entity.Property(e => e.RegionId).ValueGeneratedNever();

            entity.Property(e => e.RegionDescription).IsFixedLength();
        });

        modelBuilder.Entity<Territory>(entity =>
        {
            entity.HasKey(e => e.TerritoryId);

            entity.Property(e => e.TerritoryDescription).IsFixedLength();

            entity.HasOne(d => d.Region)
                .WithMany(p => p.Territories)
                .HasForeignKey(d => d.RegionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Territories_Region");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}