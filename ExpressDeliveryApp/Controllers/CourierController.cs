using AutoMapper;
using ExpressDeliveryApp.Domain;
using ExpressDeliveryApp.DTOs;
using ExpressDeliveryApp.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ExpressDeliveryApp.Controllers;

[ApiController]
[Route("[controller]")]
public class CourierController : ControllerBase
{
    private readonly ICourierService _courierService;
    private readonly IMapper _mapper;

    public CourierController(ICourierService courierService, IMapper mapper)
    {
        _courierService = courierService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetNewTicketAsync()
    {
        return Ok((await _courierService.GetNewTicketsAsync()).Select(x => _mapper.Map<Ticket, TicketDto>(x)));
    }

    [HttpPost("take")]
    public async Task<IActionResult> TakeNewTicketInWorkAsync([FromBody] GuidDto guidDto)
    {
        await _courierService.TakeNewTicketInWorkAsync(guidDto.Id);
        return Ok();
    }

    [HttpPost("accept")]
    public async Task<IActionResult> AcceptWorkAsync([FromBody] GuidDto guidDto)
    {
        await _courierService.AcceptWorkAsync(guidDto.Id);
        return Ok();
    }
}