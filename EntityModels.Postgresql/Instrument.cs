using System.ComponentModel.DataAnnotations;

namespace EntityModels.Postgresql;

public partial class Instrument : Item
{
    [StringLength(50)] public string InstrumentType { get; set; } = null!;
    public int InstrumentLevel { get; set; } = 1;
    public double ChanceToBreak { get; set; } = 0.2;
}