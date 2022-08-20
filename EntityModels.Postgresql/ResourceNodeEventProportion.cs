using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityModels.Postgresql;

[Table("ResourceNodeEventProportion")]
public partial class ResourceNodeEventProportion
{
    [Key] [Column("id")] public int Id { get; set; }
    public double ProportionValue { get; set; } = 1;

    public int TerritoryId { get; set; }
    [ForeignKey("TerritoryId")] public Territory Territory { get; set; } = null!;

    public int ResourceNodeEventId { get; set; }
    [ForeignKey("ResourceNodeEventId")] public ResourceNodeEvent ResourceNodeEvent { get; set; } = null!;
}