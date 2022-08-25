using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityModels.Postgresql;

[Table("Territory")]
public partial class Territory
{
    [Key] public string Name { get; set; } = null!;
    [StringLength(1000)] public string Description { get; set; } = null!;
    public int DurationSecondsExploreOnEnter { get; set; }
    public int DurationSecondsExploreInTerritory { get; set; }
    [StringLength(50)] public string InstrumentType { get; set; } = null!;
    public int InstrumentRequiredLevel { get; set; }
    public int InstrumentExpectedLevel { get; set; } //  (x2 faster for level above and 4x slower for level below)

    public string RegionName { get; set; } = null!;
    public virtual Region Region { get; set; } = null!;

    public ICollection<ResourceNodeProportion> ResourceNodeProportions { get; set; } = null!;
}