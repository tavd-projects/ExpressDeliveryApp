using ExpressDeliveryApp.DTOs;
using ExpressDeliveryApp.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ExpressDeliveryApp.Controllers;

[ApiController]
[Route("[controller]")]
public class CourierController : ControllerBase
{
    private readonly ICourierService _courierService;

    public CourierController(ICourierService courierService)
    {
        _courierService = courierService;
    }

    [HttpGet]
    public async Task<IActionResult> GetNewTicketAsync()
    {
        return Ok(await _courierService.GetNewTicketsAsync());
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