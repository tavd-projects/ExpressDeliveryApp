using ExpressDeliveryApp.Domain;

namespace ExpressDeliveryApp.Service.Interfaces;

public interface ITicketSearcherService
{
    Task<IEnumerable<Ticket>> SearchAsync(string text);
}