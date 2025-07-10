using Microsoft.AspNetCore.Mvc;
using PocMissionPush.Loan;

[ApiController]
[Route("api/[controller]")]
public class LoanController : ControllerBase
{
    public LoanService _loanService;

    public LoanController(LoanService loanService)
    {
        _loanService = loanService;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        List<Loan> loanList = _loanService.GetLoans();
        if (loanList is not null) return Ok(loanList);
        else return BadRequest("Aucun emprunt trouvé");
    }
}