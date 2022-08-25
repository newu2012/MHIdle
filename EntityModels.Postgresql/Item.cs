using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityModels.Postgresql;

[Table("Item")]
public abstract partial class Item
{
    public Item() { }

    [Key] [Column("id")] public int Id { get; set; }
    [StringLength(50)] public string Type { get; set; } = null!;
    [StringLength(50)] public string Name { get; set; } = null!;
    [StringLength(1000)] public string Description { get; set; } = null!;
    public int Rarity { get; set; } = 1;
    public int Value { get; set; } = 1;
    [StringLength(1000)] public string ImagePath { get; set; } = null!;
    public int MaximumInInventory { get; set; } = 10;
    public int MaximumInStorage { get; set; } = 10000;
}