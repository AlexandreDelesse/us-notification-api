using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using Microsoft.IdentityModel.Tokens;
using PocMissionPush.Subscriptions;
using WebPush;

public class PushService
{
    private readonly VapidDetails _vapidDetails;
    private readonly ISubscriptionRepository _subscriptionRepository;


    public PushService(IConfiguration configuration, ISubscriptionRepository pushSubRepository)
    {
        _vapidDetails = new VapidDetails(
            "mailto:alex.delesse01@gmail.com",
            configuration["VapidKeys:PublicKey"],
            configuration["VapidKeys:PrivateKey"]
        );

        _subscriptionRepository = pushSubRepository;
    }



    public async Task NotifyAll(string payload)
    {
        // await _subscriptionRepository.NotifyAll();
        // List<PushSubscription> pushSubscriptions = _subContext.Subscriptions.Select(s => new PushSubscription { Endpoint = s.Endpoint, Auth = s.Auth, P256DH = s.P256dh }).ToList();
        // pushSubscriptions.ForEach(async subscription => await SendNotificationAsync(subscription, payload));
    }


    public async Task<List<string>> NotifyAllUserIds(NotificationCmd cmd, string payload)
    {
        WebPushClient pushClient = new();

        List<Subscription> subscriptions = await _subscriptionRepository.GetSubscriptionByUserIds(cmd.UserIds);

        foreach (var sub in subscriptions)
        {
            var pushSub = new PushSubscription(endpoint: sub.Endpoint, auth: sub.Auth, p256dh: sub.P256dh);
            try
            {
                await pushClient.SendNotificationAsync(subscription: pushSub, payload, vapidDetails: _vapidDetails);
            }
            catch (WebPushException ex)
            {
                Console.WriteLine(ex);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        List<string> endpoints = [.. subscriptions.Select(s => s.Endpoint)];
        return endpoints;

    }



}

