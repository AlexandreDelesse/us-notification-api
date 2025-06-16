using Microsoft.AspNetCore.Mvc;
using PocMissionPush.Models;
using WebPush;

public class PushService
{
    private readonly VapidDetails _vapidDetails;
    private readonly IPushSubscriptionRepository<Subscription> _subscriptionRepository;


    public PushService(IConfiguration configuration, IPushSubscriptionRepository<Subscription> pushSubRepository)
    {
        _vapidDetails = new VapidDetails(
            "mailto:alex.delesse01@gmail.com",
            configuration["VapidKeys:PublicKey"],
            configuration["VapidKeys:PrivateKey"]
        );

        _subscriptionRepository = pushSubRepository;
    }

    public async Task<ActionResult> StoreSubscription(Subscription subsccription, HttpPresenter<Subscription> presenter)
    {

        var subscription = await _subscriptionRepository.StoreSubscription(subsccription);
        return presenter.PresentSuccess(subscription);
    }

    public async Task NotifyAll(string payload)
    {
        await _subscriptionRepository.NotifyAll();
        // List<PushSubscription> pushSubscriptions = _subContext.Subscriptions.Select(s => new PushSubscription { Endpoint = s.Endpoint, Auth = s.Auth, P256DH = s.P256dh }).ToList();
        // pushSubscriptions.ForEach(async subscription => await SendNotificationAsync(subscription, payload));
    }

    public async Task<ActionResult> GetSubscriptions(IResultPresenter<List<Subscription>> presenter)
    {
        var data = await _subscriptionRepository.GetSubscriptions();
        if (data != null) return presenter.PresentSuccess(data);
        else return presenter.PresentError("Aucune donnée");

    }

    public async Task<ActionResult> GetSubscriptionsByUserId(string userId, IResultPresenter<List<Subscription>> presenter)
    {
        var subscriptions = await _subscriptionRepository.GetSubscriptionsByUserId(userId);
        if (subscriptions == null) return presenter.PresentError("Aucune subscription avec cet ID");
        else return presenter.PresentSuccess(subscriptions);

    }



}

