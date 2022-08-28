namespace EntityModels.Postgresql;

public partial class Monster : TerritoryEvent
{
    //  TODO Add health
    //  TODO Add attacks
    //  TODO Add loot

    public ICollection<MonsterPart> MonsterParts { get; set; } = null!;
}