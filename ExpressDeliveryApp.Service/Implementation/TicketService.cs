using ExpressDeliveryApp.Domain;
using ExpressDeliveryApp.Domain.Exceptions;
using ExpressDeliveryApp.Repository.Interfaces;
using ExpressDeliveryApp.Service.Interfaces;

namespace ExpressDeliveryApp.Service.Implementation;

public class TicketService : ITicketService
{
    private readonly ITicketRepository _ticketRepository;

    public TicketService(ITicketRepository ticketRepository)
    {
        _ticketRepository = ticketRepository;
    }

    public async Task<Guid> RegisterAsync(Ticket ticket)
    {
        ticket.Status = TicketStatus.New;
        return await _ticketRepository.CreateAsync(ticket);
    }

    public async Task UpdateAsync(Ticket ticket)
    {
        var oldTicket = await _ticketRepository.GetAsync(ticket.Id);
        ticket.Status = oldTicket.Status;
        
        if (ticket.Status != TicketStatus.New)
            throw new ForbiddenException("Ticket status not new");

        await _ticketRepository.UpdateAsync(ticket);
    }

    public async Task CancelAsync(Guid id, string reason)
    {
        var ticket = await GetAsync(id);

        if (ticket.Status is TicketStatus.Cancelled)
            throw new TicketAlreadyCancelledException("Ticket already cancelled");

        ticket.Status = TicketStatus.Cancelled;
        ticket.CancelReason = reason;

        await _ticketRepository.UpdateAsync(ticket);
    }

    public async Task<Ticket> GetAsync(Guid id)
    {
        var ticket = await _ticketRepository.GetAsync(id);

        if (ticket is null) throw new NotFoundException("Ticket not found");

        return ticket;
    }

    public async Task<IEnumerable<Ticket>> GetAllAsync()
    {
        return await _ticketRepository.GetAllAsync();
    }
}