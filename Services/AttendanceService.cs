using EventEase.Models;

namespace EventEase.Services;

/// <summary>In-memory store behind the Attendance Tracker page.</summary>
public class AttendanceService
{
    private readonly List<AttendanceRecord> _records = new()
    {
        new() { Id = 1, Date = DateTime.Today.AddDays(-2), EventName = "Web Development Workshop", Status = "Present", Note = "Helped with setup" },
        new() { Id = 2, Date = DateTime.Today.AddDays(-1), EventName = "AI in Education Seminar", Status = "Present", Note = "Took notes" },
    };
    private int _nextId = 3;

    public IReadOnlyList<AttendanceRecord> GetAll() =>
        _records.OrderByDescending(r => r.Date).ToList();

    public void Add(AttendanceRecord record)
    {
        record.Id = _nextId++;
        _records.Add(record);
    }

    public double AttendancePercentage
    {
        get
        {
            if (_records.Count == 0) return 0;
            var present = _records.Count(r => r.Status == "Present");
            return Math.Round(present * 100.0 / _records.Count, 1);
        }
    }
}
