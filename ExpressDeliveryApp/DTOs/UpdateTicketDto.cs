namespace ExpressDeliveryApp.DTOs;

public class UpdateTicketDto
{
    public Guid Id { get; set; }
    public string CustomerName { get; set; }
    
    public decimal WeightKg { get; set; }
    public string Description { get; set; }
    
    public DateTime СargoСollectionTime { get; set; }
}