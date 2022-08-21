using System.ComponentModel.DataAnnotations.Schema;

namespace EntityModels.Postgresql;

[Table("ResourceNodeEvent")]
public partial class ResourceNodeEvent : ITerritoryEvent
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public int Capacity { get; set; }

    //  Resources and other types of items that can be found in this node through <item-id>
    public ICollection<ResourceNodeItem> ResourceNodeItems { get; set; } = null!;
    public ICollection<ResourceNodeProportion> ResourceNodeProportions { get; set; } = null!;
}