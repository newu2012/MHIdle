using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityModels.Postgresql;

[Table("TerritoryEvent")]
public abstract partial class TerritoryEvent
{
    [Key] public string Name { get; set; } = null!;
    [StringLength(1000)] public string Description { get; set; } = null!;
}