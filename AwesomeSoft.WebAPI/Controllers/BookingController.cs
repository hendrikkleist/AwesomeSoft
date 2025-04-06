using AwesomeSoft.Domain.Entities;
using AwesomeSoft.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AwesomeSoft.WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class BookingController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;
    public BookingController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    [HttpGet]
    public ActionResult<Dictionary<string, string[]>> GetSchedule()
    {
        return Ok(_unitOfWork.Bookings.GetSchedule());
    }

    [HttpPost("book")]
    public async Task<ActionResult> BookSlot([FromBody] Booking booking)
    {
        if (booking.SlotIndex < 0 || booking.SlotIndex > 7)
        {
            return BadRequest("Invalid slot index");
        }

        if (await _unitOfWork.Bookings.BookingExistsAsync(booking))
        {
            return Conflict("Slot already booked");
        }

        _unitOfWork.Bookings.Add(booking);
        var result = _unitOfWork.Complete();
        if (result == 0)
        {
            return BadRequest();
        }

        return Ok("Booking successful.");
    }

}
