using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityModels.Postgresql;

[Table("Region")]
public partial class Region
{
    public Region() { }

    [Key] [Column("id")] public int Id { get; set; } = 1;

    [StringLength(50)] public string Name { get; set; } = null!;
    [StringLength(1000)] public string Description { get; set; } = null!;

    public virtual ICollection<Territory> Territories { get; set; }
}