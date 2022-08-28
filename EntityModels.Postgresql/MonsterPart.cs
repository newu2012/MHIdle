using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityModels.Postgresql;

[Table("MonsterPart")]
public partial class MonsterPart
{
    [Key] public string PartName { get; set; } = null!;
    public double MaximumHealth { get; set; }
    public double CurrentHealth { get; set; }
    public string MonsterName { get; set; } = null!;
}