using System.Threading.Tasks;

namespace PocMissionPush.Subscriptions;

public class SubscriptionService
{
    ISubscriptionRepository _subscriptionRepository;

    public SubscriptionService(ISubscriptionRepository repository)
    {
        _subscriptionRepository = repository;
    }

    public async Task<Subscription> CreateSubscription(SubscriptionCreateDTO sub)
    {

        Subscription? existing = await _subscriptionRepository.GetSubscriptionsByEndPoint(sub.Endpoint);
        if (existing is not null) return existing;
        else
        {
            Subscription newSub = new()
            {
                UserId = "123",
                Auth = sub.Auth,
                P256dh = sub.P256dh,
                Endpoint = sub.Endpoint,
                CreatedDate = DateTime.UtcNow,
                LastUsed = DateTime.UtcNow,

            };
            Subscription myNewSub = await _subscriptionRepository.CreateSubscription(newSub);
            return myNewSub;
        }
    }

    public async Task DeleteSubscription(string endpoint)
    {
        Subscription? sub = await _subscriptionRepository.GetSubscriptionsByEndPoint(endpoint);
        if (sub is not null)
            await _subscriptionRepository.DeleteSubscription(sub);
    }
}