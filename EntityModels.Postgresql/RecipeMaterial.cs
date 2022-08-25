using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityModels.Postgresql;

[Table("RecipeMaterial")]
public partial class RecipeMaterial
{
    [Key] [Column("id")] public int Id { get; set; }
    public string RecipeName { get; set; } = null!;
    public Recipe Recipe { get; set; } = null!;
    public string ItemName { get; set; } = null!;
    public Item Item { get; set; } = null!;
    public int Quantity { get; set; }
}