using System.ComponentModel.DataAnnotations;

namespace EntityModels.Postgresql;

public partial class Resource : Item
{
    [StringLength(50)] public string ResourceType { get; set; } = null!;
}