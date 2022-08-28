using System.ComponentModel.DataAnnotations;

namespace EntityModels.Postgresql;

public partial class Monster : TerritoryEvent
{
    [StringLength(50)] public string Type { get; set; } = null!;
    
    //  TODO Add health
    //  TODO Add attacks
    //  TODO Add loot

    public ICollection<MonsterPart> MonsterParts { get; set; } = null!;
    public ICollection<TerritoryEventItem> TerritoryEventItems { get; set; } = null!;
    public ICollection<TerritoryEventProportion> TerritoryEventProportions { get; set; } = null!;
}