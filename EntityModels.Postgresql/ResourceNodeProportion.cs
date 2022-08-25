using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityModels.Postgresql;

[Table("ResourceNodeProportion")]
public partial class ResourceNodeProportion
{
    [Key] [Column("id")] public int Id { get; set; }
    public double Value { get; set; } = 1;

    public string TerritoryName { get; set; } = null!;
    public Territory Territory { get; set; } = null!;

    public string ResourceNodeEventName { get; set; } = null!;
    public ResourceNodeEvent ResourceNodeEvent { get; set; } = null!;
}