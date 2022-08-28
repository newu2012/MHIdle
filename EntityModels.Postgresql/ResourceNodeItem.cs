using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityModels.Postgresql;

[Table("ResourceNodeItem")]
public partial class ResourceNodeItem
{
    [Key] [Column("id")] public int Id { get; set; }
    public double Value { get; set; } = 1;

    public string ItemName { get; set; } = null!;
    public Item Item { get; set; } = null!;
    public int MinimumQuantity { get; set; }
    public int MaximumQuantity { get; set; }

    public string ResourceNodeName { get; set; } = null!;
    public ResourceNode ResourceNode { get; set; } = null!;
}