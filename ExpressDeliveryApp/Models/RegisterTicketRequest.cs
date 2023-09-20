namespace ExpressDeliveryApp.Models;

public class RegisterTicketRequest
{
    public string CustomerName { get; set; }
    
    public decimal WeightKg { get; set; }
    public string Description { get; set; }
    
    public DateTime СargoСollectionTime { get; set; }
}