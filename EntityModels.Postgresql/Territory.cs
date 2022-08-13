using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityModels.Postgresql;

[Table("Territory")]
public partial class Territory
{
    public Territory()
    {
        //  TODO add TerritoryActivities like: Hunting, Gathering and others 
        // TerritoryActivities = new HashSet<TerritoryActivity>();
    }

    [Key]
    [Column("id")]
    [StringLength(20)]
    public string TerritoryId { get; set; } = null!;

    [StringLength(50)] public string TerritoryDescription { get; set; } = null!;
    [Column("RegionID")] public int RegionId { get; set; }

    [ForeignKey("RegionId")]
    [InverseProperty("Territories")]
    public virtual Region Region { get; set; } = null!;

    // [ForeignKey("TerritoryId")]
    // [InverseProperty("Territories")]
    // public virtual ICollection<TerritoryActivity> TerritoryActivities { get; set; }
}