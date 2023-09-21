namespace ExpressDeliveryApp.Domain;

public class Ticket : BaseEntity
{
    public string CustomerName { get; set; }
    public TicketStatus Status { get; set; }
    public string? CancelReason { get; set; }

    public decimal WeightKg { get; set; }
    public string Description { get; set; }

    public DateTime СargoСollectionTime { get; set; }
}