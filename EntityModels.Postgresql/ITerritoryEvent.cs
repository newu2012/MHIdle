using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityModels.Postgresql;

public interface ITerritoryEvent
{
    [Key] [Column("id")] public int Id { get; set; }
    [StringLength(50)] public string Name { get; set; }
    [StringLength(1000)] public string Description { get; set; }
}