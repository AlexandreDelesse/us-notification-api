using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PocMissionPush.Models;

[ApiController]
[Route("api/[controller]")]
public class NotificationsController : ControllerBase
{
    private readonly PushService _pushService;

    public NotificationsController(PushService pushService)
    {
        _pushService = pushService;
    }

    [Authorize]
    [HttpPost("subscribe")]
    public async Task<ActionResult<Subscription>> Subscribe([FromBody] Subscription subscription)
    {
        var userId = User.FindFirst("sub")?.Value;


        if (string.IsNullOrEmpty(userId))
            return Unauthorized("userId not found in token");

        subscription.UserId = userId;

        var presenter = new HttpPresenter<Subscription>();
        return await _pushService.StoreSubscription(subscription, presenter);


    }

    [Authorize]
    [HttpGet("subscriptions")]
    public async Task<ActionResult<List<Subscription>>> GetSubscriptions()
    {
        var presenter = new HttpPresenter<List<Subscription>>();
        return await _pushService.GetSubscriptions(presenter);
    }

    [Authorize]
    [HttpGet("subscriptionsByUserId")]
    public async Task<ActionResult<List<Subscription>>> GetSubscriptionsByUserId()
    {
        var userId = User.FindFirst("sub")?.Value;


        if (string.IsNullOrEmpty(userId))
            return Unauthorized("userId not found in token");

        var presenter = new HttpPresenter<List<Subscription>>();
        return await _pushService.GetSubscriptionsByUserId(userId, presenter);
    }

    [HttpPost("notifyAll")]
    public async Task<IActionResult> Notify(string message)
    {
        var payload = JsonConvert.SerializeObject(new
        {
            title = "Une notification",
            message
        });

        await _pushService.NotifyAll(payload);
        return Ok();
    }

}
