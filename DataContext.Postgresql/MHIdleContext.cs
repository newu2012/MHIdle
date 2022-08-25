using EntityModels.Postgresql;
using Microsoft.EntityFrameworkCore;

namespace DataContext.Postgresql;

public partial class MHIdleContext : DbContext
{
    public MHIdleContext() { }

    public MHIdleContext(DbContextOptions<MHIdleContext> options)
        : base(options) { }

    //  TODO sort variables alphabetically

    //  Items
    public virtual DbSet<Resource> Resources { get; set; } = null!;
    public virtual DbSet<Instrument> Instruments { get; set; } = null!;

    //  Regions
    public virtual DbSet<Region> Regions { get; set; } = null!;
    public virtual DbSet<Territory> Territories { get; set; } = null!;
    public virtual DbSet<ResourceNodeEvent> ResourceNodeEvents { get; set; } = null!;
    public virtual DbSet<ResourceNodeItem> ResourceNodeItems { get; set; } = null!;
    public virtual DbSet<ResourceNodeProportion> ResourceNodeProportions { get; set; } = null!;

    //  Craft
    public virtual DbSet<Recipe> Recipe { get; set; } = null!;
    public virtual DbSet<RecipeMaterial> RecipeMaterial { get; set; } = null!;

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
        modelBuilder.Entity<ResourceNodeItem>().Property(rni => rni.Id).ValueGeneratedNever();
        modelBuilder.Entity<ResourceNodeProportion>().Property(rnp => rnp.Id).ValueGeneratedNever();
        modelBuilder.Entity<RecipeMaterial>().Property(rm => rm.Id).ValueGeneratedNever();

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}