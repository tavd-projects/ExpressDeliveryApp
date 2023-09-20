using ExpressDeliveryApp.Domain;
using ExpressDeliveryApp.Domain.Exceptions;
using ExpressDeliveryApp.Repository.Interfaces;

namespace ExpressDeliveryApp.Repository.Implementation;

public class InMemoryTicketRepository : ITicketRepository
{
    private readonly List<Ticket> _ticketList = new List<Ticket>();
    public async Task<Guid> CreateAsync(Ticket entity)
    {
        entity.Id = Guid.NewGuid();
        _ticketList.Add(entity);

        return entity.Id;
    }

    public async Task<Ticket> GetAsync(Guid id)
    {
        return _ticketList.Where(x => x.Id == id).FirstOrDefault();
    }

    public async Task UpdateAsync(Ticket entity)
    {
        for (int i = 0; i < _ticketList.Count; i++)
        {
            if (_ticketList[i].Id == entity.Id)
            {
                _ticketList[i] = entity;
                return;
            }
        }

        throw new NotFoundException("Ticket not found");
    }

    public async Task<IEnumerable<Ticket>> GetAllAsync()
    {
        return _ticketList.ToArray();
    }

    public async Task DeleteAsync(Ticket entity)
    {
        _ticketList.Remove(entity);
    }
}