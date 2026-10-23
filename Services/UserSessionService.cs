using EventEase.Models;

namespace EventEase.Services;

/// <summary>
/// State management for the user session. Registered as SCOPED in Program.cs,
/// so in Blazor Server each connected user (circuit) gets its own instance —
/// that is exactly the lifetime a login session needs.
/// </summary>
public class UserSessionService
{
    public RegistrationModel? CurrentUser { get; private set; }
    public bool IsLoggedIn => CurrentUser is not null;
    public DateTime? LoginTime { get; private set; }

    /// <summary>Components (e.g. NavMenu) subscribe to refresh when state changes.</summary>
    public event Action? OnChange;

    public void Register(RegistrationModel model)
    {
        CurrentUser = model;
        LoginTime = DateTime.Now;
        Notify();
    }

    public void Logout()
    {
        CurrentUser = null;
        LoginTime = null;
        Notify();
    }

    private void Notify() => OnChange?.Invoke();
}
