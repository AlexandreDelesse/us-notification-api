namespace PocMissionPush.Loan;

public class LoanService
{
    ILoanRepository _loanRepository;

    public LoanService(ILoanRepository loanRepository)
    {
        _loanRepository = loanRepository;
    }

    public List<Loan> GetLoans()
    {
        return _loanRepository.GetLoans();
    }
}