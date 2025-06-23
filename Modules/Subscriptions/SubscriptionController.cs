using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PocMissionPush.Subscriptions;

[ApiController]
[Route("api/[controller]")]
public class SubscriptionController : ControllerBase
{
    public SubscriptionService _subscriptionService;

    public SubscriptionController(SubscriptionService service)
    {
        _subscriptionService = service;
    }

    [HttpPost]
    public async Task<ActionResult<Subscription>> CreateSubscription([FromBody] SubscriptionCreateDTO newSub)
    {
        Subscription myNewSub = await _subscriptionService.CreateSubscription(newSub);
        return Ok(myNewSub);

    }

    [HttpDelete]
    public async Task<ActionResult> DeleteSubscription(string endpoint)
    {
        await _subscriptionService.DeleteSubscription(endpoint);
        return Ok();
    }
}