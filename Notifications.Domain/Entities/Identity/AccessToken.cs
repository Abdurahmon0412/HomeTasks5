namespace Notifications.Domain.Entities;

/// <summary>
/// Access Token Service
/// </summary>
public class AccessToken
{
    public Guid Id { get; set; }

    public Guid UserId { get; set; }

    public string Value { get; set; } = default!;

    public bool IsRevoked { get; set; }

    public DateTime CreatedTime { get; set; }
}