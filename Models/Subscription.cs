

namespace PocMissionPush.Models;

public class Subscription
{
    public int Id { get; set; }
    public required string UserId { get; set; }
    public required string Endpoint { get; set; }

    public required string Auth { get; set; }
    public required string P256dh { get; set; }


}