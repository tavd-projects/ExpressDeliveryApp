namespace ExpressDeliveryApp.Domain;

public class Cargo : BaseEntity
{
    public decimal WeightKg { get; set; }
    public string Description { get; set; }
}