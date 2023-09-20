using ExpressDeliveryApp.Domain;

namespace ExpressDeliveryApp.Service.Interfaces;

public interface ICourierService
{
    Task<IEnumerable<Ticket>> GetNewTicketAsync();
    Task TakeNewTicketsInWorkAsync(Guid id);
    Task AcceptWorkAsync(Guid id);
}