using Microsoft.AspNetCore.Mvc;
using RoomsReservationsApi.Data;
using RoomsReservationsApi.Models;

namespace RoomsReservationsApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ReservationsController : ControllerBase
{
    private readonly AppDbContext _context;

    public ReservationsController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Reservation>> GetReservations()
    {
        return Ok(_context.Reservations);
    }

    [HttpGet("{id}")]
    public ActionResult<Reservation> GetReservationById(int id)
    {
        var reservation = _context.Reservations.FirstOrDefault(r => r.Id == id);

        if (reservation == null)
        {
            return NotFound();
        }

        return Ok(reservation);
    }

    [HttpPost]
    public ActionResult<Reservation> AddReservation(Reservation reservation)
    {
        var room = _context.Rooms.FirstOrDefault(r => r.Id == reservation.RoomId);

        if (room == null)
        {
            return BadRequest("Room does not exist.");
        }

        if (!room.IsActive)
        {
            return BadRequest("Room is not active.");
        }

        if (reservation.EndTime <= reservation.StartTime)
        {
            return BadRequest("EndTime must be later than StartTime.");
        }

        var conflict = _context.Reservations.Any(r =>
            r.RoomId == reservation.RoomId &&
            r.Date == reservation.Date &&
            reservation.StartTime < r.EndTime &&
            reservation.EndTime > r.StartTime
        );

        if (conflict)
        {
            return Conflict("Room is already reserved in this time.");
        }

        reservation.Id = _context.Reservations.Count + 1;
        _context.Reservations.Add(reservation);

        return CreatedAtAction(nameof(GetReservationById), new { id = reservation.Id }, reservation);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteReservation(int id)
    {
        var reservation = _context.Reservations.FirstOrDefault(r => r.Id == id);

        if (reservation == null)
        {
            return NotFound();
        }

        _context.Reservations.Remove(reservation);

        return NoContent();
    }
}