﻿using System.ComponentModel.DataAnnotations;

namespace EntityModels.Postgresql;

public partial class Monster : TerritoryEvent
{
    public int MaximumHealth { get; set; }
    public int StartingHealth { get; set; }
    //  TODO Add actions

    public ICollection<MonsterPart> MonsterParts { get; set; } = null!;
}