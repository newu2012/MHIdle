﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityModels.Postgresql;

[Table("Region")]
public partial class Region
{
    public Region()
    {
        Territories = new HashSet<Territory>();
    }

    [Key] [Column("id")] public int RegionId { get; set; }
    [StringLength(50)] public string RegionDescription { get; set; } = null!;

    [InverseProperty("Region")] public virtual ICollection<Territory> Territories { get; set; }
}