namespace ExpressDeliveryApp.Domain.Exceptions;

[Serializable]
public class TicketAlreadyCancelledException : Exception
{
    public TicketAlreadyCancelledException(string message) : base(message)
    {
        
    }
    public TicketAlreadyCancelledException(string message, Exception inner) : base(message, inner)
    {
        
    }
}