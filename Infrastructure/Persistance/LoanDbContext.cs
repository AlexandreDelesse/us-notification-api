using Microsoft.EntityFrameworkCore;
using PocMissionPush.Loan;

public class LoanDbContext : DbContext
{
    public LoanDbContext(DbContextOptions<LoanDbContext> options) : base(options)
    {

    }

    public DbSet<Loan> Loans { get; set; }
}