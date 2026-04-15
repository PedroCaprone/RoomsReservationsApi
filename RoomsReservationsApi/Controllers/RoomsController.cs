using Microsoft.AspNetCore.Mvc;
using RoomsReservationsApi.Data;
using RoomsReservationsApi.Models;

namespace RoomsReservationsApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RoomsController : ControllerBase
{
    private readonly AppDbContext _context;

    public RoomsController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Room>> GetRooms()
    {
        return Ok(_context.Rooms);
    }
    
    [HttpPost]
    public ActionResult<Room> AddRoom(Room room)
    {
        room.Id = _context.Rooms.Count + 1;
        _context.Rooms.Add(room);

        return CreatedAtAction(nameof(GetRooms), new { id = room.Id }, room);
    }
}