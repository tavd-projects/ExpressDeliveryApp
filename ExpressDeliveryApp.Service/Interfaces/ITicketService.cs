using ExpressDeliveryApp.Domain;

namespace ExpressDeliveryApp.Service.Interfaces;

public interface ITicketService
{
    Guid RegisterAsync(Ticket ticket);
    Task UpdateAsync(Ticket ticket);
    Task CancelAsync(Guid id);
    
    Ticket GetAsync(Guid id);
}