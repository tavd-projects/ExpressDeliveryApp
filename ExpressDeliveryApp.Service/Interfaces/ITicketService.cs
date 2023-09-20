using ExpressDeliveryApp.Domain;

namespace ExpressDeliveryApp.Service.Interfaces;

public interface ITicketService
{
    Task<Guid> RegisterAsync(Ticket ticket);
    Task UpdateAsync(Ticket ticket);
    Task CancelAsync(Guid id, string reason);
    
    Task<Ticket> GetAsync(Guid id);
    Task<IEnumerable<Ticket>> GetAllAsync();
}