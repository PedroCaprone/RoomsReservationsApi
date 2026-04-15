using System.ComponentModel.DataAnnotations;

namespace RoomsReservationsApi.Models;

public class Reservation
{
    public int Id { get; set; }

    [Required]
    public int RoomId { get; set; }

    [Required]
    public string ReservedBy { get; set; } = string.Empty;

    [Required]
    public DateTime From { get; set; }

    [Required]
    public DateTime To { get; set; }
}