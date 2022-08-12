using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityModels.Postgresql;

[Table("Resource")]
public partial class Resource
{
    public Resource() { }

    [Key] [Column("ResourceID")] public int ResourceId { get; set; }
    [StringLength(50)] public string ResourceType { get; set; } = null!;
    [StringLength(50)] public string ResourceName { get; set; } = null!;
    [StringLength(1000)] public string ResourceDescription { get; set; } = null!;
    public int ResourceRarity { get; set; } = 1;
    public int ResourceValue { get; set; } = 1;
    [StringLength(1000)] public string ResourceImagePath { get; set; } = null!;
    public int ResourceMaximumInInventory { get; set; } = 10;
    public int ResourceMaximumInStorage { get; set; } = 10000;
}