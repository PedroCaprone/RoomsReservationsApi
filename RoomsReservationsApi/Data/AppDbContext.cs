using RoomsReservationsApi.Models;

namespace RoomsReservationsApi.Data;

public class AppDbContext
{
    public List<Room> Rooms { get; set; } = new()
    {
        new Room
        {
            Id = 1,
            Name = "Sala 101",
            BuildingCode = "A",
            Floor = 1,
            Capacity = 20,
            HasProjector = true,
            IsActive = true
        },
        new Room
        {
            Id = 2,
            Name = "Sala 202",
            BuildingCode = "B",
            Floor = 2,
            Capacity = 12,
            HasProjector = false,
            IsActive = true
        },
        new Room
        {
            Id = 3,
            Name = "Sala 303",
            BuildingCode = "A",
            Floor = 3,
            Capacity = 30,
            HasProjector = true,
            IsActive = false
        },
        new Room
        {
            Id = 4,
            Name = "Sala 204",
            BuildingCode = "B",
            Floor = 2,
            Capacity = 24,
            HasProjector = true,
            IsActive = true
        }
    };

    public List<Reservation> Reservations { get; set; } = new()
    {
        new Reservation
        {
            Id = 1,
            RoomId = 1,
            OrganizerName = "Anna Kowalska",
            Topic = "Warsztaty z HTTP i REST",
            Date = new DateOnly(2026, 5, 10),
            StartTime = new TimeOnly(10, 0, 0),
            EndTime = new TimeOnly(12, 30, 0),
            Status = "confirmed"
        },
        new Reservation
        {
            Id = 2,
            RoomId = 2,
            OrganizerName = "Jan Nowak",
            Topic = "Konsultacje projektowe",
            Date = new DateOnly(2026, 5, 11),
            StartTime = new TimeOnly(9, 0, 0),
            EndTime = new TimeOnly(10, 0, 0),
            Status = "planned"
        },
        new Reservation
        {
            Id = 3,
            RoomId = 4,
            OrganizerName = "Maria Zielinska",
            Topic = "Spotkanie organizacyjne",
            Date = new DateOnly(2026, 5, 12),
            StartTime = new TimeOnly(14, 0, 0),
            EndTime = new TimeOnly(15, 30, 0),
            Status = "confirmed"
        }
    };
}