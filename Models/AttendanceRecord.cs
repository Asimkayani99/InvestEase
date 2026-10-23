namespace EventEase.Models;

/// <summary>One entry in the Attendance Tracker.</summary>
public class AttendanceRecord
{
    public int Id { get; set; }
    public DateTime Date { get; set; } = DateTime.Today;
    public string EventName { get; set; } = string.Empty;
    public string Status { get; set; } = "Present"; // Present | Absent | Leave
    public string? Note { get; set; }
}
