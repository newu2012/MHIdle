using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityModels.Postgresql;

[Table("Territory")]
public partial class Territory
{
    public Territory()
    {
        //  TODO add TerritoryActivities like: Hunting, Gathering and others 
        // TerritoryActivities = new HashSet<TerritoryActivity>();
    }

    [Key] [Column("id")] public int Id { get; set; } = 1;

    [StringLength(50)] public string Name { get; set; } = null!;
    [StringLength(1000)] public string Description { get; set; } = null!;

    public int? RegionId { get; set; }
    [ForeignKey("RegionId")] public virtual Region? Region { get; set; } = null!;

    public ICollection<ResourceNodeEventProportion> ResourceNodeEventProportions { get; set; }
}