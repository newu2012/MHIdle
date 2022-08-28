using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityModels.Postgresql;

[Table("TerritoryEventProportion")]
public partial class TerritoryEventProportion
{
    [Key] [Column("id")] public int Id { get; set; }
    public double Value { get; set; } = 1;

    public string TerritoryName { get; set; } = null!;
    public Territory Territory { get; set; } = null!;

    public string TerritoryEventName { get; set; } = null!;
    public TerritoryEvent TerritoryEvent { get; set; } = null!;
}