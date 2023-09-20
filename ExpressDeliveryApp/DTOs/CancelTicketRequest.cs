namespace ExpressDeliveryApp.DTOs;

public class CancelTicketRequest
{
    public Guid Guid { get; set; }
    public string Reason { get; set; }
}