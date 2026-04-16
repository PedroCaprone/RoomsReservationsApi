using System.ComponentModel.DataAnnotations;

namespace RoomsReservationsApi.Models;

public class Reservation
{
    public int Id { get; set; }

    [Required]
    public int RoomId { get; set; }

    [Required]
    public string OrganizerName { get; set; } = string.Empty;

    [Required]
    public string Topic { get; set; } = string.Empty;

    [Required]
    public DateOnly Date { get; set; }

    [Required]
    public TimeOnly StartTime { get; set; }

    [Required]
    public TimeOnly EndTime { get; set; }

    [Required]
    public string Status { get; set; } = string.Empty;
}