using System.ComponentModel.DataAnnotations;

namespace RoomsReservationsApi.Models;

public class Room
{
    public int Id { get; set; }

    [Required]
    public string Name { get; set; } = string.Empty;

    [Required]
    public string Building { get; set; } = string.Empty;

    [Range(1, 500)]
    public int Capacity { get; set; }
}