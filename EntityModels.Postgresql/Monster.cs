using System.ComponentModel.DataAnnotations;

namespace EntityModels.Postgresql;

public partial class Monster : TerritoryEvent
{
    [StringLength(1000)] public string IconPath { get; set; } = null!;
    public int MaximumHealth { get; set; }
    public int StartingHealth { get; set; }
    //  TODO Add actions

    public ICollection<MonsterPart> MonsterParts { get; set; } = null!;
}