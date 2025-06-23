namespace PocMissionPush.Subscriptions;

public class Subscription
{
    public int Id { get; set; }
    public required string UserId { get; set; }
    public required string Endpoint { get; set; }
    public required string Auth { get; set; }
    public required string P256dh { get; set; }
    public required DateTime CreatedDate { get; set; }
    public required DateTime LastUsed { get; set; }
}