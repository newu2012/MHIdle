using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityModels.Postgresql;

[Table("Recipe")]
public partial class Recipe
{
    [Key] public string Name { get; set; } = null!;
    [StringLength(50)] public string Type { get; set; } = null!;
    public string ItemName { get; set; } = null!;
    public Item Item { get; set; } = null!;
    public int DurationSeconds { get; set; }
    public ICollection<RecipeMaterial> RecipeMaterials { get; set; } = null!;
    [StringLength(50)] public string InstrumentType { get; set; } = null!;
    public int InstrumentRequiredLevel { get; set; }
    public int InstrumentExpectedLevel { get; set; } //  (x2 faster for level above and 4x slower for level below)
}