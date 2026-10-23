using EventEase.Models;

namespace EventEase.Services;

/// <summary>
/// In-memory store for events. Registered as a singleton in Program.cs,
/// which keeps the demo simple; the methods mirror a real repository API.
/// </summary>
public class EventService
{
    private readonly List<Event> _items = new()
    {
        new() { Id = 1, Title = "Web Development Workshop", Category = "Workshop",
                Date = new DateTime(2026, 11, 14), Location = "Main Hall, MUST",
                Capacity = 60, RegisteredAttendees = 42,
                Description = "Hands-on HTML, CSS and Blazor practice." },
        new() { Id = 2, Title = "AI in Education Seminar", Category = "Seminar",
                Date = new DateTime(2026, 11, 21), Location = "Seminar Room 2",
                Capacity = 100, RegisteredAttendees = 78,
                Description = "How AI tools are changing classrooms." },
        new() { Id = 3, Title = "Annual Tech Conference", Category = "Conference",
                Date = new DateTime(2026, 12, 5), Location = "Auditorium",
                Capacity = 300, RegisteredAttendees = 150 },
    };
    private int _nextId = 4;

    public IReadOnlyList<Event> GetAll() => _items.OrderBy(e => e.Date).ToList();
    public Event? GetById(int id) => _items.FirstOrDefault(e => e.Id == id);

    public Event Add(Event item)
    {
        item.Id = _nextId++;
        _items.Add(item);
        return item;
    }

    public void Delete(int id)
    {
        var item = GetById(id);
        if (item is not null) _items.Remove(item);
    }

    public int TotalCapacity => _items.Sum(e => e.Capacity);
    public int TotalRegistered => _items.Sum(e => e.RegisteredAttendees);
}
