# EventEase — Blazor Event Management App

A Blazor Server app (.NET 8) built with Microsoft Copilot for the Coursera
peer-graded project. EventEase lets users create and browse events, register
an account, and track attendance.

## Features mapped to the grading criteria

1. **GitHub repository** — this public repo contains the complete project.
2. **Event Card component with two-way data binding** — `Components/EventCard.razor`
   displays one `Event` (title, category, date, location, capacity,
   registered attendees, seats left). On the Events page the Add form edits a
   draft `Event` with `@bind-Value`, and the same object is passed to the card,
   so the preview updates live as you type — true two-way binding.
3. **Routing implemented and debugged** — pages: `/` (Home), `/events`,
   `/events/{Id:int}` (Event Details), `/register`, `/attendance`.
   The `:int` route constraint plus a friendly "Event not found" view fix the
   routing errors that a bad or deleted ID used to cause.
4. **Performance and validation** — DataAnnotations validation on every form
   field (no invalid data reaches the services), `@key` on repeated list
   items so Blazor re-renders only what changed, and services registered with
   the correct lifetimes (singleton data stores, scoped session).
5. **Advanced features** —
   - *Registration Form* (`/register`) with full validation (required fields,
     email format, minimum password length, confirm-password match).
   - *State management for user sessions* — `Services/UserSessionService.cs`
     is a scoped service holding the signed-in user; the NavMenu subscribes to
     its `OnChange` event and updates immediately on login/logout.
   - *Attendance Tracker* (`/attendance`) — mark attendance per event with
     date, status and note; shows total entries and attendance percentage.
6. **Copilot summary** — see `COPILOT_SUMMARY.md`.

## Run it

```bash
dotnet run
```

Then open the URL shown in the terminal (default https://localhost:7xxx).

## Project layout

- `Components/EventCard.razor` — the reusable Event Card component
- `Components/Pages/` — Home, Events, EventDetails, Register, Attendance
- `Models/` — `Event`, `RegistrationModel`, `AttendanceRecord`
- `Services/` — `EventService`, `AttendanceService`, `UserSessionService`
- `Program.cs` — service registration (DI lifetimes)
