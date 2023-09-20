namespace ExpressDeliveryApp.Domain;

public class Ticket : BaseEntity
{
    public Guid CustomerId { get; set; }
    public Customer Customer { get; set; }
    
    public TicketStatus Status { get; set; }
    public string? CancelReason { get; set; }
    
    public Guid CargoId { get; set; }
    public Cargo Cargo { get; set; }
    
    public DateTime СargoСollectionTime { get; set; }
}