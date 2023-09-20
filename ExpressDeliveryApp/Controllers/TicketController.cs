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
    private readonly IMapper _mapper;

    public TicketController(ITicketService ticketService, IMapper mapper)
    {
        _ticketService = ticketService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetTicketAsync(Guid ticketId)
    {
        return Ok(await _ticketService.GetAsync(ticketId));
    }
    
    [HttpGet]
    public async Task<IActionResult> GetTicketsAsync()
    {
        return Ok(await _ticketService.GetAllAsync());
    }

    [HttpPost]
    public async Task<IActionResult> RegisterTicketAsync([FromBody] RegisterTicketRequest registerTicketRequest)
    {
        return Ok(await _ticketService.RegisterAsync(_mapper.Map<RegisterTicketRequest, Ticket>(registerTicketRequest)));
    }
    
    [HttpPut]
    public async Task<IActionResult> UpdateTicketAsync([FromBody] UpdateTicketRequest updateTicketRequest)
    {
        await _ticketService.UpdateAsync(_mapper.Map<UpdateTicketRequest, Ticket>(updateTicketRequest));
        return Ok();
    }
    
    [HttpPost]
    public async Task<IActionResult> CancelTicketAsync([FromBody] CancelTicketRequest cancelTicketRequest)
    {
        await _ticketService.CancelAsync(cancelTicketRequest.Guid, cancelTicketRequest.Reason);
        return Ok();
    }
}