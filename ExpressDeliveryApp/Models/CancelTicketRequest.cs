namespace ExpressDeliveryApp.Models;

public class CancelTicketRequest
{
    public Guid Guid { get; set; }
    public string Reason { get; set; }
}