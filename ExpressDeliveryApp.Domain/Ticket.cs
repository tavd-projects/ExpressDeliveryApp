namespace ExpressDeliveryApp.Domain;

public class Ticket : BaseEntity
{
    public Customer Customer { get; set; }
    public TicketStatus Status { get; set; }
    public Cargo Cargo { get; set; }
    public DateTime СargoСollectionTime { get; set; }
}