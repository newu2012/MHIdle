using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityModels.Postgresql;

[Table("RecipeMaterial")]
public partial class RecipeMaterial
{
    [Key] [Column("id")] public int Id { get; set; }
    public int RecipeId { get; set; }
    public Recipe Recipe { get; set; } = null!;
    [ForeignKey("Name")] public string ItemName { get; set; } = null!;
    public Item Item { get; set; } = null!;
    public int Quantity { get; set; }
}