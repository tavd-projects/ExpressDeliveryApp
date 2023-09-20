using ExpressDeliveryApp.Domain;

namespace ExpressDeliveryApp.Repository.Interfaces;

public interface ITicketRepository : IRepositoryBase<Ticket>
{
    Task UpdateWithoutStatusAsync(Ticket ticket);
}