using ExpressDeliveryApp.Domain;

namespace ExpressDeliveryApp.Service.Interfaces;

public interface ICourierService
{
    Task<IEnumerable<Ticket>> GetNewTicketsAsync();
    Task TakeNewTicketInWorkAsync(Guid id);
    Task AcceptWorkAsync(Guid id);
}