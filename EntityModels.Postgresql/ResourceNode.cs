using System.ComponentModel.DataAnnotations;

namespace EntityModels.Postgresql;

public partial class ResourceNode: TerritoryEvent
{
    public int Capacity { get; set; }
    public int DurationSeconds { get; set; }
    [StringLength(50)] public string InstrumentType { get; set; } = null!;
    public int InstrumentRequiredLevel { get; set; }
    public int InstrumentExpectedLevel { get; set; } //  (x2 faster for level above and 4x slower for level below)

    public ICollection<TerritoryEventItem> TerritoryEventItems { get; set; } = null!;
    public ICollection<TerritoryEventProportion> TerritoryEventProportions { get; set; } = null!;
}