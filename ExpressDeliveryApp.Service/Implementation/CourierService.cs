﻿using ExpressDeliveryApp.Domain;
using ExpressDeliveryApp.Domain.Exceptions;
using ExpressDeliveryApp.Repository.Interfaces;
using ExpressDeliveryApp.Service.Interfaces;

namespace ExpressDeliveryApp.Service.Implementation;

public class CourierService : ICourierService
{
    private readonly ITicketRepository _ticketRepository;

    public CourierService(ITicketRepository ticketRepository)
    {
        _ticketRepository = ticketRepository;
    }

    public async Task<IEnumerable<Ticket>> GetNewTicketsAsync()
    {
        return await GetTicketsFromStatusAsync(TicketStatus.New);
    }

    public async Task TakeNewTicketInWorkAsync(Guid id)
    {
        await ChangeStatusAsync(await _ticketRepository.GetAsync(id), TicketStatus.SubmittedForExecution,
            TicketStatus.New);
    }

    public async Task AcceptWorkAsync(Guid id)
    {
        await ChangeStatusAsync(await _ticketRepository.GetAsync(id), TicketStatus.Done,
            TicketStatus.SubmittedForExecution);
    }

    private async Task ChangeStatusAsync(Ticket ticket, TicketStatus status, TicketStatus previousStatus)
    {
        if (ticket.Status != previousStatus)
            throw new ForbiddenException($"Ticket status not {previousStatus}");

        await ChangeStatusAsync(ticket, status);
    }

    private async Task ChangeStatusAsync(Ticket ticket, TicketStatus status)
    {
        ticket.Status = status;
        await _ticketRepository.UpdateAsync(ticket);
    }

    private async Task<IEnumerable<Ticket>> GetTicketsFromStatusAsync(TicketStatus ticketStatus)
    {
        var tickets = await _ticketRepository.GetAllAsync();
        return tickets.Where(x => x.Status == ticketStatus);
    }
}