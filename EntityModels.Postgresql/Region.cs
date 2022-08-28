using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityModels.Postgresql;

[Table("Region")]
public partial class Region
{
    [Key] public string Name { get; set; } = null!;
    [StringLength(1000)] public string Description { get; set; } = null!;
    public int Order { get; set; }

    public virtual ICollection<Territory> Territories { get; set; } = null!;
}