using RoomsReservationsApi.Models;

namespace RoomsReservationsApi.Data;

public class AppDbContext
{
    public List<Room> Rooms { get; set; } = new List<Room>
    {
        new Room { Id = 1, Name = "Pokoj 1", Capacity = 2 },
        new Room { Id = 2, Name = "Pokoj 2", Capacity = 4 }
    };

    public List<Reservation> Reservations { get; set; } = new List<Reservation>();
}