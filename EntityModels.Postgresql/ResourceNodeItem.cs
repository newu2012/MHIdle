﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityModels.Postgresql;

[Table("ResourceNodeItem")]
public partial class ResourceNodeItem
{
    [Key] [Column("id")] public int Id { get; set; }

    public int ItemId { get; set; }
    public Item Item { get; set; } = null!;
}