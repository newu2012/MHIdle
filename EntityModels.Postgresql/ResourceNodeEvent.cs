using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityModels.Postgresql;

[Table("ResourceNodeEvent")]
public partial class ResourceNodeEvent : ITerritoryEvent
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public int Capacity { get; set; }
    public int DurationSeconds { get; set; }
    [StringLength(50)] public string InstrumentType { get; set; } = null!;
    public int InstrumentRequiredLevel { get; set; }
    public int InstrumentExpectedLevel { get; set; } //  (x2 faster for level above and 4x slower for level below)

    //  Resources and other types of items that can be found in this node through <item-id>
    public ICollection<ResourceNodeItem> ResourceNodeItems { get; set; } = null!;
    public ICollection<ResourceNodeProportion> ResourceNodeProportions { get; set; } = null!;
}