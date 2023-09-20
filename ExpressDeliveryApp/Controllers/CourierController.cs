using ExpressDeliveryApp.Domain;
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
    
    [HttpPost]
    public async Task<IActionResult> TakeNewTicketsInWorkAsync(Guid id)
    {
        await _courierService.TakeNewTicketInWorkAsync(id);
        return Ok();
    }
}