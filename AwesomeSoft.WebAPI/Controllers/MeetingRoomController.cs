using AwesomeSoft.Domain.Entities;
using AwesomeSoft.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AwesomeSoft.WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class MeetingRoomController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;

    public MeetingRoomController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    [HttpGet]
    public ActionResult GetMeetingRooms()
    {
        return Ok(_unitOfWork.MeetingRooms.GetAll());
    }

    [HttpGet("{id}")]
    public ActionResult GetMeetingRoom(int id)
    {
        var person = _unitOfWork.MeetingRooms.GetById(id);
        if (person == null)
        {
            return NotFound();
        }
        return Ok(person);
    }

    [HttpPut("{id}")]
    public IActionResult PutMeetingRoom(int id, MeetingRoom meetingRoom)
    {
        if (id != meetingRoom.Id)
        {
            return BadRequest();
        }

        _unitOfWork.MeetingRooms.Update(id, meetingRoom);
        var result = _unitOfWork.Complete();

        return Ok(result);
    }

    [HttpPost]
    public IActionResult PostMeetingRoom(MeetingRoom meetingRoom)
    {
        _unitOfWork.MeetingRooms.Add(meetingRoom);
        var result = _unitOfWork.Complete();
        if (result == 0)
        {
            return BadRequest();
        }
        return CreatedAtAction("GetMeetingRoom", new { id = meetingRoom.Id }, meetingRoom);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteMeetingRoom(int id)
    {
        var meetingRoom = _unitOfWork.MeetingRooms.GetById(id);
        if (meetingRoom == null)
        {
            return NotFound();
        }
        _unitOfWork.MeetingRooms.Remove(meetingRoom);
        var result = _unitOfWork.Complete();
        if (result == 0)
        {
            return BadRequest();
        }
        return NoContent();
    }
}
