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
    public ActionResult<IEnumerable<Room>> GetRooms(
        [FromQuery] int? minCapacity,
        [FromQuery] bool? hasProjector,
        [FromQuery] bool? activeOnly)
    {
        var rooms = _context.Rooms.AsEnumerable();

        if (minCapacity.HasValue)
        {
            rooms = rooms.Where(r => r.Capacity >= minCapacity.Value);
        }

        if (hasProjector.HasValue)
        {
            rooms = rooms.Where(r => r.HasProjector == hasProjector.Value);
        }

        if (activeOnly == true)
        {
            rooms = rooms.Where(r => r.IsActive);
        }

        return Ok(rooms);
    }

    [HttpGet("{id}")]
    public ActionResult<Room> GetRoomById(int id)
    {
        var room = _context.Rooms.FirstOrDefault(r => r.Id == id);

        if (room == null)
        {
            return NotFound();
        }

        return Ok(room);
    }

    [HttpGet("building/{buildingCode}")]
    public ActionResult<IEnumerable<Room>> GetRoomsByBuilding(string buildingCode)
    {
        var rooms = _context.Rooms
            .Where(r => r.BuildingCode.Equals(buildingCode, StringComparison.OrdinalIgnoreCase))
            .ToList();

        return Ok(rooms);
    }

    [HttpPost]
    public ActionResult<Room> AddRoom(Room room)
    {
        room.Id = _context.Rooms.Count + 1;
        _context.Rooms.Add(room);

        return CreatedAtAction(nameof(GetRoomById), new { id = room.Id }, room);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateRoom(int id, Room updatedRoom)
    {
        var room = _context.Rooms.FirstOrDefault(r => r.Id == id);

        if (room == null)
        {
            return NotFound();
        }

        room.Name = updatedRoom.Name;
        room.BuildingCode = updatedRoom.BuildingCode;
        room.Floor = updatedRoom.Floor;
        room.Capacity = updatedRoom.Capacity;
        room.HasProjector = updatedRoom.HasProjector;
        room.IsActive = updatedRoom.IsActive;

        return Ok(room);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteRoom(int id)
    {
        var room = _context.Rooms.FirstOrDefault(r => r.Id == id);

        if (room == null)
        {
            return NotFound();
        }

        var hasReservations = _context.Reservations.Any(r => r.RoomId == id);

        if (hasReservations)
        {
            return Conflict("Cannot delete room with related reservations.");
        }

        _context.Rooms.Remove(room);

        return NoContent();
    }
}