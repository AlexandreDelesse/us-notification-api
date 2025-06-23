namespace PocMissionPush.Subscriptions;

public class SubscriptionCreateDTO
{
    public required string Endpoint { get; set; }
    public required string Auth { get; set; }
    public required string P256dh { get; set; }
}