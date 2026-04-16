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
    
    [HttpPost]
    public ActionResult<Reservation> AddReservation(Reservation reservation)
    {
        reservation.Id = _context.Reservations.Count + 1;
        _context.Reservations.Add(reservation);

        return CreatedAtAction(nameof(GetReservations), new { id = reservation.Id }, reservation);
    }
}