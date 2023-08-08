using FormulaAirline.Api.Models;
using FormulaAirline.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace FormulaAirline.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class BookingController : ControllerBase
{

    private readonly ILogger<BookingController> _logger;
    private readonly IMessageProducer _messageProducer;
    public static List<Booking> _bookings = new();

    public BookingController(ILogger<BookingController> logger, IMessageProducer messageProducer)
     => (_logger, _messageProducer) = (logger, messageProducer);

    [HttpPost]
    public IActionResult CreatingBooking(Booking newbooking)
    {
        if (!ModelState.IsValid) return BadRequest();

        _bookings.Add(newbooking);

        _messageProducer.SendingMessage<Booking>(newbooking);

        return Ok();

    }


}
