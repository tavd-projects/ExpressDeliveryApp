namespace ExpressDeliveryApp.Models;

public class UpdateTicketRequest
{
    public Guid Id { get; set; }
    public string CustomerName { get; set; }
    
    public decimal WeightKg { get; set; }
    public string Description { get; set; }
    
    public DateTime СargoСollectionTime { get; set; }
}