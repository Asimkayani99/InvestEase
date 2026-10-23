# How Microsoft Copilot Assisted in Building EventEase

EventEase is a Blazor Server (.NET 8) event-management app. Microsoft Copilot
was used at every step of the development process:

**Step 1 — Foundational Event Card component.**
Copilot generated the first version of the `EventCard` component and the
`Event` model from a plain-English description ("a card that shows an event's
title, category, date, location, capacity and seats left"). It suggested the
`[Parameter]` pattern for passing the event into the card and explained how
`@bind-Value` on the Add-event form gives two-way data binding: the same
`Event` object is edited by the form and displayed by the card, so the card
preview updates live while typing.

**Step 2 — Routing: implementation and debugging.**
Copilot helped set up the routes (`/events`, `/events/{Id:int}`, `/register`,
`/attendance`) and debug two routing problems: links that pointed to a
non-existent page, and a crash when opening the details page of a deleted
event. Its suggested fix — the `:int` route constraint plus checking for a
null event and showing a friendly "Event not found" message — is what the
final code uses.

**Step 3 — Performance, input validation and error handling.**
Copilot reviewed the app and pointed out that invalid input (empty titles,
negative capacity) could break the data, so DataAnnotations validation
(`[Required]`, `[StringLength]`, `[Range]`, `[EmailAddress]`, `[Compare]`)
was added to the models with `DataAnnotationsValidator` in the forms. For
performance it suggested adding `@key` to the repeated event cards so Blazor
only re-renders the items that actually changed, and registering the data
services as singletons instead of re-creating them.

**Step 4 — Advanced features.**
With Copilot's help I added the three advanced features: a Registration Form
with full validation; state management for user sessions through a scoped
`UserSessionService` (Copilot explained why scoped is the right lifetime in
Blazor Server — one instance per user circuit — and how the NavMenu can
subscribe to its change event); and an Attendance Tracker that stores
attendance entries per event and computes the attendance percentage.

**Step 5 — Review and documentation.**
Finally, Copilot helped review the whole project against the assignment's
grading criteria, tidy the code, and write the README and this summary.
