namespace ExpressDeliveryApp.DTOs;

public class TicketDto
{
    public string CustomerName { get; set; }
    public string Status { get; set; }
    
    public string? CancelReason { get; set; }
    public decimal WeightKg { get; set; }
    
    public string Description { get; set; }

    public DateTime СargoСollectionTime { get; set; }
}