using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PocMissionPush.Subscriptions;

[ApiController]
[Route("api/[controller]")]
public class NotificationsController : ControllerBase
{
    private readonly PushService _pushService;

    public NotificationsController(PushService pushService)
    {
        _pushService = pushService;
    }

    [HttpPost("notifyByIds")]
    public async Task<ActionResult<List<string>>> NotifyAllUserIds([FromBody] NotificationCmd cmd)
    {
        var payload = JsonConvert.SerializeObject(new
        {
            title = "Une notification",
            message = "Un message pour tester"
        });


        List<string> endpoints = await _pushService.NotifyAllUserIds(cmd, payload);
        return Ok(endpoints);

    }

}
