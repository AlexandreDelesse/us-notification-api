
namespace PocMissionPush.Subscriptions;

public interface ISubscriptionRepository
{
    Task<Subscription> CreateSubscription(Subscription sub);
    Task<List<Subscription>> GetSubscriptionsByUserId(string userId);
    Task<List<Subscription>> GetSubscriptionByUserIds(List<string> userIds);
    Task<Subscription?> GetSubscriptionsByEndPoint(string endpoint);
    Task<Subscription> UpdateSubscription(Subscription newSub);
    Task DeleteSubscription(Subscription sub);

}