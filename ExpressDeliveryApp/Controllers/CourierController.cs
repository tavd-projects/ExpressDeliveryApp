using ExpressDeliveryApp.Domain;
using ExpressDeliveryApp.DTOs;
using ExpressDeliveryApp.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ExpressDeliveryApp.Controllers;

[ApiController]
[Route("[controller]/courier")]
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
    public async Task<IActionResult> TakeNewTicketInWorkAsync([FromBody] GuidRequest guidRequest)
    {
        await _courierService.TakeNewTicketInWorkAsync(guidRequest.Guid);
        return Ok();
    }

    [HttpPost("accept")]
    public async Task<IActionResult> AcceptWorkAsync([FromBody] GuidRequest guidRequest)
    {
        await _courierService.AcceptWorkAsync(guidRequest.Guid);
        return Ok();
    }
}