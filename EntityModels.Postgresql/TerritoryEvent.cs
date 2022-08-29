using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityModels.Postgresql;

[Table("TerritoryEvent")]
public abstract partial class TerritoryEvent
{
    [Key] public string Name { get; set; } = null!;
    [StringLength(50)] public string Type { get; set; } = null!;
    [StringLength(1000)] public string Description { get; set; } = null!;
    [StringLength(1000)] public string? IconPath { get; set; }
    public int Capacity { get; set; }
    public int DurationSeconds { get; set; }
    [StringLength(50)] public string InstrumentType { get; set; } = null!;
    public int InstrumentRequiredLevel { get; set; }
    public int InstrumentExpectedLevel { get; set; } //  (x2 faster for level above and 4x slower for level below)

    public ICollection<TerritoryEventItem> TerritoryEventItems { get; set; } = null!;
    public ICollection<TerritoryEventProportion> TerritoryEventProportions { get; set; } = null!;
}