using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityModels.Postgresql;

[Table("TerritoryEvent")]
public class TerritoryEvent
{
    public TerritoryEvent() { }

    [Key] [Column("id")] public int Id { get; set; }
    [StringLength(50)] public string Name { get; set; } = null!;

    [StringLength(1000)] public string Description { get; set; } = null!;

    //  TODO Give this value in Territory and not save in TerritoryEvent?
    public double ProportionValue { get; set; } = 1;

    public ICollection<Territory> Territories { get; set; }
}