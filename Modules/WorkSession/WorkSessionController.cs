using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class WorkSessionController : ControllerBase
{
    public WorkSessionService _workSessionService;

    public WorkSessionController(WorkSessionService service)
    {
        _workSessionService = service;
    }

    [HttpGet("{userId}")]
    public ActionResult GetWorkSessionByUserId(string userId)
    {
        WorkSession? workSession = _workSessionService.GetWorkSessionByUserId(userId);
        if (workSession == null)
            return NotFound("Aucun service trouvé pour cet utilisateur");
        else return Ok(workSession);
    }

    [HttpPost("{sessionId}/status")]
    public ActionResult UpdateWorkSessionStatus(int sessionId, [FromBody] string sessionStatus)
    {
        WorkSession? result = _workSessionService.UpdateWorkSessionStatus(sessionId, sessionStatus);
        if (result is null) return BadRequest();
        return Ok(result);
    }
}