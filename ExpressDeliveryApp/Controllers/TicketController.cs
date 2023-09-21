using AutoMapper;
using ExpressDeliveryApp.Domain;
using ExpressDeliveryApp.DTOs;
using ExpressDeliveryApp.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ExpressDeliveryApp.Controllers;

[ApiController]
[Route("[controller]")]
public class TicketController : ControllerBase
{
    private readonly ITicketService _ticketService;
    private readonly ITicketSearcherService _ticketSearcherService;
    private readonly IMapper _mapper;

    public TicketController(ITicketService ticketService, ITicketSearcherService ticketSearcherService, IMapper mapper)
    {
        _ticketService = ticketService;
        _ticketSearcherService = ticketSearcherService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetTicketAsync(Guid ticketId)
    {
        var ticket = await _ticketService.GetAsync(ticketId);
        return Ok(_mapper.Map<Ticket, TicketDto>(ticket));
    }

    [HttpGet("all")]
    public async Task<IActionResult> GetTicketsAsync()
    {
        var tickets = await _ticketService.GetAllAsync();
        return Ok(tickets
            .Select(x => _mapper.Map<Ticket, TicketDto>(x)));
    }

    [HttpPost("register")]
    public async Task<IActionResult> RegisterTicketAsync([FromBody] RegisterTicketDto registerTicketDto)
    {
        var id = await _ticketService.RegisterAsync(_mapper.Map<RegisterTicketDto, Ticket>(registerTicketDto));
        return Ok(new GuidDto() { Id = id });
    }

    [HttpPut]
    public async Task<IActionResult> UpdateTicketAsync([FromBody] UpdateTicketDto updateTicketDto)
    {
        await _ticketService.UpdateAsync(_mapper.Map<UpdateTicketDto, Ticket>(updateTicketDto));
        return Ok();
    }

    [HttpPost("cancel")]
    public async Task<IActionResult> CancelTicketAsync([FromBody] CancelTicketDto cancelTicketDto)
    {
        await _ticketService.CancelAsync(cancelTicketDto.Guid, cancelTicketDto.Reason);
        return Ok();
    }

    [HttpGet("search")]
    public async Task<IActionResult> FullTextSearchAsync([FromQuery] SearchDto searchDto)
    {
        return Ok(await _ticketSearcherService.SearchAsync(searchDto.Query));
    }
}