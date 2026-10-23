using System.ComponentModel.DataAnnotations;

namespace EventEase.Models;

/// <summary>One event shown by the Event Card component.</summary>
public class Event
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Please give the event a title.")]
    [StringLength(60, MinimumLength = 3, ErrorMessage = "Title must be 3-60 characters.")]
    public string Title { get; set; } = string.Empty;

    [Required(ErrorMessage = "Please choose a category.")]
    public string Category { get; set; } = "Workshop";

    [Required(ErrorMessage = "Event date is required.")]
    public DateTime Date { get; set; } = DateTime.Today.AddDays(7);

    [Required(ErrorMessage = "Location is required.")]
    [StringLength(80, ErrorMessage = "Location can be at most 80 characters.")]
    public string Location { get; set; } = string.Empty;

    [Required(ErrorMessage = "Capacity is required.")]
    [Range(1, 10000, ErrorMessage = "Capacity must be between 1 and 10,000.")]
    public int Capacity { get; set; } = 50;

    [Range(0, 10000, ErrorMessage = "Registered attendees cannot be negative.")]
    public int RegisteredAttendees { get; set; }

    [StringLength(200, ErrorMessage = "Description can be at most 200 characters.")]
    public string? Description { get; set; }

    /// <summary>Seats still open, used by the card.</summary>
    public int SeatsLeft => Capacity - RegisteredAttendees;
}
