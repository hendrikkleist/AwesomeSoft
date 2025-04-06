using AwesomeSoft.Domain.Entities;
using AwesomeSoft.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AwesomeSoft.WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class PeopleController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;

    public PeopleController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    [HttpGet]
    public ActionResult GetPeople()
    {
        return Ok(_unitOfWork.People.GetAll());
    }

    [HttpGet("{id}")]
    public ActionResult GetPerson(int id)
    {
        var person = _unitOfWork.People.GetById(id);
        if (person == null)
        {
            return NotFound();
        }
        return Ok(person);
    }

    [HttpGet("getbookings/{id}")]
    public ActionResult GetBooking(int id)
    {
        var bookings = _unitOfWork.People.GetBookings(id);
        if (bookings == null)
        {
            return Ok("No bookings");
        }
        return Ok(bookings);
    }

    [HttpPut("{id}")]
    public IActionResult PutPerson(int id, Person person)
    {
        if (id != person.Id)
        {
            return BadRequest();
        }

        _unitOfWork.People.Update(id, person);
        var result = _unitOfWork.Complete();

        return Ok(result);
    }

    [HttpPost]
    public IActionResult PostPerson(Person person)
    {
        _unitOfWork.People.Add(person);
        var result = _unitOfWork.Complete();
        if (result == 0)
        {
            return BadRequest();
        }
        return CreatedAtAction("GetPerson", new { id = person.Id }, person);
    }

    [HttpDelete("{id}")]
    public IActionResult DeletePerson(int id)
    {
        var person = _unitOfWork.People.GetById(id);
        if (person == null)
        {
            return NotFound();
        }
        _unitOfWork.People.Remove(person);
        var result = _unitOfWork.Complete();
        if (result == 0)
        {
            return BadRequest();
        }
        return NoContent();
    }

}
